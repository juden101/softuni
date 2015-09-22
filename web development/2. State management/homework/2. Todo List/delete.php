<?php
session_start();
include_once 'db.php';

if (!isset($_GET['todo_id']) || $_GET['todo_id'] == null) {
    header ('Location: list.php');
    exit;
}

$todo_id = $_GET['todo_id'];
$user_id = $_SESSION['user_id'];

deleteTodoItem($user_id, $todo_id);

header ('Location: list.php');
exit;