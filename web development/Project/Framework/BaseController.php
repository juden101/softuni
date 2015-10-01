<?php

namespace Framework;

use Framework\DB\SimpleDB;
use Framework\Sessions\ISession;

class BaseController
{
    /**
     * @var App
     */
    protected $app;

    /**
     * @var View
     */
    protected $view;

    /**
     * @var Config
     */
    protected $config;

    /**
     * @var InputData
     */
    protected $input;

    /**
     * @var Validator
     * @Inject Validator
     */
    protected $validator;

    /**
     * Default Db connection used
     * @var SimpleDB
     */
    protected $db;

    /**
     * @var ISession
     */
    protected $session;

    /**
     * @var Path
     */
    protected $path;

    public function __construct()
    {
        $this->app = App::getInstance();
        $this->view = View::getInstance();
        $this->config = $this->app->getConfig();
        $this->input = InputData::getInstance();
        $this->db = new SimpleDB();
        $this->session = $this->app->getSession();
        $this->path = isset($this->config->app['default_path']) ? $this->config->app['default_path'] : null;
    }

    protected function redirect($uri)
    {
        header("Location: $uri");
    }
}