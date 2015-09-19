<?php

class Localization {
    const LANG_EN = 'en';
    const LANG_BG = 'bg';
    const LANG_DEFAULT = self::LANG_EN;

    public static $string = [
        "greeting_header_hello" => [
            self::LANG_EN => "Hello",
            self::LANG_BG => "Здравейте"
        ],
        "informal_hello" => [
            self::LANG_EN => "Hi",
            self::LANG_BG => "Здрасти"
        ],
        "welcome_message" => [
            self::LANG_EN => "Welcome to our site",
            self::LANG_BG => "Добре дошли в нашия сайт"
        ]
    ];
}