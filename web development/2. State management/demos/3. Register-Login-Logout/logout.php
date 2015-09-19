<?php
session_start();
session_destroy(); // Delete all data in $_SESSION[]

// Remove the PHPSESSID cookie from the browser
$params = session_get_cookie_params();
setcookie(session_name(), '', time() - 42000,
    $params["path"], $params["domain"],
    $params["secure"], $params["httponly"]
);

header('Location: login.php');
die;
