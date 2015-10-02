<?php

namespace Controllers;

use Framework\BaseController;
use Framework\Normalizer;
use Models\ViewModels\CategoryController\CategoryViewModel;
use Models\ViewModels\CategoryController\IndexViewModel;
use Models\ViewModels\CategoryController\ShowViewModel;
use Models\ViewModels\ProductController\ProductViewModel;

class CategoryController extends BaseController
{
    /**
     * @Get
     * @Route("Categories/{category:string}/{start:int}/{end:int}")
     */
    public function show()
    {
        $category = $this->input->getForDb(1);
        $skip = $this->input->get(2);
        $take = $this->input->get(3) - $skip;

        $this->db->prepare("
            SELECT p.id, p.name, p.description, p.price, p.quantity, c.name as category
            FROM products p
            JOIN products_categories pc
                ON p.id = pc.productId
            JOIN categories c
                ON pc.categoryId = c.id
            WHERE quantity > 0 AND c.name LIKE ?
            ORDER BY p.id LIMIT {$take} OFFSET {$skip}",
            [ $category ]);

        $response = $this->db->execute()->fetchAllAssoc();
        $products = [];

        foreach ($response as $product) {
            $products[] = new ProductViewModel(
                Normalizer::normalize($product['id'], 'noescape|int'),
                $product['name'],
                $product['description'],
                Normalizer::normalize($product['price'], 'noescape|double'),
                Normalizer::normalize($product['quantity'], 'noescape|int'),
                $product['category']);
        }

        // Escaped one
        $category = $this->input->get(1);
        $this->view->appendToLayout('header', 'header');
        $this->view->appendToLayout('meta', 'meta');
        $this->view->appendToLayout('body', new ShowViewModel($products, $skip, $take + $skip, $category));
        $this->view->appendToLayout('footer', 'footer');
        $this->view->displayLayout('Layouts.products');
    }

    public function index()
    {
        $this->db->prepare("
            SELECT name
            FROM categories
            ORDER BY name");

        $response = $this->db->execute()->fetchAllAssoc();
        $categories = [];

        foreach ($response as $category) {
            $categories[] = new CategoryViewModel($category['name']);
        }

        $this->view->appendToLayout('header', 'header');
        $this->view->appendToLayout('meta', 'meta');
        $this->view->appendToLayout('body', new IndexViewModel($categories));
        $this->view->appendToLayout('footer', 'footer');
        $this->view->displayLayout('Layouts.categories');
    }
}