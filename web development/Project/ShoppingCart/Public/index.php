<?php

error_reporting(E_ALL);
ini_set('display_errors', 1);

use Framework\App;
use Routers\SimpleRouter;

require_once '../../Framework/App.php';
require_once '../Routers/SimpleRouter.php';

$app = App::getInstance();
$app->run();