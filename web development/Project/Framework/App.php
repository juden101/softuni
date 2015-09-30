<?php

namespace Framework;

use Framework\Routers\DefaultRouter;
use Framework\Routers\IRouter;

require_once 'Autoloader.php';

class App
{
    private static $_instance = null;
    private $_config = null;
    private $_frontController = null;
    private $_router = null;

    private function __construct()
    {
        Autoloader::registerNamespace('Framework', dirname(__FILE__) . DIRECTORY_SEPARATOR);
        Autoloader::registerAutoLoad();
        $this->_config = Config::getInstance();
    }

    public function setConfigFolder($path)
    {
        $this->_config->setConfigFolder($path);
    }

    public function getConfigFolder()
    {
        return $this->_config->getConfigFolder();
    }

    public function getRouter()
    {
        return $this->_router;
    }

    function setRouter($router)
    {
        $this->_router = $router;
    }

    /**
     * @return App
     */
    public static function getInstance()
    {
        if (self::$_instance == null) {
            self::$_instance = new App();
        }

        return self::$_instance;
    }

    /**
     * @return Config
     */
    public function getConfig()
    {
        return $this->_config;
    }

    public function run()
    {
        if ($this->_config->getConfigFolder() == null) {
            $this->setConfigFolder('../Config');
        }

        $this->_frontController = FrontController::getInstance();

        if ($this->_router instanceof IRouter) {
            $this->_frontController->setRouter($this->_router);
        } else {
            switch ($this->_router) {
                case 'JsonRPCRouter':
                    // todo
                    break;
                case 'RPCRouter':
                    // todo
                    break;
                default:
                    $this->_frontController->setRouter(new DefaultRouter());
                    break;
            }
        }

        $this->_frontController->dispatch();
    }
}