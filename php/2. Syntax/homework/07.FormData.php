<!DOCTYPE html>
<html>
<head>
    <title>Form data</title>
</head>
<body>
    <form method="POST">
        <p><input type="text" name="name" placeholder="Name..." /></p>
        <p><input type="text" name="age" placeholder="Age..." /></p>
        <p><input type="radio" name="gender" id="male" value="male" /><label for="male">Male</label></p>
        <p><input type="radio" name="gender" id="female" value="female" /><label for="female">Female</label></p>
        <p><input type="submit" name="Submit" value="Submit" /></p>
    </form>

    <?php
    if(isset($_POST['name'], $_POST['age'], $_POST['gender'])) {
        echo sprintf('My name is %s. I am %d years old. I am %s.', $_POST['name'], $_POST['age'], $_POST['gender']);
    }
    ?>
</body>
</html>