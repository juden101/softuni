<?php
session_start();
include_once 'db.php';

if (!isset($_SESSION['user_id']) || $_SESSION['user_id'] == null) {
    header ('Location: login.php');
    exit;
}

$username = $_SESSION['username'];
$user_id = $_SESSION['user_id'];

$todo_items = getTodoItems($user_id);
?>

<a href="logout.php">Logout</a>

<form method="POST" action="add.php">
    <input type="text" name="todo" />
    <input type="hidden" name="add" value="1" />
    <input type="submit" value="Add" />
</form>

<ul>
    <?php foreach ($todo_items as $item): ?>
        <li><?= $item['todo_item']; ?> <a href="delete.php?todo_id=<?= $item['id']; ?>">Delete</a></li>
    <?php endforeach; ?>
</ul>