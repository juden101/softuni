<?php

namespace Framework\Routers;

interface IRouter
{
    public function run();

    public function getController();

    public function getAction();

    public function getParams();
}