<?php

namespace SoftUni\ViewModels;

class TodosInformation
{
    public $error = false;
    public $success = false;
    private $user_id;
    private $todos = [];

    public function getUserId() {
        return $this->user_id;
    }

    public function setUserId($user_id) {
        $this->user_id = $user_id;
        return $this;
    }

    public function getTodos() {
        return $this->todos;
    }

    public function setTodos($todos) {
        $this->todos = $todos;
        return $this;
    }
}