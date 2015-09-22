<?php

session_start();
include_once 'db.php';

if (isset($_POST['add']) && $_POST['add'] == 1) {
    $todo_text = $_POST['todo'];
    $user_id = $_SESSION['user_id'];

    addTodoItem ($user_id, $todo_text);
}

header ('Location: list.php');
exit;