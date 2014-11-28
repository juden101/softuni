<!DOCTYPE html>
<html>
<body>
	<?php
	if (isset($_POST['submit'])) {
		if ($_POST["name"] || $_POST["age"]) {
			echo "Welcome ". htmlentities($_POST['name']). "<br />";
			echo "You are ". htmlentities($_POST['age']). " years old." . "<br />";
			exit();
		}
	}
	?>
	<form method="post">
		Name: <input type="text" name="name" />
		Age: <input type="text" name="age" />
		<input type="submit" name="submit" />
	</form>
</body>
</html>