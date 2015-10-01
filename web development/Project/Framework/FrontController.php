<?php

namespace Framework;

use Framework\Routers\IRouter;

class FrontController
{
    const DEFAULT_CONTROLLER = 'Index';
    const DEFAULT_METHOD = 'index';

    private static $_instance = null;
    private $_namespace = null;
    private $_controller = null;
    private $_method = null;
    private $_params = null;
    private $_requestMethod = null;
    private $_configRequestMethod = 'get';
    private $_scannedControllers = [];
    private $_customRoutes = [];

    /**
     * @var IRouter
     */
    private $_router = null;

    private function __construct()
    {
        $this->scanCustomRoutes();
    }

    public static function getInstance()
    {
        if (self::$_instance == null) {
            self::$_instance = new FrontController();
        }

        return self::$_instance;
    }

    public function getRouter()
    {
        return $this->_router;
    }

    public function setRouter(IRouter $router)
    {
        $this->_router = $router;
    }

    private function getDefaultController()
    {
        $controller = App::getInstance()->getConfig()->app['default_controller'];

        if ($controller) {
            return strtolower($controller);
        }

        return self::DEFAULT_CONTROLLER;
    }

    private function getDefaultMethod()
    {
        $method = App::getInstance()->getConfig()->app['default_method'];

        if ($method) {
            return strtolower($method);
        }

        return self::DEFAULT_METHOD;
    }

    public function dispatch()
    {
        if ($this->_router == null) {
            throw new \Exception('Invalid router!', 500);
        }

        $this->_requestMethod = strtolower($this->_router->getRequestMethod());

        if ($this->_requestMethod != 'get') {
            $token = $this->_router->getPost()['_token'];

            if (!Token::validates($token)) {
                throw new \Exception('Invalid token!', 500);
            }
        }

        $uri = $this->_router->getURI();
        $this->checkSimpleCustomRoutes($uri);
        $this->checkCustomParamsRoutes($uri);
        $this->checkForConfigRoute($uri);
    }

    private function scanCustomRoutes()
    {
        if (count($this->_scannedControllers) == 0) {
            $controllersFolder = App::getInstance()->getConfig()->app['namespaces']['Controllers'];
            $allFiles = new \RecursiveIteratorIterator(new \RecursiveDirectoryIterator($controllersFolder));
            $phpFiles = new \RegexIterator($allFiles, '/\.php$/');

            foreach ($phpFiles as $file) {
                $controllerPath = str_replace('../', '', $file->getPathName());
                $controllerPath = str_replace('.php', '', $controllerPath);
                $normalizedPath = str_replace('/', '\\', $controllerPath);

                if (!array_key_exists($normalizedPath, $this->_scannedControllers)) {
                    $this->_scannedControllers[] = $normalizedPath;
                    $normalizedPath = substr($normalizedPath, 13);
                    $reflectionController = new \ReflectionClass(new $normalizedPath);
                    $methods = $reflectionController->getMethods();

                    foreach ($methods as $method) {
                        preg_match_all('/@Route\("(.*)"\)/', $method->getDocComment(), $matches);
                        $routes = $matches[1];

                        foreach ($routes as $route) {
                            if (array_key_exists(strtolower($route), $this->_customRoutes)) {
                                throw new \Exception("Route '" . $route . "' already defined in '" .
                                    $this->_customRoutes[$route] . "'", 500);
                            }

                            $this->_customRoutes[strtolower($route)] =
                                array('Controller' => $normalizedPath, 'Method' => $method->getName());
                        }
                    }
                }
            }
        }
    }

    private function checkSimpleCustomRoutes($uri)
    {
        if (array_key_exists($uri, $this->_customRoutes)) {
            $this->_controller = $this->_customRoutes[$uri]['Controller'];
            $this->_method = strtolower($this->_customRoutes[$uri]['Method']);
            $this->_params = $uri;
            $this->processController();
        }
    }

    private function checkCustomParamsRoutes($uri)
    {
        foreach ($this->_customRoutes as $route => $value) {
            if (preg_match('/[\s\S]*{.+}[\s\S]*/', $route)) {
                $pattern = preg_replace('/{.+:int}/', '\d+', $route);
                $pattern = preg_replace('/{.+:string}/', '\w+', $pattern);
                $pattern = str_replace('/', '\/', $pattern);
                $pattern = '/' . $pattern . '/';

                if (preg_match($pattern, $uri)) {
                    $this->_controller = $this->_customRoutes[$route]['Controller'];
                    $this->_method = strtolower($this->_customRoutes[$route]['Method']);
                    $this->_params = $uri;
                    $this->processController();
                }
            }
        }
    }

