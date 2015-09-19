<?php

session_start();

if (!isset($_SESSION['count'])) {
    $_SESSION['count'] = 0;
}

echo "Session counter: " . ++$_SESSION['count'];
