<?php

namespace SoftUni\Controllers;

use SoftUni\Models\Todos;
use SoftUni\ViewModels\RegisterInformation;
use SoftUni\ViewModels\LoginInformation;
use SoftUni\ViewModels\TodosInformation;

class TodosController extends BaseController
{
    public function index()
    {
        if (!$this->isUserLogged())
        {
            header('Location: ../users/login');
            exit;
        }

        $todosModel = new Todos();
        $todo_items = $todosModel->getTodoItems($_SESSION['user_id']);

        $viewModel = new TodosInformation();
        $viewModel->setUserId($_SESSION['user_id']);
        $viewModel->setTodos($todo_items);

        return new \SoftUni\View($viewModel);
    }

    public function add()
    {
        if ($this->isUserLogged())
        {
            header('Location: ../users/login');
            exit;
        }


    }
}