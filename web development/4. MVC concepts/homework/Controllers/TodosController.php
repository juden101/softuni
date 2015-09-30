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
        if (!$this->isUserLogged())
        {
            header('Location: ../users/login');
            exit;
        }

        $todoModel = new Todos();
        $viewModel = new TodosInformation();

        if (isset($_POST['content'])) {
            if ($todoModel->addTodoItem($_SESSION['user_id'], $_POST['content'])) {
                $viewModel->success = 'Successfuly added todo';
                return new \SoftUni\View($viewModel);
            }

            $viewModel->error = 'An error occured';
            return new \SoftUni\View($viewModel);
        }

        return new \SoftUni\View();
    }

    public function delete($todo_id)
    {
        if (!$this->isUserLogged())
        {
            header('Location: ../users/login');
            exit;
        }

        $todoModel = new Todos();

        $todoModel->deleteTodoItem($_SESSION['user_id'], $todo_id);

        header('Location: ../../todos/index');
        exit;
    }
}