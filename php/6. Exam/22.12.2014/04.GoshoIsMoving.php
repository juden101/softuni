<?php

$luggageText = $_GET['luggage'];
$typeLuggage = $_GET['typeLuggage'];
$luggageRoom = $_GET['room'];
$minWeight = $_GET['minWeight'];
$maxWeight = $_GET['maxWeight'];

if(empty($typeLuggage) || strlen($luggageRoom) == 0 || strlen($minWeight) == 0 || strlen($maxWeight) == 0) {
    echo '<ul></ul>';
    exit;
}

$luggage = [];
$splitLuggage = preg_split("/C\|\_\|/", $luggageText, -1, PREG_SPLIT_NO_EMPTY);

foreach($splitLuggage as $lug) {
    $properties = preg_split("/;/", $lug, -1, PREG_SPLIT_NO_EMPTY);

    $luggageType = trim($properties[0]);
    $room = trim($properties[1]);
    $name = trim($properties[2]);
    $weight = trim($properties[3]);
    $weight = str_replace('kg', '', $weight);

    if(!isset($luggage[$luggageType])) {
        $luggage[$luggageType] = [];
    }

    if(!isset($luggage[$luggageType][$room])) {
        $luggage[$luggageType][$room] = [];
    }

    if(!isset($luggage[$luggageType][$room][$name])) {
        $luggage[$luggageType][$room][$name] = 0;
    }

    $luggage[$luggageType][$room][$name] += (int)$weight;
}

ksort($luggage);

$output = [];

foreach($luggage as $name => $rooms) {
    if(in_array($name, $typeLuggage)) {
        foreach($rooms as $room => $stuff) {
            if($luggageRoom == $room) {
                ksort($stuff);

                $stuffs = '';
                $kilograms = 0;
                foreach($stuff as $key => $value) {
                    $stuffs .= $key . ', ';
                    $kilograms += $value;
                }
                $stuffs = substr($stuffs, 0, strlen($stuffs) - 2);


                if($kilograms >= $minWeight && $kilograms <= $maxWeight) {
                    if(!isset($output[$name])) {
                        $output[$name] = [];
                    }

                    $output[$name][$room] = $stuffs . ' - ' . $kilograms . 'kg';
                }
            }
        }
    }
}

echo '<ul>';
foreach($output as $type => $roomsValue) {
    echo '<li>';
    echo '<p>' . $type . '</p>';
        echo '<ul>';
        foreach($roomsValue as $room => $value) {
            echo '<li>';
                echo '<p>' . $room . '</p>';
                echo '<ul><li><p>' . $value . '</p></li></ul>';
            echo '</li>';
        }
        echo '</ul>';
    echo '</li>';
}
echo '</ul>';