<?php

namespace Framework;

use Framework\Routers\DefaultRouter;
use Framework\Routers\IRouter;

class FrontController {
    const CONTROLLERS_NAMESPACE = 'ShoppingCart\\Controllers\\';
    const CONTROLLERS_SUFFIX = 'Controller';

    private $_controller;
    private $_action;
    private $_params = [];
    private $_router = null;

    private  static  $_instance = null;

    private function __construct() {
    }

    public function getRouter() {
        return $this->_router;
    }

    public function setRouter(IRouter $router) {
        $this->_router = $router;
    }

    public static function getInstance() {
        if (self::$_instance == null) {
            self::$_instance = new FrontController();
        }

        return self::$_instance;
    }

    public function dispatch() {
        $this->_router->run();

        $controllerName =
            self::CONTROLLERS_NAMESPACE .
            $this->_router->getController() .
            self::CONTROLLERS_SUFFIX;

        $this->_controller = new $controllerName();
        $this->_action = $this->_router->getAction();
        $this->_params = $this->_router->getParams();

        call_user_func_array(
            [
                $this->_controller,
                $this->_action
            ],
            $this->_params
        );
    }
}