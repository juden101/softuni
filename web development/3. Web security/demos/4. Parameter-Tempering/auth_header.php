<header class="login">
    <?php
        session_start();
        if (isset($_SESSION['user'])) :
    ?>
        <div class="user">User: <?= htmlspecialchars($_SESSION['user']) ?></div>
        <div class="logout"><a href="logout.php">[Logout]</a></div>
        <div class="edit-profile"><a href="edit-profile.php?user=<?php echo $_SESSION['user'] ?>">Edit profile</a></div>
    <?php
        else :
            header('Location: login.php');
            die;
        endif;
    ?>
</header>