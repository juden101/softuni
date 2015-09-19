<h1>Tab #2</h1>

<p>Tab #2 - generate random numbers</p>

<?php
    if (isset($_POST['count'])) {
        $count = intval($_POST['count']);
        if ($count == 0) {
            $count = 1;
        }
        echo '<ul>';
        for ($i = 0; $i < $count; $i++) {
            echo '<li>' . rand(1, 1000) . '</li>';
        }
        echo '</ul>';
    }
?>

<form method="post" action="index.php?tabid=2">
    How many random numbers to generate? <input type="text" name="count" />
    <br />
    <input type="submit" value="submit">
</form>
