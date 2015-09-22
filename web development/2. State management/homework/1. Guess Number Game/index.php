<?php
session_start();

if (isset($_POST['name']) && $_POST['name'] != null) {
    $_SESSION['game_number'] = rand(0, 100);
    $_SESSION['name'] = $_POST['name'];
}

if (isset($_SESSION['game_number']) && $_SESSION['game_number'] != null) {
    header('Location: play.php');
}

?>

<form method="POST">
    <input type="text" name="name" placeholder="Name..." />
    <input type="submit" value="[Start Game]" />
</form>