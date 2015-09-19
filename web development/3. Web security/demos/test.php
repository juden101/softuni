<?php

$password = 'pass123';
$hash1 = hash("sha256", $password);
$hash2 = hash("sha256", $password);

?>

<h1><?php echo $hash1 ?></h1>
<h1><?php echo $hash2 ?></h1>
<h1><?php echo $verify1 ?></h1>
<h1><?php echo $verify1 ?></h1>