<?php

$list = explode(PHP_EOL, $_GET['list']);
$maxSize = $_GET['maxSize'];

echo '<ul>';
foreach($list as $string) {
    $string = trim($string);

    if(strlen($string) > 0) {
        strlen($string) > $maxSize ? $string = substr($string, 0, $maxSize) . '...' : null;
        echo '<li>' . htmlspecialchars($string) . '</li>';
    }
}
echo '</ul>';