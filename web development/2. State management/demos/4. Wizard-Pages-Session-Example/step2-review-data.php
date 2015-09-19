<!DOCTYPE html>
<html>

<head>
	<title>Certificate: Step 2 of 3</title>
</head>

<body>

    <?php
    // This starts the PHP session
    session_start();

	// Push the posted form fields into the session
	$_SESSION['fullname'] = $_POST['fullname'];
	$_SESSION['title'] = $_POST['title'];
    $_SESSION['company'] = $_POST['company'];
    $_SESSION['coursename'] = $_POST['coursename'];
	?>

	<p>Here we have simple output. Go to next page for Certificate-like view.</p>
	<form action="step3-certificate.php" name="certificateSubmit" method="POST">
		<table border="0" cellspacing="10">
			<tr>
				<td>Full Name: </td>
				<td><?php echo htmlentities($_SESSION['fullname']); ?></td>
			</tr>
			<tr>
				<td>Title:</td>
				<td><?php echo htmlentities($_SESSION['title']); ?></td>
			</tr>
			<tr>
				<td>Company:</td>
				<td><?php echo htmlentities($_SESSION['company']); ?></td>
			</tr>
			<tr>
				<td>Course:</td>
                <td><?php echo htmlentities($_SESSION['coursename']); ?></td>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td><input type="Submit" name="submit" 
					value="Generate Certificate &gt; &gt;"></td>
			</tr>
		</table>
	</form>
</body>

</html>
