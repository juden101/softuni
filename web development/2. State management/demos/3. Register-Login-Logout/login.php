<?php
if (isset($_POST['user'])) {
    $username = $_POST['user'];
    $password = $_POST['pass'];
    if (checkLogin($username, $password)) {
        if ($_POST['remember_me']) {
            // Set the session timeout to 3 months
            ini_set("session.cookie_lifetime", 3 * 30 * 24 * 60 * 60);
        }
        session_start();
        $_SESSION['user'] = $username;
        header('Location: main.php');
        die;
    }
    $errorMsg = 'Invalid login.';
}

function checkLogin($user, $pass) {
    return $user == 'admin' && $pass == 'admin';
}
?>

<!DOCTYPE html>
<html>
<head>
    <title>Login</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <?php if (isset($errorMsg)) : ?>
        <h2>Error: <?= $errorMsg ?></h2>
    <?php endif ?>

    <h1>Please login:</h1>
    <form method="post">
        Username: <input type="text" name="user" />
        <br />
        Password: <input type="password" name="pass" />
        <br />
        Remember me: <input type="checkbox" name="remember_me" />
        <br />
        <input type="submit" value="Login" />
    </form>
</body>
</html>
