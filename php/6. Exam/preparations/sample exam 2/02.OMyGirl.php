<?php

$text = $_GET['text'];
$key = $_GET['key'];

$keyLength = strlen($key);
$regex = '';
$result = '';

$regex .= !ctype_alpha($key[0]) && !ctype_digit($key[0]) ? '\\' . $key[0] : $key[0];
for($i = 1; $i < $keyLength - 1; $i++) {
    $currentChar = $key[$i];

    if (ctype_digit($currentChar)) {
        $regex .= '\d*';
    } elseif (ctype_upper($currentChar)) {
        $regex .= '[A-Z]*';
    } elseif (ctype_lower($currentChar)) {
        $regex .= '[a-z]*';
    } else {
        $regex .= '\\' . $currentChar;
    }
}
$regex .= !ctype_alpha($key[$keyLength - 1]) && !ctype_digit($key[$keyLength - 1]) ? '\\' . $key[$keyLength - 1] : $key[$keyLength - 1];

$pattern = '/' . $regex . '(.{2,6})' . $regex . '/';
preg_match_all($pattern, $text, $matches);

$result = implode('', $matches[1]);
echo $result;