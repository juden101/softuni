<?php
$email = "<p class='recipient'>" . htmlspecialchars($_GET['recipient']) . "</p><p class='subject'>" . htmlspecialchars($_GET['subject']) . "</p><p class='message'>" . htmlspecialchars($_GET['body']) . "</p>";

for($i = 0, $j = 0; $i < strlen($email); $i++, $j++) {
    echo $i > 0 ? dechex(ord($email[$i])  * ord($_GET['key'][$j])) . '|' : '|' . dechex(ord($email[$i])  * ord($_GET['key'][$j])) . '|';
    $j == strlen($_GET['key']) - 1 ? $j = -1 : null;
}