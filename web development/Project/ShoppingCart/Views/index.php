<html>
    <head>
        <meta charset="UTF-8">
        <title>Document</title>
    </head>
    <body>
        <h1>Index View</h1>
        <?php
        \Framework\FormViewHelper::init()->initTextBox()->setAttribute('class', 'some')->setName('username')->setValue('pesho')->create()->render();
        ?>
        <div><?= $this->_viewBag->getData(); ?></div>
    </body>
</html>