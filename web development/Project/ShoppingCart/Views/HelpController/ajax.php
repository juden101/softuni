<h1>Ajax test</h1>
<button id="btn" class="btn btn-default" onclick="send()">Submit Ajax</button>
<div id="#"></div>
<script>
    function send() {
        <?php
        \Framework\AjaxViewHelper::init()->initForm($this->getPath() . "help/jsonroutes", "get")->initCallback("function( msg ) {
           document.getElementById(\"#\").innerHTML = msg;
        }")->render(true);
        ?>
    }
</script>