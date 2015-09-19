<?php

require_once('localization.php');
require_once('database.php');

$db = Database::getInstance()->getConnection();
$res = $db->query("SHOW COLUMNS FROM translations");
$columns = $res->fetchAll(PDO::FETCH_ASSOC);

$possibleLanguages = [];

foreach ($columns as $row) {
    $strpos = strpos($row['Field'], 'text_');

    if ($strpos !== false) {
        $possibleLanguages[] = str_replace('text_', '', $row['Field']);
    }
}

if (isset($_GET['lang'])) {
    $lang = $_GET['lang'];

    if (!in_array($lang, $possibleLanguages)) {
        throw new Exception("Wrong language!");
    }

    setcookie('lang', $lang);
    $_COOKIE['lang'] = $lang;
}

function __($tag) {
    $lang = isset($_COOKIE['lang']) ? $_COOKIE['lang'] : Localization::LANG_DEFAULT;

    $db = Database::getInstance()->getConnection();
    $query = $db->query("SELECT text_{$lang} FROM translations WHERE tag = '$tag'");

    $row = $query->fetch(PDO::FETCH_NUM);

    return $row[0];
}