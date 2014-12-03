<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Word Mapping</title>
    <link rel="stylesheet" type="text/css" href="table-style.css" />
</head>
<body>
    <?php

    $words = [];

    if(isset($_POST['words']) && $_POST['words'] != '') {
        preg_match_all('/\w+/', $_POST['words'], $allWords);

        foreach($allWords[0] as $word) {
            $word = strtolower($word);

            if(isset($words[$word])) {
                $words[$word]++;
            }
            else {
                $words[$word] = 1;
            }
        }
    }
    ?>

    <form method="POST">
        <textarea name="words" rows="5" cols="40"><?= isset($_POST['words']) && $_POST['words'] != '' ? $_POST['words'] : null;?></textarea>
        <input type="submit" value="Count words" />
    </form>

    <?php
    if(isset($words) && count($words) > 0):
    ?>
        <table>
            <?php
            foreach($words as $word => $count):
            ?>
                <tr><td><?= $word;?></td><td><?= $count;?></td></tr>
            <?php
            endforeach;
            ?>
        </table>
    <?php
    endif;
    ?>
</body>
</html>