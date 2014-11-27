<?php

$todayDate = getdate();
$newYearDate = mktime(0, 0, 0, 1, 1, $todayDate['year'] + 1);
$diff = $newYearDate - $todayDate[0];

if(date("I", $todayDate[0]) > 0) {
    $diff -= 3600;
}

$daysUntilNewYear = round($diff / 86400);
$hoursUntilNewYear = number_format(round($diff / 3600), 0, '', ' ');
$minutesUntilNewYear = number_format(round($diff / 60), 0, '', ' ');
$secondsUntilNewYear = number_format($diff, 0, '', ' ');
$totalTime = date("H:i:s", $todayDate[0]);

echo sprintf('Hours until new year: %s', $hoursUntilNewYear) . PHP_EOL;
echo sprintf('Minutes until new year: %s', $minutesUntilNewYear) . PHP_EOL;
echo sprintf('Seconds until new year: %s', $secondsUntilNewYear) . PHP_EOL;
echo sprintf('Days:Hours:Minutes:Seconds %d:%s', $daysUntilNewYear, $totalTime) . PHP_EOL;