<?php
$file = './uploads/images.jpg';

if(file_exists($file)) {
    // Download the image with name of the image.
    header('Content-Disposition: attachment; filename='.basename($file));
    header('Content-Length: ' . filesize($file));
    readfile($file);

    // Show the image in the browser
    header('Content-Type: image/jpeg');
    header('Content-Disposition: inline; filename='.basename($file));
    header('Content-Length: ' . filesize($file));
    readfile($file);

    // Show the image in the browser as text/html
    header('Content-Type: text/html');
    readfile($file);

    // Download the image with name: 6. file-download.php
    header('Content-Type: application/octet-stream');
    readfile($file);

    exit;
}