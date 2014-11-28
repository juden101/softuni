<?php
session_start();
?>
<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>HTML Tags Counter</title>
</head>
<body>
    <?php
        $isCurrentTagValid;
        $currentScore = 0;

        if(isset($_POST['tag']) && $_POST['tag'] != null) {
            $currentTag = $_POST['tag'];

            $validTags = array("a", "abbr", "address", "area", "article", "aside", "audio", "b", "base", "bdi", "bdo", "blockquote", "body", "br", "button", "canvas", "caption",
                "cite", "code", "col", "colgroup", "command", "datalist", "dd", "del", "details", "dfn", "div", "dl", "dt", "em", "embed", "fieldset", "figcaption", "figure",
                "footer", "form", "h1", "h2", "h3", "h4", "h5", "h6", "head", "header", "hgroup", "hr", "html", "i", "iframe", "img", "input", "ins", "kbd", "keygen", "label",
                "legend", "li", "link", "map", "mark", "menu", "meta", "meter", "nav", "noscript", "object", "ol", "optgroup", "option", "output", "p", "param", "pre", "progress",
                "q", "rp", "rt", "ruby", "s", "samp", "script", "section", "select", "small", "source", "span", "strong", "style", "sub", "summary", "sup", "table", "tbody", "td",
                "textarea", "tfoot", "th", "thead", "time", "title", "tr", "track", "u", "ul", "var", "video", "wbr");

            if(in_array($currentTag, $validTags)) {
                $currentTagValid = true;
                $currentScore++;
            }
            else {
                $currentTagValid = false;
            }
        }

        if(!isset($_SESSION["score"]) || $_SESSION["score"] == null) {
            $_SESSION["score"] = 0;
        }

        $_SESSION["score"] += $currentScore;
    ?>
    <form method="POST">
        <section>
            <p>Enter HTML tags:</p>
        </section>
        <section>
            <input type="text" name="tag" />
            <input type="submit" value="Submit" />
        </section>
        <section>
            <p><?= isset($currentTagValid) ? $currentTagValid == true && $currentTagValid != null ? 'Valid HTML tag!' : 'Invalid HTML tag!' : null;?></p>
            <p>Score: <?= isset($_SESSION["score"]) && $_SESSION["score"] != null ? $_SESSION["score"] : 0;?></p>
        </section>
    </form>
</body>
</html>