<?php

namespace Controllers;

use Framework\BaseController;
use Framework\Normalizer;
use Models\ViewModels\ProductController\IndexViewModel;
use Models\ViewModels\ProductController\ProductViewModel;

class ProductController extends BaseController
{
    /**
     * @Get
     * @Route("Products/{start:int}/{end:int}")
     */
    public function index()
    {
        $skip = $this->input->get(1);
        $take = $this->input->get(2);
        $this->db->prepare("
            SELECT p.name, p.description, p.price, p.quantity, c.name as category
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
            $products[] = new ProductViewModel(
                $product['name'],
                $product['description'],
                Normalizer::normalize($product['price'], 'noescape|double'),
                Normalizer::normalize($product['quantity'], 'noescape|int'),
                $product['category']);
        }

        $this->view->appendToLayout('header', 'header');
        $this->view->appendToLayout('meta', 'meta');
        $this->view->appendToLayout('body', new IndexViewModel($products, $skip, $take));
        $this->view->appendToLayout('footer', 'footer');
        $this->view->displayLayout('Layouts.products');
    }
}