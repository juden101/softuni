<?php

namespace SoftUni\Controllers;

use SoftUni\BindingModels\UserBindingModel;
use SoftUni\Models\Users;
use SoftUni\ViewModels\RegisterInformation;
use SoftUni\ViewModels\LoginInformation;
use SoftUni\ViewModels\ProfileInformation;
use SoftUni\ViewModels\BuildingsInformation;

class UsersController extends BaseController
{
    public function profile()
    {
        if (!$this->isUserLogged())
        {
            header('Location: login');
            exit;
        }

        $userModel = new Users();

        $viewModel = new ProfileInformation();
        $viewModel->setUser($userModel->get($_SESSION['user_id']));

        if (isset($_POST['edit'])) {
            if ($_POST['password'] != $_POST['confirm'] || empty($_POST['password'])) {
                $viewModel->error = 'An error occured';
                return new \SoftUni\View($viewModel);
            }

            $userBindingModel = new UserBindingModel(
                $_POST['username'],
                $_POST['password'],
                $_SESSION['user_id']
            );

            if ($userModel->edit($userBindingModel)) {
                $viewModel->success = 'Successfuly update profile';
                return new \SoftUni\View($viewModel);
            }

            $viewModel->error = 'An error occured';
            return new \SoftUni\View($viewModel);
        }

        return new \SoftUni\View($viewModel);
    }

    public function register()
    {
        if ($this->isUserLogged())
        {
            header('Location: profile');
            exit;
        }

        $viewModel = new RegisterInformation();

        if (isset($_POST['username'], $_POST['password'])) {
            try {
                $user = $_POST['username'];
                $pass = $_POST['password'];

                $userModel = new Users();
                $userModel->register($user, $pass);

                $this->initLogin($user, $pass);
            } catch (\Exception $e) {
                $viewModel->error = $e->getMessage();
                return new \SoftUni\View($viewModel);
            }
        }

        return new \SoftUni\View();
    }

    public function login()
    {
        if ($this->isUserLogged())
        {
            header('Location: profile');
            exit;
        }

        $viewModel = new LoginInformation();

        if (isset($_POST['username'], $_POST['password'])) {
            try {
                $user = $_POST['username'];
                $pass = $_POST['password'];

                $this->initLogin($user, $pass);
            } catch (\Exception $e) {
                $viewModel->error = $e->getMessage();
                return new \SoftUni\View($viewModel);
            }
        }

        return new \SoftUni\View();
    }

    public function logout()
    {
        if (!$this->isUserLogged())
        {
            header('Location: login');
            exit;
        }

        $this->initLogout();

        header('Location: login');
        exit;
    }

    private function initLogin($user, $pass)
    {
        $userModel = new Users();
        $userId = $userModel->login($user, $pass);
        $_SESSION['user_id'] = $userId;

        header("Location: profile");
        exit;
    }

    private function initLogout()
    {
        session_destroy();
    }
}