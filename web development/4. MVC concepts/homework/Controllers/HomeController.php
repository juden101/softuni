<?php

namespace SoftUni\Controllers;

use SoftUni\ViewModels\HomeInformation;

class HomeController extends BaseController
{
    public function index()
    {
        if ($this->isUserLogged())
        {
            header('Location: login');
            exit;
        }

        $viewModel = new HomeInformation();

        return new \SoftUni\View($viewModel);
    }
}