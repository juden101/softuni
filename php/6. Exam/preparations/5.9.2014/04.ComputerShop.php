<?php

$minPrice = $_GET['minPrice'];
$maxPrice = $_GET['maxPrice'];
$filter = $_GET['filter'];
$order = $_GET['order'];
$list = $_GET['list'];

$products = [];
$matches = preg_split("/\r?\n/", $list, -1, PREG_SPLIT_NO_EMPTY);

for($i = 0; $i < count($matches); $i++) {
    $properties = preg_split("/\|/", $matches[$i]);

    $product = [
        'id' => $i + 1,
        'name' => htmlspecialchars(trim($properties[0])),
        'type' => htmlspecialchars(trim($properties[1])),
        'components' => trim($properties[2]),
        'price' => trim($properties[3])
    ];

    $components = [];
    $comp_props = preg_split("/,/", $product['components']);
    foreach($comp_props as $component) {
        $components[] = '<li class="component">' . htmlspecialchars(trim($component)) . '</li>';
    }
    $product['components'] = $components;

    if($product['price'] >= $minPrice && $product['price'] <= $maxPrice) {
        if($filter == 'all' || $filter == $product['type']) {
            $products[] = $product;
        }
    }
}

usort($products, function($a, $b) {
    if($a['price'] == $b['price']) {
        return $a['id'] - $b['id'];
    }

    return $a['price'] - $b['price'];
});

if($order == 'descending') {
    $products = array_reverse($products);
}

foreach($products as $product) {
    $price = number_format($product['price'], 2, '.', '');

    $output = '<div class="product" id="product' . $product['id'] . '">';
        $output .= "<h2>{$product['name']}</h2>";
        $output .= '<ul>';
            $output .= implode('', $product['components']);
        $output .= '</ul>';
        $output .= "<span class=\"price\">{$price}</span>";
    $output .= '</div>';

    echo $output;
}