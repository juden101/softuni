<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Print tags</title>
</head>
<body>
    <p>Enter tags:</p>

    <form method="POST">
        <input type="text" name="tags" />
        <input type="submit" value="Submit" />
    </form>

    <?php

    if(isset($_POST['tags']) && $_POST['tags'] != null) {
        $allTags = explode(',', $_POST['tags']);

        foreach($allTags as $tagKey => $tagName) {
            echo $tagKey . ' : ' . $tagName . '<br />';
        }
    }
    ?>
</body>
</html>