<header class="login">
    <?php
    session_start();
    if (isset($_SESSION['user'])) : ?>
        <div class="user">User: <?= htmlspecialchars($_SESSION['user']) ?></div>
        <div class="user-menu">
            Menu:
            <a href="main.php">[Main]</a>
            <a href="other.php">[Other]</a>
        </div>
        <div class="logout"><a href="logout.php">[Logout]</a></div>
    <?php else :
        header('Location: login.php');
        die;
    endif; ?>
</header>
