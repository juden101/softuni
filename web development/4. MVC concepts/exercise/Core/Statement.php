<?php

namespace SoftUni\Core;

class Statement
{
    protected $stmt;

    public function __construct($pdo) {
        $this->stmt = $pdo;
    }

    public function fetch($fetchStyle = \PDO::FETCH_ASSOC) {
        return $this->stmt->fetch($fetchStyle);
    }

    public function fetchAll($fetchStyle = \PDO::FETCH_ASSOC) {
        return $this->stmt->fetchAll($fetchStyle);
    }

    public function bindParam($parameter, &$variable, $data_type = \PDO::PARAM_STR, $length) {
        return $this->stmt->bindParam($parameter, $variable, $data_type, $length);
    }

    public function execute($input_parameters) {
        return $this->stmt->execute($input_parameters);
    }

    public function rowCount() {
        return $this->stmt->rowCount();
    }
}