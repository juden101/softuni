<?php
include('config.php');
if (isset($_POST['user'])) {
    $username = $_POST['user'];
    $password = $_POST['pass'];
    $fullName = $_POST['fullName'];

    mysql_connect(DB_HOST, DB_USER, DB_PASS);
    mysql_select_db(DB_NAME);

    $hashPass = password_hash($password, PASSWORD_BCRYPT);

    // $username = mysql_real_escape_string($username);
    // $fullName = mysql_real_escape_string($fullName);
    $registerSql = "INSERT INTO users (Username, Password, FullName) VALUES ('".$username."', '".$hashPass."', '".$fullName."')";
    $result = mysql_query($registerSql);
    $row = @mysql_fetch_assoc($result);
    header('Location: login.php');
}

?>

<?php include('header.php') ?>

<?php if (isset($errorMsg)) : ?>
    <h2>Error: <?= $errorMsg ?></h2>
<?php endif ?>

    <h1>Please register:</h1>
    <form method="post">
        Username: <input type="text" name="user" />
        <br />
        Password: <input type="password" name="pass" />
        <br />
        Full name: <input type="text" name="fullName" />
        <br />
        <input type="submit" value="Register" />
    </form>
    <a href="login.php">Go login</a>

<?php include('footer.php') ?>