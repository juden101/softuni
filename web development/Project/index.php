<?php

error_reporting(E_ALL);
ini_set('display_errors', 1);

use Framework\App;
use Framework\Autoloader;

require_once 'Framework/App.php';
require_once 'Framework/Autoloader.php';

Autoloader::init();

$app = App::getInstance();
$app->run();

$config = $app->getConfig();