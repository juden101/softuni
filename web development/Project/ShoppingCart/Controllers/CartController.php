<?php

namespace Controllers;

use Framework\BaseController;
use Framework\Normalizer;
use Models\ViewModels\CartController\CartProductViewModel;
use Models\ViewModels\CartController\IndexViewModel;

class CartController extends BaseController
{
    /**
     * @Authorize
     */
    public function index()
    {
        $cart = $this->session->cart;
        $products = [];
        $totalPrice = 0;
        $money = 0;

        if ($cart) {
            foreach ($cart as $itemId) {
                $this->db->prepare("
                    SELECT p.id, p.name, p.price
                    FROM products p
                    JOIN products_categories pc
                        ON p.id = pc.productId
                    JOIN categories c
                        ON pc.categoryId = c.id
                    WHERE p.id = ?",
                    [ $itemId ]);

                $response = $this->db->execute()->fetchRowAssoc();
                $price = Normalizer::normalize($response['price'], 'noescape|double');
                $product = new CartProductViewModel(
                    Normalizer::normalize($response['id'], 'noescape|int'),
                    $response['name'],
                    $price);

                $products[] = $product;
                $totalPrice += $price;
            }

            $this->db->prepare("
                SELECT cash
                FROM users
                WHERE id = ? AND username = ?",
                [ $this->session->_login, $this->session->_username ]);
            $response = $this->db->execute()->fetchRowAssoc();
            $money = isset($response['cash']) ? Normalizer::normalize($response['cash'], 'noescape|double') : 0;
        }

        $this->view->appendToLayout('header', 'header');
        $this->view->appendToLayout('meta', 'meta');
        $this->view->appendToLayout('body', new IndexViewModel($products, $totalPrice, $money));
        $this->view->appendToLayout('footer', 'footer');
        $this->view->displayLayout('Layouts.cart');
    }

    /**
     * @Authorize
     * @Get
     * @Route("cart/add/{id:int}")
     */
    public function add()
    {
        if (!$this->session->cart) {
            $this->session->cart = [];
        }

        $cart = $this->session->cart;
        $cart[] = $this->input->get(2);
        $this->session->cart = $cart;

        $this->redirect($this->path);
    }

    /**
     * @Authorize
     * @Delete
     * @Route("cart/remove/{id:int}")
     */
    public function remove()
    {
        if (!$this->session->cart) {
            throw new \Exception("Cart is empty!", 500);
        }

        $id = $this->input->get(2);
        $cart = $this->session->cart;

        foreach ($cart as $k => $itemId) {
            if ($itemId == $id) {
                unset($cart[$k]);
                break;
            }
        }

        $this->session->cart = $cart;
        $this->redirect($this->path . 'cart');
    }
}