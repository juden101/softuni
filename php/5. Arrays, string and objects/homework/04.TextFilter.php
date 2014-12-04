<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Text Filter</title>
    <style>
        input {
            display: block;
            margin-bottom: 5px;
        }
    </style>
</head>
<body>
    <form method="POST">
        <input type="text" name="banlist" value="<?= isset($_POST['banlist']) && $_POST['banlist'] != '' ? $_POST['banlist'] : null;?>" placeholder="Ban list" />
        <textarea name="text" rows="5" cols="40" placeholder="Text..."><?= isset($_POST['text']) && $_POST['text'] != '' ? $_POST['text'] : null;?></textarea>
        <input type="submit" value="Filter text" />
    </form>

    <?php
    if(isset($_POST['banlist'], $_POST['text']) && $_POST['banlist'] != '' && $_POST['text'] != '') {
        preg_match_all('/\w+/', $_POST['banlist'], $banlist);
        $text = $_POST['text'];

        $banlistReplacment = [];
        foreach($banlist[0] as $word) {
            $banlistReplacment[] = str_repeat('*', strlen($word));
        }

        $output  = str_replace($banlist[0], $banlistReplacment, $text);
    ?>
        <textarea name="text" rows="5" cols="40" disabled><?= $output;?></textarea>
    <?php
    }
    ?>
</body>
</html>