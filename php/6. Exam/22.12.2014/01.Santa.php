<?php

$childName = $_GET['childName'];
$wantedPresent = $_GET['wantedPresent'];
$riddles = preg_split("/;/", $_GET['riddles']);

$childName = str_replace(' ', '-', $childName);

$riddle = -1;
$riddlesCount = count($riddles);

for($i = 0; $i < strlen($childName); $i++) {
    $riddle++;

    if($riddle >= $riddlesCount) {
        $riddle = 0;
    }
}

$childName = htmlspecialchars($childName);
$wantedPresent = htmlspecialchars($wantedPresent);
$currentRiddle = htmlspecialchars($riddles[$riddle]);

echo "\$giftOf{$childName} = \$[wasChildGood] ? '{$wantedPresent}' : '{$currentRiddle}';";