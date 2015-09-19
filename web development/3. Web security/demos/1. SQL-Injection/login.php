<?php
include('config.php');

// http://php.net/manual/bg/function.mysql-real-escape-string.php

if (isset($_POST['user'])) {
    $username = $_POST['user']; // ' or ''='
    $password = $_POST['pass'];

    mysql_connect(DB_HOST, DB_USER, DB_PASS);
    mysql_select_db(DB_NAME);

    $hashPass = hash('SHA256', $password);

    $loginQuery = "SELECT * FROM users WHERE username='{$username}' AND password='{$password}'";
    $result = mysql_query($loginQuery);
    $row = @mysql_fetch_assoc($result);
    var_dump($row);
    if($row) {
        session_start();
        $_SESSION['user'] = $username;
        header('Location: main.php');
        die;
    }
    else {
        $errorMsg = 'Invalid login.';
    }
}
?>
<?php include('header.php'); ?>
    <?php if (isset($errorMsg)) : ?>
        <h2>Error: <?= $errorMsg ?></h2>
    <?php endif ?>

    <h1>Please login:</h1>
    <form method="post">
        Username: <input type="text" name="user" />
        <br />
        Password: <input type="password" name="pass" />
        <br />
        <input type="submit" value="Login" />
    </form>
    <a href="register.php">Go register</a>

<?php include('footer.php') ?>
