<?php

namespace Controllers;

use Framework\App;
use Framework\BaseController;
use Models\BindingModels\LoginBindingModel;
use Models\BindingModels\RegisterBindingModel;
use Models\ViewModels\IndexController\CreateViewModel;

class IndexController extends BaseController
{
    public function index()
    {
        $this->view->appendToLayout('header', 'header');
        $this->view->appendToLayout('footer', 'footer');
        $this->view->displayLayout('Layouts.home');
    }

    /**
     * @Route("test")
     */
    public function create()
    {
        $this->view->display(new CreateViewModel('test'));
    }

    /**
     * @Route("test/delete")
     * @Delete
     */
    public function delete()
    {
        echo "delete";
    }

    /**
     * @NotLogged
     * @param LoginBindingModel $model
     * @throws \Exception
     */
    public function login(LoginBindingModel $model)
    {
        $this->db->prepare("
            SELECT id
            FROM users
            WHERE username = ? AND password = ?",
            array($model->getUsername(), $model->getPassword()));

        $response = $this->db->execute()->fetchRowAssoc();
        $id = $response['id'];
        $this->session->_login = $id;

        $this->session->_username = $model->getUsername();
        $this->redirect('../home/index');
    }

    /**
     * @Authorize error:("You are not logged in!")
     * @throws \Exception
     */
    public function logout()
    {
        $this->session->destroySession();
        $this->redirect('../home/index');
    }

    /**
     * @NotLogged
     * @param RegisterBindingModel $model
     */
    public function register(RegisterBindingModel $model)
    {
        // Check for already registered with the same name
        $this->db->prepare("
            SELECT id
            FROM users
            WHERE username = ?",
            array($model->getUsername()));

        $response = $this->db->execute()->fetchRowAssoc();
        $id = $response['id'];

        if ($id !== null) {
            $username = $model->getUsername();
            throw new \Exception("Username '$username' already taken!", 400);
        }

        $this->db->prepare("
            INSERT INTO users (username, password, cash)
            VALUES (?, ?, ?)",
            [
                $model->getUsername(),
                $model->getPassword(),
                App::getInstance()->getConfig()->shopping_cart['initialCash']
            ])->execute();

        $loginBindingModel = new LoginBindingModel(array('username' => $model->getUsername(), 'password' => $model->getPassword()));
        $loginBindingModel->afterRegisterPasswordPass($model->getPassword());
        $this->login($loginBindingModel);
    }
}