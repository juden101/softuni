<?php

/*
* PDO database class - only one connection allowed
*/
class Database {
    private $_connection;
    private static $_instance; //The single instance
    private $_host = "mysql:host=localhost;dbname=todo_list";
    private $_username = "root";
    private $_password = "";

    private function __construct() {
        $this->_connection = new PDO(
            $this->_host,
            $this->_username,
            $this->_password,
            array(PDO::MYSQL_ATTR_INIT_COMMAND => "SET NAMES 'utf8'"));
    }

    /*
    Get an instance of the Database
    @return Instance
    */
    public static function getInstance() {
        if(!self::$_instance) {
            self::$_instance = new self();
        }

        return self::$_instance;
    }

    private function __clone() {
    }

    public function getConnection() {
        return $this->_connection;
    }
}