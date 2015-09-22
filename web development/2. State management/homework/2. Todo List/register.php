<?php

include_once 'db.php';

if (isset($_POST['register']) && $_POST['register'] == 1) {
    $username = $_POST['username'];
    $password = $_POST['password'];

    $register_output = createUser ($username, $password);

    echo $register_output;
}

?>
<a href="login.php">Login</a>

<form method="POST">
    <input type="text" name="username" placeholder="username" />
    <input type="password" name="password" placeholder="password" />
    <input type="hidden" name="register" value="1" />
    <input type="submit" value="Register" />
</form>