<div class="input-group">
    <h1>Welcome to the Admin Home</h1>
    <h2>Admin list:</h2>
    <ul class="list-group">
        <?php foreach ($this->_viewBag['body']->getAdmins() as $key => $admin) : ?>
            <li class="list-group-item"><a href="<?= $this->getPath(); ?>user/<?= $admin ?>/profile"><?= ucfirst($admin) ?></a></li>
        <?php endforeach; ?>
    </ul>
</div>