<h1>Ajax test</h1>
<button id="btn" class="btn btn-default" onclick="sentAjax()">Submit Ajax</button>
<div id="#"></div>
<script>
    function sentAjax() {
        <?php
        \Framework\AjaxViewHelper::init()->initForm("/help/jsonroutes", "put")->initCallback("function( msg ) {
           document.getElementById(\"#\").innerHTML = msg;
        }")->render(true);
        ?>
    }
</script>