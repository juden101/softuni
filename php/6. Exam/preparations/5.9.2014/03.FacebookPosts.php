<?php

date_default_timezone_set('Europe/Sofia');
$text = $_GET['text'];
$matches = preg_split("/\r?\n/", $text, -1, PREG_SPLIT_NO_EMPTY);

$posts = [];
foreach($matches as $text) {
    if($text == null) {
        continue;
    }

    $properties = explode(';', $text);

    $post = [
        'author' => trim($properties[0]),
        'timestamp' => strtotime(trim($properties[1])),
        'date' => trim($properties[1]),
        'post' => trim($properties[2]),
        'likes' => trim($properties[3]),
        'comments' => trim($properties[4])
    ];

    $comments = '';
    $splitComments = explode('/', $post['comments']);
    if(isset($post['comments']) && $post['comments'] != null) {
        foreach($splitComments as $comment) {
            $comments .= '<p>' . htmlspecialchars(trim($comment)) . '</p>';
        }
    }
    $post['comments'] = $comments;

    $posts[] = $post;
}

usort($posts, function($a, $b) {
    return $b['timestamp'] - $a['timestamp'];
});

foreach($posts as $post) {
    echo '<article>';
        echo '<header>';
            echo '<span>' . htmlspecialchars($post['author']) . '</span>';
            echo '<time>' . date('j F Y', strtotime($post['date'])) . '</time>';
        echo '</header>';
        echo '<main>';
            echo '<p>' . htmlspecialchars($post['post']) . '</p>';
        echo '</main>';
        echo '<footer>';
            echo '<div class="likes">' . htmlspecialchars($post['likes']) . ' people like this</div>';
            if($post['comments'] != null) {
                echo '<div class="comments">';
                    echo $post['comments'];
                echo '</div>';
            }
        echo '</footer>';
    echo '</article>';
}