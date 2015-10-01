<?php

namespace Models\ViewModels\Admin\IndexController;

class AdminCreateViewModel {
    private $data;

    function __construct($data)
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