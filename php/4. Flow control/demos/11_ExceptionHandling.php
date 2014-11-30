<!DOCTYPE html>
<html>

<head lang="en">
    <meta charset="UTF-8">
    <title>Exception Handling - Example</title>
</head>

<body>
<?php
function checkNum($number) {
  if ($number > 1) {
    throw new Exception("The value must be 1 or smaller");
  }
}

//trigger exception in a "try" block
try {
  checkNum(-67);
  // If the exception is thrown, this text will not be shown
  echo 'If you see this, the number is 1 or smaller';
}

//catch exception
catch(Exception $e) {
  echo 'Message: ' . $e->getMessage();
}
?>
</body>

</html>
