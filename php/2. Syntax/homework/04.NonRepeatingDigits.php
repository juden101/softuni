<?php

function findDigits($n) {
    $digits = [];

    for($a = 1; $a <= 9; $a++) {
        for($b = 0; $b <= 9; $b++) {
            for($c = 0; $c <= 9; $c++) {
                if($a != $b && $b != $c && $c != $a) {
                    $currentNumber = $a . $b . $c;

                    if((int)$currentNumber <= $n) {
                        $digits[] = $currentNumber;
                        $isFound = true;
                    }
                }
            }
        }
    }

    return $digits;
}

function printFoundDigits($digits) {
    $digitsCount = count($digits);

    if($digitsCount == 0) {
        echo 'no';
    }
    else {
        for($i = 0; $i < $digitsCount; $i++) {
            echo $digits[$i];

            if($i < $digitsCount - 1) {
                echo ', ';
            }
        }
    }

    echo PHP_EOL;
}

$foundDigits = findDigits(1234);
printFoundDigits($foundDigits);

$foundDigits = findDigits(145);
printFoundDigits($foundDigits);

$foundDigits = findDigits(15);
printFoundDigits($foundDigits);

$foundDigits = findDigits(247);
printFoundDigits($foundDigits);