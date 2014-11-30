<!DOCTYPE html>
<html>

<head lang="en">
    <meta charset="UTF-8">
    <title>Variable Scope</title>
</head>

<body>
<?php
$a = 1;
$b = 2;

function sum() {
    //try to comment
    global $a, $b;

    $b = $a + $b;
}

sum();
echo $b;
?>
</body>

</html>
