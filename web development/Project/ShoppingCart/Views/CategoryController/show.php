<div class="alert alert-success" role="alert" id="#" style="display: none"></div>

<?php
if (!$this->_viewBag['body']->getProducts()) :?>
    <h1 class="alert alert-danger text-center">No Products</h1>
<?php endif;
foreach ($this->_viewBag['body']->getProducts() as $product) :?>
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title"><?= $product->getName() ?></h3>
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
                     onclick="sendAjax('<?= $product->getName(); ?>', '<?= $this->getPath() . 'cart/add/' . $product->getId(); ?>')">Add to cart
                </div>
                <div id="btn" class="panel panel-primary btn btn-default" onclick="enableReviewForm(<?= $product->getId()?>)">
                    Write review
                </div>
                <a href="<?= $this->getPath(); ?>product/<?= $product->getId() ?>/show" id="btn" class="panel panel-primary btn btn-default">
                    Show reviews</a>
                <?php \Framework\FormViewHelper::init()->initForm($this->getPath() . 'review/add/' . $product->getId(),
                    ['class' => 'form-group', 'style' => 'display: none', 'id' => $product->getId()])
                    ->initLabel()->setAttribute('for', 'message')->setValue('Message')->create()
                    ->initTextArea()->setAttribute('name', 'message')->setAttribute('class', 'form-control input-md')->setAttribute('id', 'message')->create()
                    ->initSubmit()->setAttribute('value', 'Send')->setAttribute('class', 'btn btn-primary btn-sm col-sm-1 col-sm-offset-5')->create()
                    ->render(true);
            else: ?>
                <a href="<?= $this->getPath(); ?>home/login" class="panel panel-primary btn btn-default">Login to add to cart!</a>
                <a href="<?= $this->getPath(); ?>home/login" class="panel panel-primary btn btn-default">Login to write review!</a>
                <a href="<?= $this->getPath(); ?>product/<?= $product->getId() ?>/show" id="btn" class="panel panel-primary btn btn-default">Show reviews</a>
            <?php endif?>
        </div>
    </div>
<?php endforeach; ?>
<ul class="pager">
    <li><a href="<?= $this->getPath() . 'categories/' . $this->_viewBag['body']->getCategory() ?>/<?php
        $start = $this->_viewBag['body']->getStart();
        if ($start - 3 >= 0) {
            echo $start -= 3;
        } else {
            echo 0;
        }
        ?>/<?php
        $end = $this->_viewBag['body']->getEnd();
        if ($end - 3 > 0) {
            echo $end -= 3;
        } else {
            echo 3;
        }
        ?>">Previous</a></li>
    <?php if ($this->_viewBag['body']->getProducts()) : ?>
        <li><a href="<?= $this->getPath() . 'categories/' . $this->_viewBag['body']->getCategory() ?>/<?php
            $start = $this->_viewBag['body']->getStart();
            echo $start += 3;
            ?>/<?php
            $end = $this->_viewBag['body']->getEnd();
            echo $end += 3;
            ?>"> Next</a></li>
    <?php endif; ?>
</ul>