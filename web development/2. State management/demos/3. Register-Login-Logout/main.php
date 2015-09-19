<!DOCTYPE html>
<html>
<head>
    <title>User Area: Main Page</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <?php include('auth_header.php'); ?>

    <h1>Hi, <?= htmlspecialchars($_SESSION['user']) ?>, welcome to Main Page.</h1>

    <p>
        This page is for logged-in users only.
        Anonymous visitors cannot see it.
    </p>
</body>
</html>
