<div class="alert alert-success" role="alert" id="#" style="display: none"></div>

<?php
if (!$this->_viewBag['body']->getProducts()) :?>
    <h1 class="alert alert-danger text-center">No Products</h1>
<?php endif;
foreach ($this->_viewBag['body']->getProducts() as $product) :?>
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title"><a href="<?= $this->getPath() . 'product/' . $product->getId() ?>/show"><?= $product->getName() ?></a></h3>
        </div>
        <div class="panel-body">
            <div>Description: <?= $product->getDescription() ?></div>
            <div>Price: <?= $product->getPrice() ?> $</div>
            <div>Quantity: <?= $product->getQuantity() ?> remaining</div>
            <div>
                <a href="<?= $this->getPath() . 'categories/' . $product->getCategory() ?>/0/3">Category: <?= $product->getCategory() ?></a>
            </div>
            <?php if (\Framework\App::getInstance()->isLogged()) : ?>
                <div id="btn" class="panel panel-primary btn btn-default"
                     onclick="sentAjax(<?= $product->getId() . ', \'' . $product->getName() . '\'' ?>)"
                    >Add to cart
                </div>
            <?php else: ?>
                <a href="<?= $this->getPath(); ?>home/login" class="panel panel-primary btn btn-default">Login to add to cart!</a>
            <?php endif?>
        </div>
    </div>
<?php endforeach; ?>

<ul class="pager">
    <?php
        $start = $this->_viewBag['body']->getStart();
        $start - 3 >= 0 ? $start -= 3 : $start = 0;
        $end = $this->_viewBag['body']->getEnd();
        $end - 3 > 0 ? $end -= 3 : $end = 3;
    ?>
    <li>
        <a href="<?= $this->getPath() . 'products/' . $start . '/' . $end; ?>">Previous</a>
    </li>
    <?php if ($this->_viewBag['body']->getProducts()) : ?>
        <li>
            <?php
            $start = $this->_viewBag['body']->getStart() + 3;
            $end = $this->_viewBag['body']->getEnd();
            ?>
            <a href="<?= $this->getPath() . 'products/' . $start . '/' . $end; ?>">Next</a>
        </li>
    <?php endif; ?>
</ul>

<script>
    function sentAjax(id, name) {
        $.ajax({
            method: "GET",
            url: "<?= $this->getPath(); ?>cart/add/" + id,
            data: {}
        }).done(
            function (msg) {
                document.getElementById("#").style.display = 'block';
                document.getElementById("#").innerHTML = '"' + name + '" added to cart!';
                document.getElementById("cart-products-count").innerHTML = parseInt(document.getElementById("cart-products-count").innerHTML) + 1;
            }
        );
    }
</script>