<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Coloring texts</title>
    <link rel="stylesheet" type="text/css" href="coloring-texts.css" />
</head>
<body>
<?php

$coloredChars = [];

if(isset($_POST['text']) && $_POST['text'] != '') {
    preg_match_all('/\S+?/', $_POST['text'], $allChars);

    foreach($allChars[0] as $char) {
        $color = 'blue';

        if(ord($char) % 2 == 0) {
            $color = 'red';
        }

        $coloredChars[] = ['char' => $char, 'color' => $color];
    }
}
?>

<form method="POST">
    <textarea name="text" rows="5" cols="40"><?= isset($_POST['text']) && $_POST['text'] != '' ? $_POST['text'] : null;?></textarea>
    <input type="submit" value="Color text" />
</form>

<?php
if(isset($coloredChars) && count($coloredChars) > 0):
    ?>
    <p>
        <?php
        foreach($coloredChars as $charProperties):
        ?>
            <span class="<?= $charProperties['color'];?>"><?= $charProperties['char'];?></span>
        <?php
        endforeach;
        ?>
    </p>
<?php
endif;
?>
</body>
</html>