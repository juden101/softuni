<?php

date_default_timezone_set('UTC');

$numbersString = $_GET['numbersString'];
$dateString = $_GET['dateString'];

$numbersPattern = '/[\D]{1}([\d]+)[\D]{1}/';
preg_match_all($numbersPattern, $numbersString, $numbersMatches);

$sum = 0;
foreach($numbersMatches[0] as $key => $match) {
    $str = $match;
    if(!ctype_alpha($str[0]) && !ctype_alpha($str[strlen($str) - 1])) {
        $number = substr($str, 1, strlen($str) - 2);
        $sum += $number;
    }
}
$backwardsSum = strrev($sum);

$datesPattern = '/(19|20)\d\d[\-\/.](0[1-9]|1[012])[\-\/.](0[1-9]|[12][0-9]|3[01])/';
preg_match_all($datesPattern, $dateString, $datesMatches);
if(count($datesMatches[0]) > 0) {
    echo '<ul>';
    for($i = 0; $i < count($datesMatches[0]); $i++) {
        $date = $datesMatches[0][$i];
        $splitDate = explode('-', $date);
        $year = $splitDate[0];
        $month = $splitDate[1];
        $day = $splitDate[2];

        $dateFormat = 'Y-m-d';

        $newDate = DateTime::createFromFormat($dateFormat, $date);
        $newDate->modify('+' . $backwardsSum .' days');
        echo '<li>' . $newDate->format($dateFormat) . '</li>';
    }
    echo '</ul>';
}
else {
    echo '<p>No dates</p>';
}