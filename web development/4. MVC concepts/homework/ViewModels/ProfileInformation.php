<?php

namespace SoftUni\ViewModels;

class ProfileInformation
{
    public $error = false;
    public $success = false;
    private $user;
    private $id;
    private $username;
    private $pass;
    private $gold;
    private $food;

    public function getUser()
    {
        return $this->user;
    }

    public function setUser($user)
    {
        $this->setId($user->id);
        $this->setUsername($user->username);
        $this->setPass($user->password);
        $this->setGold($user->gold);
        $this->setFood($user->food);
        return $this;
    }

    public function getId() {
        return $this->id;
    }

    public function setId($id) {
        $this->id = $id;
        return $this;
    }

    public function getUsername() {
        return $this->username;
    }

    public function setUsername($username) {
        $this->username = $username;
        return $this;
    }

    public function getPass() {
        return $this->pass;
    }

    public function setPass($pass) {
        $this->pass = $pass;
        return $this;
    }

    public function getGold() {
        return $this->gold;
    }

    public function setGold($gold) {
        $this->gold = $gold;
        return $this;
    }

    public function getFood() {
        return $this->food;
    }

    public function setFood($food) {
        $this->food = $food;
        return $this;
    }
}