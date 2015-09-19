<?php
include('config.php');

if (isset($_POST['user'])) {
    $username = $_POST['user'];
    $password = $_POST['pass'];

    mysql_connect(DB_HOST, DB_USER, DB_PASS);
    mysql_select_db(DB_NAME);

    $loginQuery = "SELECT Id, Username, Password, FullName FROM Users WHERE username = '".$username."'";
    echo $loginQuery;
    $result = mysql_query($loginQuery);
    $row = @mysql_fetch_assoc($result);
    var_dump($row);
    if(!$row) {
        $errorMsg = 'Invalid login.';
    }

    if (password_verify($password, $row['Password'])) {
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
