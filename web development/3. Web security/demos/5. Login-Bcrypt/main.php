<?php include('header.php'); ?>
<?php include('auth_header.php'); ?>

<h1>Hi, <?= htmlspecialchars($_SESSION['user']) ?>, how are you?</h1>

<p>
	This page is for logged-in users only.
	Anonymous visitors cannot see it.
</p>
<?php include('footer.php'); ?>
