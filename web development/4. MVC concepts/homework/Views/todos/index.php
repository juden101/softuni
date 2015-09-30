<?= isset($model->error) ? $model->error : ''; ?>
<?= isset($model->success) ? $model->success : ''; ?>

<h1>Todos</h1>

<?php

var_dump($model->getTodos());