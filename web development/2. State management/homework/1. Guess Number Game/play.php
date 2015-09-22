<?php
session_start();

if (!isset($_SESSION['game_number'])) {
    header('Location: index.php');
}

if (isset($_POST['game_number']) && $_POST['game_number'] != null) {
    $game_number = $_POST['game_number'];

    if (!is_numeric($game_number) || $game_number < 0 || $game_number > 100)
    {
        echo '<h1>Invalid number!</h1>';
    }
    else
    {
        if ($game_number == $_SESSION['game_number'])
        {
            echo '<h1>Congratulations, ' . $_SESSION['name'] . '</h1>';
            echo '<h2><a href="index.php">Play again</a></h2>';

            session_unset($_SESSION);
        }
        else if ($game_number < $_SESSION['game_number'])
        {
            echo 'Up';
        }
        else if ($game_number > $_SESSION['game_number'])
        {
            echo 'Down';
        }
    }
}

?>

<form method="POST">
    <input type="text" name="game_number" placeholder="Number in range [0...100]" />
    <input type="submit" value="Play" />
</form>