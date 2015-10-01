<?php

namespace Models\BindingModels;

class RegisterBindingModel
{
    private $username;
    private $password;
    private $confirm;

    function __construct(array $params)
    {
        $this->setUsername($params['username']);
        $this->setPassword($params['password']);
        $this->setConfirm($params['confirm']);
    }

    /**
     * @return string
     */
    public function getUsername()
    {
        return $this->username;
    }

    /**
     * @param string $username
     */
    private function setUsername($username)
    {
        $this->username = $username;
    }

    /**
     * @return string
     */
    public function getPassword()
    {
        return $this->password;
    }

    /**
     * @param string $password
     */
    private function setPassword($password)
    {
        $this->password = crypt($password, PASSWORD_DEFAULT);
    }

    public function getConfirm(){
        return $this->confirm;
    }

    private function setConfirm($password)
    {
        $this->confirm = crypt($password, PASSWORD_DEFAULT);
    }
}