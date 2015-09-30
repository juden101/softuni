<?= isset($model->error) ? $model->error : ''; ?>
<?= isset($model->success) ? $model->success : ''; ?>

<h1>Buildings</h1>

<h3>
    Resources:
    <p>Gold: <?= $model->getGold(); ?></p>
    <p>Food: <?= $model->getFood(); ?></p>
</h3>

<table border="1">
    <tr>
        <td>Building name</td>
        <td>Level</td>
        <td>Gold</td>
        <td>Food</td>
    </tr>
    <?php foreach($model->getBuildings() as $building): ?>
        <tr>
            <td><?= $building['name']; ?></td>
            <td><?= $building['level']; ?></td>
            <td><?= $building['gold']; ?></td>
            <td><?= $building['food']; ?></td>
            <td><a href="buildings.php?evolve=<?= $building['id']; ?>">Evolve</a></td>
        </tr>
    <?php endforeach; ?>
</table>