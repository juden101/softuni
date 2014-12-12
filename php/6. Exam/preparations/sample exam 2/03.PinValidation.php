<?php

if (isset($_GET['name']) && isset($_GET['gender']) && isset($_GET['pin'])) {
    $isValidData = true;
    $gender = $_GET['gender'];
    $genderValue = $gender == 'male' ? 0 : 1;

    $nameString = $_GET['name'];
    $namePattern = '/[A-Z][a-z]+\s[A-Z][a-z]+/';
    preg_match($namePattern, $nameString, $name);

    $pinString = $_GET['pin'];
    $pinPattern = '/[0-9]{10}/';
    preg_match($pinPattern, $pinString, $pin);

    if (empty($name) || empty($pin)) {
        $isValidData = false;
    } else {
        $name = $name[0];
        $pin = $pin[0];
        $isValidData = validatePin($pin,$genderValue);
    }

    if ($isValidData) {
        $output = [
            'name' => $name,
            'gender' => $gender,
            'pin' => $pin
        ];

        echo json_encode($output);
    } else {
        echo '<h2>Incorrect data</h2>';
    }
}

function validatePin($pin, $gender) {
    $year = substr($pin, 0, 2);
    $month = substr($pin, 2, 2);
    $day = substr($pin, 4, 2);

    if ($month > 40) {
        $month -= 40;
        $year = '20' . $year;
    } elseif ($month > 20) {
        $month -= 20;
        $year = '18' . $year;
    } else {
        $year = '19' . $year;
    }

    $stringDate = $day . '-' . $month . '-' . $year;
    $date = date_create($stringDate, timezone_open('Europe/Sofia'));
    if (!$date) {
        return false;
    }

    $monthChk = date_format($date, 'm');
    if ($monthChk != $month) {
        return false;
    }

    $genderChk = substr($pin,8,1);
    if ($genderChk % 2 != $gender) {
        return false;
    }

    $sumChk = substr($pin, 9, 1);
    $weights = [2, 4, 8, 5, 10, 9, 7, 3, 6];
    $sum = 0;
    for ($i = 0; $i < 9; $i++) {
        $sum += substr($pin, $i, 1) * $weights[$i];
    }

    $sum = $sum % 11 % 10;
    if($sum != $sumChk) {
        return false;
    }

    return true;
}