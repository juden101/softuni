<header>
    <nav class="navbar navbar-default">
        <div class="container-fluid">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse"
                        data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="<?= $this->getPath(); ?>home/index">Shopping Cart</a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav">
                    <li>
                        <?php Framework\FormViewHelper::init()
                            ->initLink()->setAttribute('href', $this->getPath() . 'home/index')->setValue('Home')->create()
                            ->render();
                        ?>
                    </li>
                    <?php if (!\Framework\App::getInstance()->isLogged()) : ?>
                        <li>
                            <?php \Framework\FormViewHelper::init()
                                ->initLink()->setAttribute('href', $this->getPath() . 'home/login')->setValue('Login')->create()
                                ->render();
                            ?>
                        </li>
                        <li>
                            <?php \Framework\FormViewHelper::init()
                                ->initLink()->setAttribute('href', $this->getPath() . 'home/register')->setValue('Register')->create()
                                ->render();
                            ?>
                        </li>
                    <?php endif; ?>
                    <li>
                        <?php \Framework\FormViewHelper::init()
                            ->initLink()->setAttribute('href', $this->getPath() . 'products/0/3')->setValue('All products')->create()
                            ->render();
                        ?>
                    </li>
                    <li>
                        <?php \Framework\FormViewHelper::init()
                            ->initLink()->setAttribute('href', $this->getPath() . 'categories')->setValue('All categories')->create()
                            ->render();
                        ?>
                    </li>
                    <?php if (\Framework\App::getInstance()->isLogged()) : ?>
                    <li>
                        <?php \Framework\FormViewHelper::init()
                            ->initLink()->setAttribute('href', $this->getPath() . 'products/sell')->setValue('Sell product')->create()
                            ->render();
                        ?>
                    </li>
                    <?php endif; ?>
                    <li>
                        <?php \Framework\FormViewHelper::init()
                            ->initBoostrapDropDown('Help', 'li')
                            ->setDropDownLi($this->getPath() . 'help', 'Help')
                            ->setDropDownLi($this->getPath() . 'help/ajax', 'Ajax test')
                            ->create()->render();
                        ?>
                    </li>
                </ul>
                <?php if (\Framework\App::getInstance()->isLogged()) : ?>
                    <ul class="nav navbar-nav navbar-right">
                        <li>
                            <a href="<?= $this->getPath(); ?>cart"><span class="glyphicon glyphicon-shopping-cart" aria-hidden="true"></span>
                                <span class="badge" id="cart-products-count"><?= count(\Framework\App::getInstance()->getSession()->cart) ?></span></a>
                        </li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button"
                               aria-haspopup="true"
                               aria-expanded="false"><?= \Framework\App::getInstance()->getUsername() ?><span
                                    class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><?= \Framework\FormViewHelper::init()
                                        ->initLink()
                                        ->setAttribute('href', $this->getPath() . "user/" . \Framework\App::getInstance()->getUsername() . "/profile")
                                        ->setValue('Profile')
                                        ->create()
                                        ->render(); ?></li>
                                <?php if (\Framework\App::getInstance()->isAdmin()) : ?>
                                    <li><a href="<?= $this->getPath(); ?>admin">Admin</a></li>
                                <?php endif; ?>
                                <li role="separator" class="divider"></li>
                                <li>
                                    <?php Framework\FormViewHelper::init()
                                        ->initLink()->setAttribute('href', $this->getPath() . 'user/logout')->setValue('Logout')->create()
                                        ->render();
                                    ?>
                                </li>
                            </ul>
                        </li>
                    </ul>
                <?php endif; ?>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container-fluid -->
    </nav>
</header>