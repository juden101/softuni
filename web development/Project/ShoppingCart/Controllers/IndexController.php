<?php

namespace Controllers;

use Framework\BaseController;
use Models\ViewModels\IndexController\IndexViewModel;

class IndexController extends BaseController {
    public function index() {
        $this->view->display(new IndexViewModel('test'));
    }

    public function test() {
        echo "Test action";
    }
}