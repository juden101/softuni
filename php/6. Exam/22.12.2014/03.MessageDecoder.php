<?php

$matrix = json_decode($_GET['jsonTable']);
$number = $matrix[0];
$matrix = $matrix[1];

$pingPattern = '/Reply from (.+?): bytes=(.+?) time=(.+?)ms TTL=(.+)/';
$output = [];
$words = [];
$currentWord = '';

foreach($matrix as $row) {
    preg_match($pingPattern, $row, $match);
    if(empty($match)) {
        continue;
    }

    $ip = $match[1];
    $bytes = $match[2];
    $time = $match[3];
    $ttl = $match[4];

    $char = chr($time);

    if($char == '*') {
        $words[] = $currentWord;
        $currentWord = '';
    }
    else {
        $currentWord .= $char;
    }
}
if(strlen($currentWord) > 0) {
    $words[] = $currentWord;
}

$row = 0;
for($i = 0; $i < count($words); $i++) {
    $splitWord = str_split($words[$i]);

    $count = 0;
    foreach($splitWord as $char) {
        if($count >= $number) {
            $count = 0;
            $row++;
        }

        $output[$row][] = $char;

        $count++;
    }

    for($j = 0; $j < $number - $count; $j++) {
        $output[$row][] = '';
    }

    $row++;
}

echo '<table border=\'1\' cellpadding=\'5\'>';
for($row = 0; $row < count($output); $row++) {
    echo '<tr>';
    for($col = 0; $col < count($output[$row]); $col++) {
        $char = trim(htmlspecialchars($output[$row][$col]));
        $style = '';

        if($char != '') {
            $style = ' style=\'background:#CAF\'';
        }

        echo "<td{$style}>{$char}</td>";
    }
    echo '</tr>';
}
echo '</table>';