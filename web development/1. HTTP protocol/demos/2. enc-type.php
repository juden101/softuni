<strong>application/x-www-form-urlencoded:</strong>
<form action="" method="post" enctype="application/x-www-form-urlencoded">
    Name:
    <input type="text" name="name">
    <input type="file" name="file"/>
    <input type="submit" value="Upload" name="submit">
</form>

<strong>multipart/form-data:</strong>
<form action="" method="post" enctype="multipart/form-data">
    Name:
    <input type="text" name="name">
    <input type="file" name="file"/>
    <input type="submit" value="Upload" name="submit">
</form>

<strong>text/plain:</strong>
<form action="" method="post" enctype="text/plain">
    Name:
    <input type="text" name="name">
    <input type="file" name="file"/>
    <input type="submit" value="Upload" name="submit">
</form>

<?php
    echo "POST:";
    var_dump($_POST);
    echo "Request:";
    var_dump($_REQUEST);
    echo "Files:";
    var_dump($_FILES);