<?php

function getSundays($year, $month) {
    return new DatePeriod(
        new DateTime("first sunday of $year-$month"),
        DateInterval::createFromDateString('next sunday'),
        new DateTime("last day of $year-$month")
    );
}

$currentMonth = date('m');
$currentYear = date('Y');

foreach (getSundays($currentYear, $currentMonth) as $sunday) {
    echo $sunday->format("jS F, Y\n");
}