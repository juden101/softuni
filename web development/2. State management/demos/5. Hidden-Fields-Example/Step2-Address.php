<!DOCTYPE html>
<html>
<head>
    <title>Step 2 - Address</title>
</head>
<body>
    <form method="post" action="Step3-Confirm.php">
        <input type="hidden" name="first_name"
               value="<?= htmlspecialchars($_POST['first_name']) ?>" />
        <input type="hidden" name="last_name"
               value="<?= htmlspecialchars($_POST['last_name']) ?>" />
        Address: <input type="text" name="address" />
        <br />
        <input type="submit" value="Next" />
    </form>
</body>
</html>
