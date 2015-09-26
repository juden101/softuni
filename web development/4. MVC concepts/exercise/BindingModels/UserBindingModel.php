<?php

namespace SoftUni\BindingModels;

class UserBindingModel
{
    private $id;
    private $user;
    private $pass;
    private $gold;
    private $food;

    public function __construct($user, $pass, $id = null, $gold = null, $food = null) {
        $this->setId($id)
            ->setUsername($user)
            ->setPass($pass)
            ->setGold($gold)
            ->setFood($food);
    }

    public function getId() {
        return $this->id;
    }

    public function setId($id) {
        $this->id = $id;
        return $this;
    }

    public function getUsername() {
        return $this->user;
    }

    public function setUsername($user) {
        $this->user = $user;
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