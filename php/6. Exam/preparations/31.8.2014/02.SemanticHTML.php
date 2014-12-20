<?php

$html = $_GET['html'];
$semanticTags = ['main', 'header', 'nav', 'article', 'section', 'aside', 'footer'];

$open_tags_pattern = '/<div.*?(id|class)\s*=\s*"(.*?)".*?>/';
preg_match_all($open_tags_pattern, $html, $opening_tags);

foreach($opening_tags[0] as $key => $value) {
    $attr_name = $opening_tags[1][$key];
    $attr_value = $opening_tags[2][$key];

    if(in_array($attr_value, $semanticTags)) {
        $new_tag = $value;
        $new_tag = str_replace('div', $attr_value, $new_tag);
        $new_tag = preg_replace('/\s{2,}/', ' ', $new_tag);
        $new_tag = str_replace($attr_name . '="' . $attr_value . '"', '', $new_tag);
        $new_tag = str_replace($attr_name . ' ="' . $attr_value . '"', '', $new_tag);
        $new_tag = str_replace($attr_name . '= "' . $attr_value . '"', '', $new_tag);
        $new_tag = str_replace($attr_name . ' = "' . $attr_value . '"', '', $new_tag);
        $new_tag = preg_replace('/\s{2,}/', ' ', $new_tag);
        $new_tag = preg_replace('/\s*>/', '>', $new_tag);
    }

    $html = str_replace($value, $new_tag, $html);
}

$close_tags_pattern = '/<\/div.*?([\w]+?)\s*-->/';
preg_match_all($close_tags_pattern, $html, $closing_tags);

foreach($closing_tags[0] as $key => $value) {
    $attr_name = $closing_tags[1][$key];

    if(in_array($attr_name, $semanticTags)) {
        $new_tag = $value;
        $new_tag = str_replace($value, '</' . $attr_name . '>', $new_tag);
    }

    $html = str_replace($value, $new_tag, $html);
}

echo $html;