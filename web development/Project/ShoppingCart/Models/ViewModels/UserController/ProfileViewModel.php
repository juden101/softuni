<?php

namespace Models\ViewModels\UserController;

class ProfileViewModel
{
    private $username;
    private $isAdmin;
    private $balance;
    private $isEditor;

    function __construct($username, $isAdmin, $balance, $isEditor)
    {
        $this->username = $username;
        $this->isAdmin = $isAdmin;
        $this->balance = $balance;
        $this->isEditor = $isEditor;
    }

    /**
     * @return mixed
     */
    public function getUsername()
    {
        return $this->username;
    }

    /**
     * @return mixed
     */
    public function getIsAdmin()
    {
        return $this->isAdmin;
    }

    /**
     * @return mixed
     */
    public function getIsEditor()
    {
        return $this->isEditor;
    }

    /**
     * @return mixed
     */
    public function getBalance()
    {
        return $this->balance;
    }
}