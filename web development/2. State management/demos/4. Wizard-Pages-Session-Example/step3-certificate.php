<!DOCTYPE html>
<html>

<head>
	<title>Certificate: Step 3 of 3</title>
</head>

<body>

    <?php
    // This starts the PHP session
    session_start();

    require './includes/now.fn';
    ?>

	<div>
		<table border="0" cellspacing="10" cellpadding="2"
               style="background: url('images/certificate_border.png') no-repeat">
			<tr>
				<td align="center">
					<img src="images/spacer.gif" width="415" height="3"><br />
					<h1><?php echo htmlentities($_SESSION['company']); ?></h1>
					<p><?php echo 'Date: '.$now.'<br/>'; ?>					
					In recognition of successfully completing the course:</p>
					<p><strong>
                        <?php echo htmlentities($_SESSION['coursename']); ?><br />
                    </strong></p>
					<h2>
						<?php echo htmlentities($_SESSION['fullname']); ?><br />
						<?php echo htmlentities($_SESSION['title']); ?>	
					</h2>						
					<p>is hereby awarded this</p>					
					<h3>Certificate of Completion</h3>
				</td>
			</tr>
		</table>
	</div>
</body>

</html>