<!DOCTYPE html>
<html>
<body>
<?php
if (isset($_COOKIE["user"])) :
    echo "Welcome " . $_COOKIE["user"] . "!";
else :
    echo "Welcome guest!";
endif;
setcookie("user", "Nakov", time() + 5); // expires in 5 sec.
?>
</body>
</html>
