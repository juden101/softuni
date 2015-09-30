<?= isset($model->error) ? $model->error : ''; ?>
<?= isset($model->success) ? $model->success : ''; ?>

<h1>Todos</h1>

<ul>
<?php foreach ($model->getTodos() as $todo): ?>
    <li><?= $todo['todo_item'] ;?> | <a href="../todos/delete/<?= $todo['id']; ?>">Delete</a></li>
<?php endforeach; ?>
</ul>