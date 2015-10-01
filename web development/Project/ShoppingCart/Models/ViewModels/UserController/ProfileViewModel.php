<?php

namespace Models\ViewModels\UserController;

class ProfileViewModel
{
    private $username;
    private $isAdmin;

    function __construct($username, $isAdmin)
    {
        $this->username = $username;
        $this->isAdmin = $isAdmin;
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
}