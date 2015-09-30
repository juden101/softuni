<?= isset($model->error) ? $model->error : ''; ?>
<?= isset($model->success) ? $model->success : ''; ?>

<h1>Add todo</h1>

<form method="POST" action="todos/add">
    <input type="text" name="content" />
    <input type="submit" name="Add" />
</form>