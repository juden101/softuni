<!DOCTYPE html>
<html>
<head>
    <title>Sum Two Numbers</title>
</head>
<body>
	<form method="get">
		<label for="a">a</label>
		<input type="text" name="a" id="a"/>
		<label for="b">b</label>
		<input type="text" name="b" id="b"/>
		<input type="submit" name="submit" value="Calculate Sum"/><br />
	</form>

	<?php
	if (isset($_GET['submit'])) {
		echo 'The sum of the numbers is '.($_GET['a'] + $_GET['b']).'.';
	}
	?>	   
</body>
</html>