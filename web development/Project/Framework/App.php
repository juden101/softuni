<?php

namespace Framework;

use Framework\DB\SimpleDB;
use Framework\Routers\DefaultRouter;
use Framework\Routers\IRouter;
use Framework\Sessions\ISession;
use Framework\Sessions\NativeSession;

require_once 'Autoloader.php';

class App
{
    private static $_instance = null;
    /**
     * @var Config
     */
    private $_config = null;
    private $_frontController = null;
    private $_router = null;
    private $_dbConnections = [];
    /**
     * @var ISession
     */
    private $_session = null;

    private function __construct()
    {
        set_exception_handler(array($this, '_exceptionHandler'));
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

    public function getDbConnection($connection = 'default')
    {
        if (!$connection) {
            throw new \Exception('No connection string provided', 500);
        }

        if (isset($this->_dbConnections[$connection])) {
            return $this->_dbConnections[$connection];
        }

        $dbConfig = $this->getConfig()->database;

        if (!$dbConfig[$connection]) {
            throw new \Exception('No valid connection string found in config file', 500);
        }

        $database = new \PDO(
            $dbConfig[$connection]['connection_url'],
            $dbConfig[$connection]['username'],
            $dbConfig[$connection]['password'],
            $dbConfig[$connection]['pdo_options']
        );

        $this->_dbConnections[$connection] = $database;

        return $database;
    }

    /**
     * @return ISession
     */
    public function getSession(){
        return $this->_session;
    }

    public function setSession(ISession $session){
        $this->_session = $session;
    }

    public function run()
    {
        if ($this->_config->getConfigFolder() == null) {
            $this->setConfigFolder('ShoppingCart/config');
        }

        $this->_frontController = FrontController::getInstance();

        if ($this->_router instanceof IRouter) {
            $this->_frontController->setRouter($this->_router);
        }

        if ($this->_router == null) {
            $this->_frontController->setRouter(new DefaultRouter());
        }

        if ($this->_session == null) {
            $sessionInfo = $this->_config->app['session'];

            if ($sessionInfo['auto_start']) {
                if ($sessionInfo['type'] == 'native') {
                    $this->_session = new NativeSession(
                        $sessionInfo['name'],
                        $sessionInfo['lifetime'],
                        $sessionInfo['path'],
                        $sessionInfo['domain'],
                        $sessionInfo['secure']
                    );
                }
            }
        }

        $this->_frontController->dispatch();
    }

    public function _exceptionHandler($ex)
    {
        if ($this->_config && $this->_config->app['displayExceptions'] == true) {
            echo '<pre>' . print_r($ex, true) . '</pre>';
        } else {
            $this->displayError($ex->getCode());
        }
    }

    public function displayError($error)
    {
        try {
            $view = View::getInstance();
            $view->display('errors' . $error);
        } catch (\Exception $ex) {
            echo '<h1>' . $error . '</h1>';
            exit;
        }
    }

    public function __destruct()
    {
        if ($this->_session != null) {
            $this->_session->saveSession();
        }
    }

    public function getUsername()
    {
        return $this->_session->escapedUsername;
    }

    public function isLogged()
    {
        return $this->_session->escapedUsername !== null;
    }

    public function isAdmin()
    {
        return SimpleDB::isAdmin();
    }

    public function isEditor()
    {
        return SimpleDB::hasRole('editor');
    }

    public function isModerator()
    {
        return SimpleDB::hasRole('moderator');
    }
}