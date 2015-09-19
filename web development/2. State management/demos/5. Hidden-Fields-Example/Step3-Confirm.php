<!DOCTYPE html>
<html>
<head>
    <title>Step 3 - Confirm Customer Data</title>
</head>
<body>
    <h2>Confirm Customer Data</h2>
    First name: <?= htmlspecialchars($_POST['first_name']) ?>
    <br />
    Last name: <?= htmlspecialchars($_POST['last_name']) ?>
    <br />
    Address: <?= htmlspecialchars($_POST['address']) ?>
</body>
</html>
