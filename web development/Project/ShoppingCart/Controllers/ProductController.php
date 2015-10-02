<?php

namespace Controllers;

use Framework\BaseController;
use Framework\Normalizer;
use Models\BindingModels\SellProductBindingModel;
use Models\ViewModels\ProductController\IndexViewModel;
use Models\ViewModels\ProductController\ProductViewModel;
use Models\ViewModels\ProductController\ProductMessage;

class ProductController extends BaseController
{
    /**
     * @Get
     * @Route("Products/{start:int}/{end:int}")
     */
    public function index()
    {
        $skip = $this->input->get(1);
        $take = $this->input->get(2) - $skip;
        $this->db->prepare("
            SELECT p.id, p.name, p.description, p.price, p.quantity, c.name as category
            FROM products p
            JOIN products_categories pc
                ON p.id = pc.productId
            JOIN categories c
                ON pc.categoryId = c.id
            WHERE quantity > 0
            ORDER BY p.id LIMIT {$take} OFFSET {$skip}");

        $response = $this->db->execute()->fetchAllAssoc();
        $products = [];

        foreach ($response as $product) {
            $p_id = isset($product['id']) ? $product['id'] : null;

            $products[] = new ProductViewModel(
                Normalizer::normalize($p_id, 'noescape|int'),
                $product['name'],
                $product['description'],
                Normalizer::normalize($product['price'], 'noescape|double'),
                Normalizer::normalize($product['quantity'], 'noescape|int'),
                $product['category']);
        }

        $this->view->appendToLayout('header', 'header');
        $this->view->appendToLayout('meta', 'meta');
        $this->view->appendToLayout('body', new IndexViewModel($products, $skip, $take + $skip));
        $this->view->appendToLayout('footer', 'footer');
        $this->view->displayLayout('Layouts.products');
    }

    /**
     * @Get
     * @Route("product/{id:int}/show")
     */
    public function product()
    {
        $id = $this->input->get(1);
        $this->db->prepare("
            SELECT p.id, p.name, p.description, p.price, p.quantity, c.name as category
            FROM products p
            JOIN products_categories pc
              ON p.id = pc.productId
            JOIN categories c
              ON pc.categoryId = c.id
            WHERE quantity > 0 AND p.id = ?",
            [ $id ]);

        $response = $this->db->execute()->fetchRowAssoc();

        if (!$response) {
            throw new \Exception("No product with id '$id'!", 404);
        }

        $this->db->prepare("
            SELECT u.username, u.isAdmin, u.isEditor, r.message
            FROM reviews r
            JOIN products p
                ON r.productId = p.id
            JOIN users u
                ON r.userId = u.id
            WHERE p.id = ?",
            [ $id ]);

        $reviews = $this->db->execute()->fetchAllAssoc();
        $givenReviews = [];

        foreach ($reviews as $review) {
            $givenReviews[] = new ProductMessage(
                $review['username'],
                $review['message'],
                Normalizer::normalize($review['isAdmin'], 'noescape|bool'),
                Normalizer::normalize($review['isEditor'], 'noescape|bool')
            );
        }

        $product = new ProductViewModel(
            Normalizer::normalize($response['id'], 'noescape|int'),
            $response['name'],
            $response['description'],
            Normalizer::normalize($response['price'], 'noescape|double'),
            Normalizer::normalize($response['quantity'], 'noescape|int'),
            $response['category'],
            $givenReviews
        );

        $this->view->appendToLayout('header', 'header');
        $this->view->appendToLayout('meta', 'meta');
        $this->view->appendToLayout('body', $product);
        $this->view->appendToLayout('footer', 'footer');
        $this->view->displayLayout('Layouts.product');
    }

    /**
     * @Route("products/sell")
     * @Authorize
     */
    public function sell()
    {
        $this->view->appendToLayout('header', 'header');
        $this->view->appendToLayout('meta', 'meta');
        $this->view->appendToLayout('body', 'sell');
        $this->view->appendToLayout('footer', 'footer');
        $this->view->displayLayout('Layouts.sellProduct');
    }

    /**
     * @Route("product/add")
     * @Post
     * @Authorize
     * @param SellProductBindingModel $model
     * @throws \Exception
     */
    public function add(SellProductBindingModel $model)
    {
        $this->db->prepare("
            SELECT id, name
            FROM categories
            WHERE name LIKE ?",
            [ $model->getCategory() ]);

        $response = $this->db->execute()->fetchRowAssoc();
        $categoryId = Normalizer::normalize($response['id'], 'noescape|int');

        if (!$response) {
            $name = $model->getCategory();
            throw new \Exception("No category '$name'!", 404);
        }

        $this->db->prepare("
            INSERT INTO products (name, description, price, quantity)
            VALUES (?, ?, ?, ?)",
            [ $model->getName(), $model->getDescription(), $model->getPrice(), 1 ]);
        $this->db->execute();

        $this->db->prepare("
            SELECT id
            FROM products
            WHERE name = ? AND description = ?",
            [ $model->getName(), $model->getDescription() ]);
        $response = $this->db->execute()->fetchRowAssoc();
        $productId = Normalizer::normalize($response['id'], 'noescape|int');

        $this->db->prepare("
            INSERT INTO products_categories (productId, categoryId)
            VALUES (?, ?)",
            [ $productId, $categoryId ]);
        $this->db->execute();

        $this->redirect("{$this->path}product/$productId/show");
    }
}