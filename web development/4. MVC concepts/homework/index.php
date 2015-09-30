<?php

session_start();

require_once 'Application.php';
require_once 'Autoloader.php';

$autoloader = new \SoftUni\Autoloader();
$autoloader->init();

$uri = $_SERVER['REQUEST_URI'];
$self = $_SERVER['PHP_SELF'];
$index = basename($self);
$directories = str_replace($index, '', $self);
$requestString = str_replace($directories, '', $uri);

$requestParams = explode("/", $requestString);

$controller = array_shift($requestParams);
$action = array_shift($requestParams);

$controller == null ? $controller = \SoftUni\Config\ApplicationConfig::DEFAULT_CONTROLLER : null;
$action == null ? $action = \SoftUni\Config\ApplicationConfig::DEFAULT_ACTION : null;

\SoftUni\Core\Database::setInstance(
    \SoftUni\Config\DatabaseConfig::DB_INSTANCE,
    \SoftUni\Config\DatabaseConfig::DB_DRIVER,
    \SoftUni\Config\DatabaseConfig::DB_USER,
    \SoftUni\Config\DatabaseConfig::DB_PASS,
    \SoftUni\Config\DatabaseConfig::DB_NAME,
    \SoftUni\Config\DatabaseConfig::DB_HOST
);

$app = new \SoftUni\Application($controller, $action, $requestParams);
$app->start();