<?php include('header.php'); ?>
<?php include('auth_header.php'); ?>
<?php include('config.php'); ?>

<?php
    if (isset($_POST['fullName'])){
        mysql_connect(DB_HOST, DB_USER, DB_PASS);
        mysql_select_db(DB_NAME);
        $searchSql = "UPDATE Users SET FullName = '".$_POST['fullName']."' WHERE Username = '".$_POST['username']."'";
        $result = mysql_query($searchSql);
        if($result) {
            echo "Updated";
            exit;
        }
    }

    if(!isset($_GET['user'])){
        echo "Wrong link!";
        exit;
    }
?>


<form action="" method="POST">
    Fullname: <input type="text" name="fullName" />
    <input type="hidden" name="username" value="<?php echo $_GET['user'] ?>"/>
    <br />
    <input type="submit" value="Change full name" />
</form>

<?php include('footer.php'); ?>