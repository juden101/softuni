<?php

date_default_timezone_set('Europe/Sofia');

$text = $_GET['text'];
$articles = explode(PHP_EOL, $text);

foreach($articles as $article) {
    preg_match('/^([\w\s-]+?)%([\w\s\.-]+?);([\s]*\d{1,2}-\d{1,2}-\d{4}[\s]*)-(.+)$/', $article, $matches);

    if(isset($matches[0]) && strlen($matches[0]) > 0) {
        $article = [
            'name' => trim($matches[1]),
            'author' => trim($matches[2]),
            'date' => trim($matches[3]),
            'contain' => trim($matches[4]),
        ];

        $article['date'] = date('F', strtotime($article['date']));
        strlen($article['contain']) > 100 ? $article['contain'] = substr($article['contain'], 0, 100) . '...' : $article['contain'] .= '...';

        echo '<div>' . PHP_EOL;
        echo '<b>Topic:</b> <span>' . htmlspecialchars($article['name']) . '</span>' . PHP_EOL;
        echo '<b>Author:</b> <span>' . htmlspecialchars($article['author']) . '</span>' . PHP_EOL;
        echo '<b>When:</b> <span>' . htmlspecialchars($article['date']) . '</span>' . PHP_EOL;
        echo '<b>Summary:</b> <span>' . htmlspecialchars($article['contain']) . '</span>' . PHP_EOL;
        echo '</div>' . PHP_EOL;
    }
}