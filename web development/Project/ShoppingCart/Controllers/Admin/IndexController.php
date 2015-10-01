<?php

namespace Controllers\Admin;

use Framework\BaseController;
use Models\ViewModels\Admin\IndexController\AdminCreateViewModel;
use Models\ViewModels\Admin\IndexController\AdminIndexViewModel;
use Models\ViewModels\IndexViewModel;

class IndexController extends BaseController
{
    public function index()
    {
        $model = 'test';
        $validModel = $this->validator->setRule('minlength', $model, 10, 'invalid lenght')->validate();

        if (!$validModel) {
            $model = $this->validator->getErrors()[0];
        }

        //$this->view->appendToLayout('body', new IndexViewModel('test'));
        $this->view->appendToLayout('body', new AdminIndexViewModel('TestAdmin', $model, 'no'));
        $this->view->appendToLayout('header', 'header');
        $this->view->appendToLayout('footer', 'footer');
        $this->view->displayLayout('Layouts.Admin.home');
    }

    public function create()
    {
        //$this->view->appendToLayout('body', new AdminIndexViewModel('TestAdmin', '1', 'no'));
        $this->view->appendToLayout('body', new AdminCreateViewModel('TestAdmin'));
        $this->view->appendToLayout('header', 'header');
        $this->view->appendToLayout('footer', 'footer');
        $this->view->displayLayout('Layouts.Admin.home');
    }
}