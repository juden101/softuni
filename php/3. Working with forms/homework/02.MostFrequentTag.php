<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Most frequent tag</title>
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
        $tags = [];

        foreach ($allTags as $tagName) {
            $tagName = trim($tagName);

            if (isset($tags[$tagName])) {
                $tags[$tagName]++;
            } else {
                $tags[$tagName] = 1;
            }
        }

        arsort($tags);

        foreach($tags as $tagKey => $tagName) {
            echo $tagKey . ' : ' . $tagName . ' times<br />';
        }

        echo '<br />Most Frequent Tag is: ' . array_keys($tags)[0];
    }
    ?>
</body>
</html>