<?php

$_GET['mainWord'] = '{"row4": "operator"}';
$_GET['words'] = '["generally","objects","system","like","need"]';

$input1 = $_GET['mainWord'];
$input2 = $_GET['words'];
$word1 = (array)json_decode($input1);
$words = json_decode($input2);

$rowMainWord = getRow(key($word1));
$mainWord = $word1[key($word1)];
$sizeTable = strlen($mainWord);

//create board consists only horizontal word.
$board = [];
$row = array_fill(0, strlen($mainWord), '');

for ($col = 0; $col < strlen($mainWord); $col++) {
    if ($rowMainWord == $col) {
        $board[] = str_split($mainWord);
    } else {
        $board[] = $row;
    }
}

var_dump($words);

foreach($board as $row) {

}

function getRow($rowStr) {
    preg_match('/\d+/', $rowStr, $matches);
    return $matches[0] - 1;
}