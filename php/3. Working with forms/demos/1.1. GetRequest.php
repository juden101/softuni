<!DOCTYPE html>
<html>
<head>
	<title>GET Request</title>
</head>
<body>
	<form method="get">
		Name: <input type="text" name="name" />
		Age: <input type="text" name="age" />
		<input type="submit" name="submit" />
	</form>	

	<?php
	//check if keys "name" or "age" exist (you may get warning )
	if (isset($_GET['submit'])) {
		$name = htmlentities($_GET['name']);
		$age = htmlentities($_GET['age']);
	    echo "Welcome $name!<br />";
	    echo "You are $age years old.";
	}
	?>
</body>
</html>
