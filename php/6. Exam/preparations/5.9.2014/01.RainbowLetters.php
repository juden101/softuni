<?php

$text = $_GET['text'];
$red = $_GET['red'];
$green = $_GET['green'];
$blue = $_GET['blue'];
$nth = $_GET['nth'];

$red = dechex($red);
$green = dechex($green);
$blue = dechex($blue);

strlen($red) == 1 ? $red = '0' . $red : null;
strlen($green) == 1 ? $green = '0' . $green : null;
strlen($blue) == 1 ? $blue = '0' . $blue : null;

$color = $red . $green . $blue;

echo '<p>';
for($i = 0; $i < strlen($text); $i++) {
    if(($i + 1) % $nth == 0) {
        echo '<span style="color: #' . $color . '">' . htmlspecialchars($text[$i]) . '</span>';
    }
    else {
        echo htmlspecialchars($text[$i]);
    }
}
echo '</p>';