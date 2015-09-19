<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
</head>
<body>
    <form  method="POST">
        Username: <input type="text" name="username"/>
        Password: <input type="password" name="password"/>

        <select name="sex[]" id="sex">
            <option value="male">Male</option>
            <option value="female">Female</option>
            <option value="other">Other</option>
        </select>

        <input type="submit" name="submit" />
    </form>

    <?php
        echo "before SET";
        if(isset($_POST['submit'])) {
            echo "SET";
            $username = htmlentities($_POST['username']);
            $password = htmlentities($_POST['password']);
            $sex = $_POST['sex'];

            echo "Hello, $username!";
            echo "Pass: $password!";

            echo $sex[0];
        }
    ?>
</body>
</html>