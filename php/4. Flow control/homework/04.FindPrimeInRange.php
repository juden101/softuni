<?php

function isPrime($n) {
    if($n < 2) {
        return false;
    }

    if($n == 2) {
        return true;
    }

    $i = 2;
    while($i <= $n/2) {
        if($n % $i == 0) {
            return false;
        }

        $i++;
    }

    return true;
}

?>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Find Primes in Range</title>
    <link rel="stylesheet" type="text/css" href="numbers.css" />
</head>
<body>
    <?php
    $startIndex = '';
    $endIndex = '';
    $numbers = [];

    if(isset($_POST['startIndex'], $_POST['endIndex']) && $_POST['startIndex'] != '' && $_POST['endIndex'] != '') {
        $startIndex = $_POST['startIndex'];
        $endIndex = $_POST['endIndex'];

        for($i = $startIndex; $i <= $endIndex; $i++) {
            $numbers[] = [
                'number' => $i,
                'isPrime' => isPrime($i)
            ];
        }
    }
    ?>

    <form method="POST">
        <label for="startIndex">Starting Index:</label>
        <input type="text" name="startIndex" id="startIndex" value="<?= $startIndex;?>" />
        <label for="endIndex">End:</label>
        <input type="text" name="endIndex" id="endIndex" value="<?= $endIndex;?>" />
        <input type="submit" value="Submit" />
    </form>

    <section>
        <?php
        for($i = 0; $i < count($numbers); $i++) {
        ?>
            <span class="number <?= $numbers[$i]['isPrime'] ? 'prime' : null;?>"><?= $numbers[$i]['number'];?></span>
        <?php
        }
        ?>
    </section>
</body>
</html>