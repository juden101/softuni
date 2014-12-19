<?php
session_start();
include '../config.php';
include '../functions.php';
ifLoggedIn();

$isError = false;
$errorMessage = '';

$current_post = [
	'title' => '',
	'description' => '',
	'content' => '',
	'tags' => [],
	'valid' => false
];

if (isset($_POST['submit'])) {
    $current_post['title'] = $_POST['title'];
    $current_post['description'] = $_POST['description'];
    $current_post['content'] = $_POST['content'];
    $current_post['tags'] = explode(',', $_POST['tags']);
	
    try {
        $current_post['valid'] = isPostValid($current_post['title'], $current_post['description'], $current_post['content'], $current_post['tags']);
    } catch(Exception $e) {
        $isError = true;
        $errorMessage = $e->getMessage();
    }
	
    if($current_post['valid']) {
        createPost($current_post['title'], $current_post['description'], $current_post['content'], $_SESSION['username'], time());
		
		$post_id = getLastPostId();
		$post_id = $post_id['post_id'];
        createTags($current_post['tags'], $post_id);
		
		header('Location: index.php');
		exit;
    }
}
?>
<html>
<head>
    <title>Admin panel - post create</title>
    <link rel="stylesheet" href="../styles/main.css" type="text/css"/>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
</head>
<body class="adminPanel">
	<ul class="menu">
		<li><a href="index.php">Dashboard</a></li>
		<li><a href="post_create.php">Create new post</a></li>
		<li><a href="users_overview.php">Users overview</a></li>
		<li><a href="../logout.php">Logout</a></li>
	</ul>
	<?= $isError ? "<p class=\"error\">{$errorMessage}</p>" : null;?>
	<form method="POST" id="post-form">
		<input type="text" name="title" value="<?= $current_post['title'];?>" placeholder="Title..." />
		<textarea name="description" placeholder="Description..."><?= $current_post['description'];?></textarea>
		<textarea name="content" id="editor" placeholder="Content..."><?= $current_post['content'];?></textarea>
		<input type="text" name="tags" value="<?= implode(',', $current_post['tags']);?>" placeholder="tag1, tag2" />
		<input type="submit" value="Submit" name="submit"/>
	</form>

	<script type="text/javascript" src="../scripts/ckeditor/ckeditor.js"></script>
	<script type="text/javascript" src="../scripts/loadEditor.js"></script>
</body>
</html>