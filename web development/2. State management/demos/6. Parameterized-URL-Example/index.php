<!DOCTYPE html>
<html>
<head>
    <title>Tabs</title>
</head>
<body>
    <?php
    define('NUMTABS', 3);
    ?>

    <p>
        Select a Tab:
        <a href="index.php?tabid=1">[Tab #1]</a>
        <a href="index.php?tabid=2">[Tab #2]</a>
        <a href="index.php?tabid=3">[Tab #3]</a>
    </p>

    <?php
    if (isset($_GET['tabid'])) {
        $selectedTabID = $_GET['tabid'];
    }
    if (($selectedTabID >= 1 && $selectedTabID <= NUMTABS)) {
        include('includes/tab' . $selectedTabID . '.php');
    } else {
        $requestPath = parse_url($_SERVER['REQUEST_URI'], PHP_URL_PATH);
        header("Location: " . $requestPath . "?tabid=1");
        die;
    }
    ?>
</body>
</html>
