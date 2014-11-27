<?php

$firstNumber;
$secondNumber;

function printSum($firstNumber, $secondNumber) {
    echo sprintf('$firstNumber + $secondNumber = %d + %d = %0.2f', $firstNumber, $secondNumber, $firstNumber + $secondNumber) . PHP_EOL;
}

$firstNumber = 2;
$secondNumber = 5;
printSum($firstNumber, $secondNumber);

$firstNumber = 1.567808;
$secondNumber = 0.356;
printSum($firstNumber, $secondNumber);

$firstNumber = 1234.5678;
$secondNumber = 333;
printSum($firstNumber, $secondNumber);