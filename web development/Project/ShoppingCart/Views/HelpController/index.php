<html>
<head>
    <meta charset="UTF-8">
    <title>Api</title>
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
</head>
<body>
<div class="container">
    <?php
    $routes = $this->_viewBag->getRoutes();
    foreach ($routes as $route => $bindingModel) {
        \Framework\FormViewHelper::init()
            ->initDiv()->setValue($route)->setAttribute("class", "text-primary")->create()->render();
        if ($bindingModel) {
            \Framework\FormViewHelper::init()
                ->initDiv()->setValue("Binding model params:")->create()->render();
            foreach ($bindingModel as $param) {
                \Framework\FormViewHelper::init()
                    ->initDiv()->setValue("*$param")->create()->render();
            }
        }
        echo "<hr />";
    }
    ?>
</div>
</body>
</html>