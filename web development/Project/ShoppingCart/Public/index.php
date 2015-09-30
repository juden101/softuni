<?php

error_reporting(E_ALL);
ini_set('display_errors', 1);

use Framework\App;

require_once '../../Framework/App.php';

$app = App::getInstance();
$app->run();

$config = $app->getConfig();