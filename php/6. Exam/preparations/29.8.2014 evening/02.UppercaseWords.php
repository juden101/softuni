<?php

$text = htmlspecialchars($_GET['text']);
$splitText = str_split($text);
$currentWord = '';

echo '<p>';
foreach($splitText as $char) {
    if(ctype_alpha($char)) {
        $currentWord .= $char;
    }
    else {
        $currentWord = uppercaseCheck($currentWord);
        echo $char;
    }
}
echo uppercaseCheck($currentWord) . '</p>';

function uppercaseCheck($currentWord) {
    if(strtoupper($currentWord) == $currentWord) {
        if($currentWord == strrev($currentWord)) {
            for($i = 0, $temp = ''; $i < strlen($currentWord); $i++) {
                $temp .= $currentWord[$i] . $currentWord[$i];
            }
            $currentWord = $temp;
        }
        else {
            $currentWord = strrev($currentWord);
        }
    }

    echo $currentWord;
    return $currentWord = '';
}