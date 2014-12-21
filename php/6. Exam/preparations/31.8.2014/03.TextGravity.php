<?php

$text = $_GET['text'];
$lineLength = $_GET['lineLength'];

$textLength = strlen($text);
$rows = intval($textLength / $lineLength) + ($textLength % $lineLength == 0 ? 0 : 1);
$matrix = [];
$currentChar = 0;

for ($row = 0; $row < $rows; $row++) {
    $matrix[] = [];

    for ($col = 0; $col < $lineLength; $col++, $currentChar++) {
        if ($currentChar < strlen($text)) {
            $matrix[$row][$col] = $text[$currentChar];
        } else {
            $matrix[$row][$col] = ' ';
        }
    }
}

for($i = count($matrix) - 1; $i > 0; $i--) {
    for($row = 0; $row < $rows - 1; $row++) {
        for($col = 0; $col < count($matrix[$row]); $col++) {
            if($matrix[$row + 1][$col] == ' ') {
                $matrix[$row + 1][$col] = $matrix[$row][$col];
                $matrix[$row][$col] = ' ';
            }
        }
    }
}

echo '<table>';
for($row = 0; $row < $rows; $row++) {
    echo '<tr>';
    for($col = 0; $col < count($matrix[$row]); $col++) {
        echo '<td>' . htmlspecialchars($matrix[$row][$col]) . '</td>';
    }
    echo '</tr>';
}
echo '<table>';