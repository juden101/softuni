<!DOCTYPE html>
<html>
<head>
    <title>Table</title>
</head>
<body>
	<form method="post">
		<label for="rows">Rows</label>
		<input type="text" name="rows" id="rows"/>
		<label for="cols">Cols</label>
		<input type="text" name="cols" id="cols"/>
		<input type="submit" name="submit" value="Create Table"/>
	</form>
   <?php
	   if (isset($_POST['submit'])) {
		   echo '<table border="1">';
		   for ($row = 0; $row < $_POST['rows']; $row++) {
			   echo '<tr>';
			   for ($col = 0; $col < $_POST['cols']; $col++) {
					echo '<td>'.($col + $row).'</td>';
			   }
			   echo '</tr>';
		   }
		   echo '</table>';
		}
   ?>
</body>
</html>