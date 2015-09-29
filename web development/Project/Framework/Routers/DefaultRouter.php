<?php

namespace Framework\Routers;

class DefaultRouter implements IRouter {
    const DEFAULT_CONTROLLER = 'Home';
    const DEFAULT_ACTION = 'index';

    private $_controller = null;
    private $_action = null;
    private $_params = [];

    public function run() {
        if (isset($_GET['uri']) && $_GET['uri'] != null) {
            $uri = strtolower($_GET['uri']);
            $params = explode("/", $uri);

            if (isset($params) && !empty($params)) {
                $controller = ucfirst(array_shift($params));
                $this->setController($controller);

                if (isset($params) && !empty($params)) {
                    $action = array_shift($params);
                    $this->setAction($action);
                    $this->setParams($params);
                }
            }
        }

        if (!isset($this->_controller) || $this->_controller == null) {
            $this->setController(self::DEFAULT_CONTROLLER);
        }

        if (!isset($this->_action) || $this->_action == null) {
            $this->setAction(self::DEFAULT_ACTION);
        }
    }

    public function getController() {
        return $this->_controller;
    }

    private function setController($controller) {
        $this->_controller = $controller;
    }

    public function getAction() {
        return $this->_action;
    }

    private function setAction($action) {
        $this->_action = $action;
    }

    public function getParams() {
        return $this->_params;
    }

    private function setParams($params) {
        $this->_params = $params;
    }
}