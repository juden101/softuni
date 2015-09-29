<?php

namespace Framework;

use Framework\Routers\DefaultRouter;

require_once 'Autoloader.php';

class App {
    private static $_instance = null;
    private $_config = null;
    private $_frontController = null;
    private $_router = null;

    private function __construct() {
        Autoloader::registerNamespace('Framework', dirname(__FILE__) . DIRECTORY_SEPARATOR);
        Autoloader::registerAutoload();

        $this->_config = Config::getInstance();
        $this->_router = new DefaultRouter();
    }

    public function getConfigFolder() {
        return $this->_config->getConfigFolder();
    }

    private function setConfigFolder($path) {
        $this->_config->setConfigFolder($path);
    }

    public function getRouter() {
        return $this->_router;
    }

    public function setRouter($router) {
        $this->_router = $router;
    }

    /**
     * @return Config
     */
    public function getConfig() {
        return $this->_config;
    }

    /**
     * @return App
     */
    public static function getInstance() {
        if (self::$_instance == null) {
            self::$_instance = new App();
        }
        return self::$_instance;
    }

    public function run() {
        if ($this->_config->getConfigFolder() == null) {
            $this->setConfigFolder('Config');
        }

        $this->_frontController = FrontController::getInstance();
        $this->_frontController->setRouter($this->_router);
        $this->_frontController->dispatch();
    }
}