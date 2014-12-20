<?php

$priceList = $_GET['priceList'];
$products = [];

preg_match_all('/<tr>(.+?)<\/tr>/s', $priceList, $rows);
$rows = $rows[1];

for($i = 1; $i < count($rows); $i++) {
    preg_match_all('/<td>(.+?)<\/td>/s', $rows[$i], $properties);

    $properties = $properties[1];
    $product = html_entity_decode(trim($properties[0]));
    $component = html_entity_decode(trim($properties[1]));
    $price = html_entity_decode(trim($properties[2]));
    $currency = html_entity_decode(trim($properties[3]));

    if(!isset($products[$component])) {
        $products[$component] = [];
    }

    $products[$component][] = [
        'product' => $product,
        'price' => $price,
        'currency' => $currency,
    ];
}

ksort($products);

foreach($products as $key => $product) {
    usort($products[$key], function($a, $b) {
        return strcmp($a['product'], $b['product']);
    });
}

echo json_encode($products);