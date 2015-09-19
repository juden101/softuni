<!DOCTYPE html>
<html>

<head>
	<title>Certificate: Step 1 of 3</title>
</head>

<body>
    <p>Fill Out Your Data:</p>
    <form action="step2-review-data.php" name="firstSubmit" method="POST">
        <table border="0" cellspacing="10">
            <tr>
                <td>Full Name: </td>
                <td><input name="fullname" type="text" size="20" maxlength="80"></td>
            </tr>
            <tr>
                <td>Title:</td>
                <td><input name="title" type="text" size="20" maxlength="80"></td>
            </tr>
            <tr>
                <td>Company:</td>
                <td><input name="company" type="text" size="20" maxlength="80"></td>
            </tr>
            <tr>
                <td>Course:</td>
                <td><input name="coursename" type="text" size="20" maxlength="80"
                           readonly="readonly" value="PHP Web Development"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><input type="submit" name="submit" value="Proceed &gt; &gt;"></td>
            </tr>
        </table>
    </form>
</body>
</html>
