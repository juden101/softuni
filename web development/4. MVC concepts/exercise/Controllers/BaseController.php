<?php

namespace SoftUni\Controllers;

abstract class BaseController
{
    public function isUserLogged()
    {
        return isset($_SESSION['user_id']) && $_SESSION['user_id'] != null;
    }
}