<?php

$texts = explode(PHP_EOL, $_GET['text']);
$artist = $_GET['artist'];
$property = $_GET['property'];
$order = $_GET['order'];

$songs = [];

foreach($texts as $text) {
    $splitText = explode('|', $text);

    $song = [
        'name' => trim($splitText[0]),
        'genre' => trim($splitText[1]),
        'artists' => explode(', ', trim($splitText[2])),
        'downloads' => intval(trim($splitText[3])),
        'rating' => floatval(trim($splitText[4])),
    ];

    sort($song['artists']);

    if(in_array($artist, $song['artists'])) {
        $songs[] = $song;
    }
}

usort($songs, function($a, $b) use ($order, $property) {
    if ($a[$property] == $b[$property]) {
        return strcmp($a['name'], $b['name']);
    }

    return ($order == 'ascending' ^ $a[$property] < $b[$property]) ? 1 : -1;
});

echo '<table>' . PHP_EOL;
echo '<tr><th>Name</th><th>Genre</th><th>Artists</th><th>Downloads</th><th>Rating</th></tr>' . PHP_EOL;
foreach($songs as $song) {
    echo '<tr><td>' . htmlspecialchars($song['name']) . '</td><td>' . htmlspecialchars($song['genre']) . '</td><td>' . htmlspecialchars(implode(', ', $song['artists'])) . '</td><td>' . htmlspecialchars($song['downloads']) . '</td><td>' . htmlspecialchars($song['rating']) . '</td></tr>' . PHP_EOL;
}
echo '</table>' . PHP_EOL;