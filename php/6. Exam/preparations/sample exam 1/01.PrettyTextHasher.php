<?php

$text = $_GET['text'];
$hashValue = $_GET['hashValue'];
$fontSize = $_GET['fontSize'];
$fontStyle = $_GET['fontStyle'];

$cssStyle = '';
if($fontStyle == 'bold') {
    $cssStyle = 'font-weight:bold;';
}
else {
    $cssStyle = "font-style:{$fontStyle};";
}

$textResult = '';
for($i = 0; $i < strlen($text); $i++) {
    $char = $text[$i];

    if($i % 2 == 0) {
        $textResult .= chr(ord($char) + $hashValue);
    }
    else {
        $textResult .= chr(ord($char) - $hashValue);
    }
}

echo "<p style=\"font-size:{$fontSize};{$cssStyle}\">{$textResult}</p>";