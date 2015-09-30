<?= isset($model->error) ? $model->error : ''; ?>
<?= isset($model->success) ? $model->success : ''; ?>

<h1>Hello, <?= $model->getUsername(); ?></h1>

<?php if (isset($_GET['error'])) : ?>
    <h2>An error occured</h2>
<?php elseif (isset($_GET['success'])) : ?>
    <h2>Successfully updated profile</h2>
<?php endif; ?>

<h3>
    Resources:
    <p>Gold: <?= $model->getGold(); ?></p>
    <p>Food: <?= $model->getFood(); ?></p>
</h3>

Go to:
<div class="menu">
    <a href="buildings">Buildings</a>
</div>

<form action="" method="POST">
    <div>
        <input type="text" name="username" value="<?= $model->getUsername();?>" />
        <input type="password" name="password" />
        <input type="password" name="confirm" />
        <input type="submit" name="edit" value="Edit" />
    </div>
</form>