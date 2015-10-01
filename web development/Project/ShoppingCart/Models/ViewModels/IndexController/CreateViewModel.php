<?php

namespace Models\ViewModels\IndexController;

class CreateViewModel
{
    private $data;

    public function __construct($data)
    {
        $this->data = $data;
    }

    /**
     * @return mixed
     */
    public function getData()
    {
        return $this->data;
    }
}