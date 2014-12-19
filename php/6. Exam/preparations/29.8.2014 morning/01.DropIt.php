<?php

$text = $_GET['text'];
$minFontSize = $_GET['minFontSize'];
$step = $_GET['step'];
$maxFontSize = $_GET['maxFontSize'];

$currentSize = $minFontSize;
$increasing = true;

$text = str_split($text);
foreach($text as $character) {
    $tag = '<span style=\'font-size:' . $currentSize . ';';
    $isCharEven = ord($character) % 2 == 0;
    $isLetter = ctype_alpha($character);

    if($isCharEven) {
        $tag .= 'text-decoration:line-through;';
    }
    $tag .= '\'>' . htmlspecialchars($character) . '</span>';
    echo $tag;

    if(!$isLetter) {
        continue;
    }

    if($increasing) {
        $currentSize += $step;

        if($currentSize >= $maxFontSize) {
            $increasing = false;
        }
    }
    else {
        $currentSize -= $step;

        if($currentSize <= $minFontSize) {
            $increasing = true;
        }
    }
}