<?php
session_start();
include_once 'db.php';

if (isset($_POST['login']) && $_POST['login'] == 1) {
    $username = $_POST['username'];
    $password = $_POST['password'];

    $login_output = isUserValid ($username, $password);

    if ($login_output != false) {
        $_SESSION['username'] = $username;
        $_SESSION['user_id'] = $login_output['id'];

        header ('Location: list.php');
        exit;
    } else {
        echo '<h1>Invalid login</h1>';
    }
}

?>

<a href="register.php">Register</a>

<form method="POST">
    <input type="text" name="username" placeholder="username" />
    <input type="password" name="password" placeholder="password" />
    <input type="hidden" name="login" value="1" />
    <input type="submit" value="Login" />
</form>