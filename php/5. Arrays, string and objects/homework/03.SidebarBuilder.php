<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Sidebar Builder</title>
    <link rel="stylesheet" type="text/css" href="sidebar-builder.css" />
</head>
<body>
    <form method="POST">
        <section>
            <label for="categories">Categories:</label>
            <input type="text" name="categories" id="categories" value="<?= isset($_POST['categories']) && $_POST['categories'] != null ? $_POST['categories'] : null;?>" />
        </section>

        <section>
            <label for="tags">Tags:</label>
            <input type="text" name="tags" id="tags" value="<?= isset($_POST['tags']) && $_POST['tags'] != null ? $_POST['tags'] : null;?>" />
        </section>

        <section>
            <label for="months">Months:</label>
            <input type="text" name="months" id="months" value="<?= isset($_POST['months']) && $_POST['months'] != null ? $_POST['months'] : null;?>" />
        </section>

        <input type="submit" value="Generate" />
    </form>

    <?php
        if(isset($_POST['categories'], $_POST['tags'], $_POST['months']) && $_POST['categories'] != '' && $_POST['tags'] != '' && $_POST['months'] != '') {
            $regexPattern = '/\w+/';

            preg_match_all($regexPattern, $_POST['categories'], $categories);
            preg_match_all($regexPattern, $_POST['tags'], $tags);
            preg_match_all($regexPattern, $_POST['months'], $months);

        ?>
        <section id="sidebar">
            <div>
                <p class="header">Categories</p>
                <ul>
                <?php
                foreach($categories[0] as $category):
                ?>
                    <li><a href="#"><?= $category;?></a></li>
                <?php
                    endforeach;
                ?>
                </ul>
            </div>
            <div>
                <p class="header">Tags</p>
                <ul>
                <?php
                foreach($tags[0] as $tag):
                ?>
                    <li><a href="#"><?= $tag;?></a></li>
                <?php
                endforeach;
                ?>
                </ul>
            </div>
            <div>
                <p class="header">Months</p>
                <ul>
                <?php
                foreach($months[0] as $month):
                ?>
                    <li><a href="#"><?= $month;?></a></li>
                <?php
                endforeach;
                ?>
                </ul>
            </div>
        </section>
        <?php
        }
    ?>
</body>
</html>