<?php

date_default_timezone_set('UTC');

$startDate = strtotime($_GET['dateOne']);
$endInputDate = strtotime($_GET['dateTwo']);

preg_match_all('/[0-9]+\-[0-9]+\-[0-9]+/', $_GET['holidays'], $holidaysInput);
$holidays = [];
$result = [];

foreach($holidaysInput[0] as $holidayDate) {
    $holidays[] = strtotime($holidayDate);
}

if($startDate < $endInputDate) {
    for($currentDate = $startDate; $currentDate <= $endInputDate; $currentDate += 86400) {
        $dayOfWeek = date('w', $currentDate);
        if($dayOfWeek == 0 || $dayOfWeek == 6) {
            continue;
        }

        if(in_array($currentDate, $holidays)) {
            continue;
        }

        $result[] = $currentDate;
    }
}

if(count($result) > 0) {
    echo '<ol>';
    foreach($result as $resultsDate) {
        echo '<li>' . date('d-m-Y', $resultsDate) . '</li>';
    }
    echo '</ol>';
}
else {
    echo '<h2>No workdays</h2>';
}