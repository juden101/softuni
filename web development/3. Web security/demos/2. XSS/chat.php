<?php include('header.php'); ?>
<?php include('auth_header.php'); ?>
<?php include('config.php'); ?>
<h1>Chat</h1>

<p>
    This page is for logged-in users only.
    Anonymous visitors cannot see it.
</p>

    <form action="" method="POST">
        Message: <input type="text" name="message" />
        <input type="submit" />
    </form>

<?php
    mysql_connect(DB_HOST, DB_USER, DB_PASS);
    mysql_select_db(DB_NAME);

    if (isset($_POST['message'])) {
        $message = $_POST['message'];
        $username = $_SESSION['user'];
        $insertSql = "INSERT INTO Messages (Content, Username) VALUES ('".$message."', '".$username."')";
        $result = mysql_query($insertSql);
        if ($result) {
            showMessages();
        }
    }
    else {
        showMessages();
    }

    function showMessages() {
        $selectMessages = "SELECT Content, Username FROM Messages ORDER BY Id DESC";
        $resultMessages = mysql_query($selectMessages);

        $row = mysql_fetch_assoc($resultMessages);
        if ($row) {
            while($row) {
                // $message = htmlspecialchars($row['Content']);
                $message = $row['Content'];
                $username = $row['Username'];
                echo "<li><strong>$username</strong>: $message</li>";
                $row = mysql_fetch_assoc($resultMessages);
            }
        }
        else {
            echo "<li>No results.</li>";
        }
    }
?>


<?php include('footer.php'); ?>