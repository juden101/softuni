<?php include('header.php'); ?>
<?php include('auth_header.php'); ?>
<?php include('config.php'); ?>


<h1>Hi, <?= htmlspecialchars($_SESSION['user']) ?>, how are you?</h1>

<p>
	This page is for logged-in users only.
	Anonymous visitors cannot see it.
</p>
<div>
    <form action="" method="GET">
        <input type="text" id="search" name="search" />
        <input type="submit" value="Search" />
    </form>

    <?php if(isset($_GET['search'])) : ?>
        <ul>
            <?php
                $searchTerm = mysql_real_escape_string($_GET['search']);
                mysql_connect(DB_HOST, DB_USER, DB_PASS);
                mysql_select_db(DB_NAME);
                $searchSql = "SELECT Title FROM Books WHERE Title LIKE '%$searchTerm%'";
                $result = mysql_query($searchSql);

                $row = mysql_fetch_assoc($result);
                if ($row) {
                    while($row) {
                        $title = htmlentities($row['Title']);
                        echo "<li>$title</li>";
                        $row = mysql_fetch_assoc($result);
                    }
                }
                else {
                    echo "<li>No results.</li>";
                }
            ?>
        </ul>
    <?php endif; ?>
    <div id="search-result">

    </div>
</div>

<?php include('footer.php'); ?>
