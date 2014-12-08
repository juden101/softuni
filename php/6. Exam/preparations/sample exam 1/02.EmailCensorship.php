<?php

$text = $_GET['text'];
$blacklist = $_GET['blacklist'];
$blacklistItems = preg_split('/[*\s]+/', $blacklist, -1, PREG_SPLIT_NO_EMPTY);

$replacedText = preg_replace_callback('/[a-zA-Z0-9\+\_\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-\.]+/', 'replaceEmails', $text, -1);
echo "<p>{$replacedText}</p>";

function replaceEmails($input) {
    $email = $input[0];

    if(isBlacklisted($email)) {
        $result = str_repeat('*', strlen($email));
    }
    else {
        $result = "<a href=\"mailto:{$email}\">{$email}</a>";
    }

    return $result;
}

function isBlacklisted($email) {
    global $blacklistItems;
    foreach($blacklistItems as $blacklistItem) {
        if($blacklistItem == $email) {
            return true;
        }
        else if(endsWith($email, $blacklistItem)) {
            return true;
        }
    }

    return false;
}

function endsWith($haystack, $needle) {
    $length = strlen($needle);
    if($length == 0) {
        return true;
    }

    return (substr($haystack, -$length) === $needle);
}