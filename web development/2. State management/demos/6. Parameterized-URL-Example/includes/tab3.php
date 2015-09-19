<h1>Tab #3</h1>

<p>Tab #3 - RSS feed</p>

<?php

$xml=("https://softuni.bg/feed/forumposts");
$xmlDoc = new DOMDocument();
$xmlDoc->load($xml);

// Get elements from "<channel>"
$channel=$xmlDoc->getElementsByTagName('channel')->item(0);
$channel_title = $channel->getElementsByTagName('title')->item(0)->childNodes->item(0)->nodeValue;
$channel_link = $channel->getElementsByTagName('link')->item(0)->childNodes->item(0)->nodeValue;
$channel_desc = $channel->getElementsByTagName('description')->item(0)->childNodes->item(0)->nodeValue;

// Output elements from "<channel>"
echo "<p><a href='" . htmlspecialchars($channel_link) . "'>" . htmlspecialchars($channel_title) . "</a>";
echo "<br />";
echo htmlspecialchars($channel_desc) . "</p>";

// Get and output "<item>" elements
echo "<ul>";
$items = $xmlDoc->getElementsByTagName('item');
for ($i = 0; $i < $items->length; $i++) {
    $item_title = $items->item($i)->getElementsByTagName('title')->item(0)->childNodes->item(0)->nodeValue;
    $item_link = $items->item($i)->getElementsByTagName('link')->item(0)->childNodes->item(0)->nodeValue;
    echo "<li><a href='" . htmlspecialchars($item_link) . "'>" . htmlspecialchars($item_title) . "</a></li>";
}
echo "</ul>";
?>