    private function checkForConfigRoute($uri)
    {
        $routes = App::getInstance()->getConfig()->routes;
        $routeData = null;

        if (is_array($routes) && count($routes) > 0) {
            foreach ($routes as $route => $data) {
                $route = strtolower($route);

                if (stripos($uri, $route) === 0 &&
                    ($uri == $route || stripos($uri, $route . '/') === 0) &&
                    $data['namespace']
                ) {
                    $this->_namespace = $data['namespace'];
                    $routeData = $data;
                    // package found, remove it from uri - example Admin/index/edit/3
                    $uri = substr($uri, strlen($route) + 1);

                    break;
                }
            }
        } else {
            throw new \Exception('Default route missing', 500);
        }

        if ($this->_namespace == null && $routes['*']['namespace']) {
            $this->_namespace = $routes['*']['namespace'];
            $routeData = $routes['*'];
        } else if ($this->_namespace == null && !$routes['*']['namespace']) {
            throw new \Exception('Default route missing', 500);
        }

        $params = explode('/', strtolower($uri));
        // No params means no controller and method as well.
        if ($params[0]) {
            $this->_controller = trim($params[0]) . 'Controller';

            if ($params[1]) {
                $this->_method = trim($params[1]);
                unset($params[0], $params[1]);
                $this->_params = array_values($params);
            } else {
                $this->_method = $this->getDefaultMethod();
            }
        } else {
            $this->_controller = $this->getDefaultController() . 'Controller';
            $this->_method = $this->getDefaultMethod();
        }

        if (is_array($routeData) &&
            isset($routeData['controllers']) && $routeData['controllers'] != null
        ) {
            $controller = str_replace('Controller', '', $this->_controller);

            if (isset($routeData['controllers'][$controller]['requestMethod'][$this->_method])) {
                $this->_configRequestMethod = $routeData['controllers'][$controller]['requestMethod'][$this->_method];
            }

            if (isset($routeData['controllers'][$controller]['methods'][$this->_method])) {
                $this->_method = strtolower($routeData['controllers'][$controller]['methods'][$this->_method]);
            } else {
                if ($this->_method != self::DEFAULT_METHOD) {
                    throw new \Exception("No method set for '" . $this->_method . "'!", 404);
                }
            }

            if (isset($routeData['controllers'][$controller]['goesTo'])) {
                $this->_controller = strtolower($routeData['controllers'][$controller]['goesTo']) . 'Controller';
            }

            if (isset($routeData['controllers'][$controller]['requestMethod'][$this->_method])) {
                $this->_configRequestMethod = $routeData['controllers'][$controller]['requestMethod'][$this->_method];
            }
        }

        $this->processController();
    }
    private function processController()
    {
        $input = InputData::getInstance();
        $input->setGet($this->_params);
        $input->setPost($this->_router->GetPost());
        $file = ucfirst($this->_namespace) . '\\' . ucfirst($this->_controller);
        $this->_controller = $file;
        $realPath = str_replace('\\', DIRECTORY_SEPARATOR, $file);
        $realPath = realpath('ShoppingCart\\' . $realPath . '.php');

        if (file_exists($realPath) && is_readable($realPath)) {
            $calledController = new $file();

            if (method_exists($calledController, $this->_method)) {
                if ($this->isValidRequestMethod($calledController, $this->_method)) {
                    $calledController->{strtolower($this->_method)}();
                    exit;
                } else {
                    throw new \Exception("Method does not allow '" . ucfirst($this->_requestMethod) . "' requests!", 500);
                }
            } else {
                throw new \Exception("'" . $this->_method . "' not found in '" . $file . '.php', 404);
            }
        } else {
            throw new \Exception("File '" . $file . '.php' . "' not found!", 404);
        }
    }

    private function isValidRequestMethod($controller, $method)
    {
        $reflectionMethod = new \ReflectionMethod($controller, $method);
        $foundRequestAnnotations = [];
        $comment = strtolower($reflectionMethod->getDocComment());

        if (preg_match('/@get/', $comment)) {
            $foundRequestAnnotations[] = 'get';
        }

        if (preg_match('/@post/', $comment)) {
            $foundRequestAnnotations[] = 'post';
        }

        if (preg_match('/@put/', $comment)) {
            $foundRequestAnnotations[] = 'put';
        }

        if (preg_match('/@delete/', $comment)) {
            $foundRequestAnnotations[] = 'delete';
        }

        if (count($foundRequestAnnotations) != 0) {
            if (count($foundRequestAnnotations) > 1) {
                throw new \Exception('Method cannot have more than 1 request method annotation', 500);
            }

            $request = $foundRequestAnnotations[0];

            if (strtolower($request) != $this->_requestMethod) {
                return false;
            }

            return true;
        }

        if ($this->_requestMethod != $this->_configRequestMethod) {
            return false;
        }

        return true;
    }
}