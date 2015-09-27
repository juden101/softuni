<?php

namespace Framework;

require_once 'Autoloader.php';

class App {
    private static $_instance = null;
    private $_config = null;

    private function __construct(){
        Autoloader::registerNamespace('Framework', dirname(__FILE__) . DIRECTORY_SEPARATOR);
        Autoloader::registerAutoload();
        $this->_config = Config::getInstance();
    }

    public function getConfigFolder(){
        return $this->_config->getConfigFolder();
    }

    public function setConfigFolder($path){
        $this->_config->setConfigFolder($path);
    }

    /**
     * @return Config
     */
    public function getConfig(){
        return $this->_config;
    }

    /**
     * @return App
     */
    public static function getInstance(){
        if (self::$_instance == null) {
            self::$_instance = new App();
        }
        return self::$_instance;
    }

    public function run()
    {
        if ($this->_config->getConfigFolder() == null) {
            $this->setConfigFolder('Config');
        }
    }
}