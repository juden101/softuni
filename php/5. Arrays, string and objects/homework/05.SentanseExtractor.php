<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Extract sentences</title>
    <style>
        input {
            display: block;
            margin-bottom: 5px;
        }
    </style>
</head>
<body>
<form method="POST">
    <input type="text" name="word" value="<?= isset($_POST['word']) && $_POST['word'] != '' ? $_POST['word'] : null;?>" placeholder="Word" />
    <textarea name="text" rows="5" cols="40" placeholder="Text..."><?= isset($_POST['text']) && $_POST['text'] != '' ? $_POST['text'] : null;?></textarea>
    <input type="submit" value="Extract sentences" />
</form>

<?php
if(isset($_POST['word'], $_POST['text']) && $_POST['word'] != '' && $_POST['text'] != '') {
    $neededSentences = [];
    $neededWord = $_POST['word'];
    preg_match_all('/.+?[\.\!\?]+/', $_POST['text'], $allSentences);

    foreach($allSentences[0] as $sentence) {
        if(substr_count($sentence, $neededWord) > 1) {
            $neededSentences[] = trim($sentence);
        }
    }

    $result = '';
    if(count($neededSentences) == 0) {
        $result = 'No results!';
    }
    else {
        foreach($neededSentences as $sentence) {
            $result .=  $sentence . ' ';
        }
    }
?>
    <textarea name="text" rows="5" cols="40" disabled><?= $result;?></textarea>
<?php
}
?>
</body>
</html>