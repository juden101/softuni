<div class="panel panel-primary">
    <div class="panel-heading">
        <h3 class="panel-title"><a
                href="<?= $this->getPath(); ?>product/<?= $this->_viewBag['body']->getId() ?>/show"><?= $this->_viewBag['body']->getName() ?></a>
        </h3>
    </div>
    <div class="panel-body">
        <div>Description: <?= $this->_viewBag['body']->getDescription() ?></div>
        <div>Price: <?= $this->_viewBag['body']->getPrice() ?> lv.</div>
        <div>Quantity: <?= $this->_viewBag['body']->getQuantity() ?> remaining</div>
        <div>
            <a href="<?= $this->getPath(); ?>categories/<?= $this->_viewBag['body']->getCategory() ?>/0/3">Category: <?= $this->_viewBag['body']->getCategory() ?></a>
        </div>
        <?php if (\Framework\App::getInstance()->isLogged()) : ?>
            <div id="btn" class="panel panel-primary btn btn-default"
                 onclick="sentAjax(<?= $this->_viewBag['body']->getId() ?>)"
                >Add to cart
            </div>
        <?php else: ?>
            <a href="<?= $this->getPath(); ?>home/login" class="panel panel-primary btn btn-default">Login to add to cart!</a>
        <?php endif ?>
    </div>
</div>

<script>
    function sentAjax(id) {
        $.ajax({
            method: "GET",
            url: "<?= $this->getPath(); ?>cart/add/" + id,
            data: {}
        }).done(
            function () {
                window.location.replace('<?= $this->getPath(); ?>cart')
            }
        );
    }
</script>