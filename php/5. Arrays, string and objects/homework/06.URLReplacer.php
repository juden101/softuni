<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>URL Replacer</title>
    <style>
        input {
            display: block;
            margin-bottom: 5px;
        }
    </style>
</head>
<body>
<form method="POST">
    <textarea name="text" rows="5" cols="40" placeholder="Text..."><?= isset($_POST['text']) && $_POST['text'] != '' ? $_POST['text'] : null;?></textarea>
    <input type="submit" value="Replace URLs" />
</form>

<?php
if(isset($_POST['text']) && $_POST['text'] != '') {
    $text = $_POST['text'];

    $text = preg_replace('/<a href="(.+?)">/', '[URL=$1]', $text);
    $text = preg_replace('/<\/a>/', '[/URL]', $text);
?>
    <textarea name="text" rows="5" cols="40" disabled><?= $text;?></textarea>
<?php
}
?>
</body>
</html>