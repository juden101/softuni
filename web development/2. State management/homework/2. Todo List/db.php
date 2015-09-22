<?php

include_once('database.php');

function createUser ($username, $password) {
    $db = Database::getInstance()->getConnection();

    $sql = 'INSERT INTO `users` (username, password_hash) VALUES (:username, :password_hash)';
    $query = $db->prepare($sql);
    $query->execute(array(':username' => $username, ':password_hash' => md5($password)));

    $rows = $query->rowCount();
    if ($rows == 1) {
        return "Successfully registered";
    }

    return "Try again";
}

function isUserValid ($username, $password) {
    $db = Database::getInstance()->getConnection();
    $sql = 'SELECT `id` FROM `users` WHERE username=:username AND password_hash=:password_hash';
    $query = $db->prepare($sql);
    $query->execute(array(':username' => $username, ':password_hash' => md5($password)));

    return $query->fetch();
}

function getTodoItems ($user_id) {
    $db = Database::getInstance()->getConnection();
    $sql = 'SELECT * FROM `todos` WHERE user_id=:user_id';
    $query = $db->prepare($sql);
    $query->execute(array(':user_id' => $user_id));

    return $query->fetchAll();
}

function addTodoItem ($user_id, $todo_text) {
    $db = Database::getInstance()->getConnection();

    $sql = 'INSERT INTO `todos` (user_id, todo_item) VALUES (:user_id, :todo_item)';
    $query = $db->prepare($sql);
    $query->execute(array(':user_id' => $user_id, ':todo_item' => $todo_text));
}

function deleteTodoItem ($user_id, $todo_id) {
    $db = Database::getInstance()->getConnection();

    $sql = 'DELETE FROM `todos` WHERE user_id=:user_id AND id=:id';
    $query = $db->prepare($sql);
    $query->execute(array(':user_id' => $user_id, ':id' => $todo_id));
}