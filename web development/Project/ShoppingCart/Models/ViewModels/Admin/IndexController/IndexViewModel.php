<?php

namespace Models\ViewModels\Admin\IndexController;

class IndexViewModel {
    private $admins;

    public function __construct($admins)
    {
        $this->admins = $admins;
    }

    public function getAdmins()
    {
        return $this->admins;
    }
}