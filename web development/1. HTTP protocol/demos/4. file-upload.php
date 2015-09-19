<!DOCTYPE html>
<html>
<body>

<form action="" method="post" enctype="multipart/form-data">
    Select image to upload:
    <input type="file" name="fileToUpload" id="fileToUpload">
    <input type="submit" value="Upload Image" name="submit">
</form>

<?php
    $target_dir = "uploads/";
    if(isset($_POST["submit"])) {
        $target_file = $_FILES["fileToUpload"];
        var_dump($target_file);

        $file = file($target_file['tmp_name']);

        file_put_contents('./uploads/' . $target_file["name"], $file);
        echo "File uploaded!";
    }
?>
</body>
</html>