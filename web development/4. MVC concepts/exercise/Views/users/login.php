<?= isset($model->error) ? $model->error : ''; ?>

<form action="" method="POST">
    <input type="text" name="username" />
    <input type="password" name="password" />
    <input type="submit" value="Login" />
</form>