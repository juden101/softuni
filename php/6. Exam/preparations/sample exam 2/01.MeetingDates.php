<?php

date_default_timezone_set('UTC');

$startInputDate = strtotime($_GET['dateOne']);
$endInputDate = strtotime($_GET['dateTwo']);

$thursdays = [];

if($startInputDate > $endInputDate) {
    $temp = $startInputDate;
    $startInputDate = $endInputDate;
    $endInputDate = $temp;
}

for($currentDate = $startInputDate; $currentDate <= $endInputDate; $currentDate += 86400) {
    if(date('w', $currentDate) == 4) {
        $thursdays[] = $currentDate;
    }
}

if(count($thursdays) > 0) {
    echo '<ol>';
    foreach($thursdays as $thursdays) {
        echo '<li>' . date('d-m-Y', $thursdays) . '</li>';
    }
    echo '</ol>';
}
else {
    echo '<h2>No Thursdays</h2>';
}