<?php

namespace Framework\Routers;

class DefaultRouter implements IRouter {
    public function getURI() {
        return isset($_GET['uri']) ? strtolower($_GET['uri']) : null;
    }
}