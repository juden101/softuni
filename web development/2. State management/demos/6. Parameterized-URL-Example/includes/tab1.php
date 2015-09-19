<h1>Tab #1</h1>

<p>Tab #1 - greetings</p>

<?php
    if (isset($_POST['name'])) {
        echo '<p>Hello, ' . htmlspecialchars($_POST['name']) . '!</p>';
    }
?>

<form method="post" action="index.php?tabid=1">
    Enter your name: <input type="text" name="name" />
    <br />
    <input type="submit">
</form>
