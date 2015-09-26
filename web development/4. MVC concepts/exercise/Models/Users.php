<?php

namespace SoftUni\Models;

use SoftUni\Core\Database;
use SoftUni\BindingModels;

class Users
{
    private $user = null;

    const GOLD_DEFAULT = 1500;
    const FOOD_DEFAULT = 1500;

    public function register($username, $password)
    {
        $db = Database::getInstance('app');

        if($this->exists($username)) {
            throw new \Exception("User already registered");
        }

        $result = $db->prepare("
            INSERT INTO users (username, password, gold, food)
            VALUES (?, ?, ?, ?)
        ");

        $result->execute(
            [
                $username,
                password_hash($password, PASSWORD_DEFAULT),
                self::GOLD_DEFAULT,
                self::FOOD_DEFAULT
            ]
        );

        if ($result->rowCount() > 0)
        {
            $user_id = $db->lastId();

            $db->query("
                INSERT INTO user_buildings (user_id, building_id, level)
                SELECT $user_id, id, 0 FROM buildings
            ");

            return true;
        }

        throw new \Exception('Cannot register user');
    }

    public function exists($username) {
        $db = Database::getInstance('app');

        $result = $db->prepare("SELECT id FROM users WHERE username = ?");
        $result->execute([ $username ]);

        return $result->rowCount() > 0;
    }

    public function login($username, $password)
    {
        $db = Database::getInstance('app');

        $result = $db->prepare("SELECT * FROM users WHERE username = ?");

        $result->execute(
            [
                $username
            ]
        );

        if ($result->rowCount() == 0) {
            throw new \Exception("Invalid user!");
        }

        $userRow = $result->fetch();

        if (password_verify($password, $userRow['password'])) {
            return $userRow['id'];
        }

        throw new \Exception("Password does not match");
    }

    public function getInfo($id) {
        $db = Database::getInstance('app');

        $result = $db->prepare("
            SELECT id, username, password, gold, food
            FROM users
            WHERE id = ?");

        $result->execute([ $id ]);

        return $result->fetch();
    }

    public function get($user_id) {
        if ($this->user != null) {
            return $this->user;
        }

        $userRow = $this->getInfo($user_id);

        $this->user = new \stdClass();
        $this->user->username = $userRow['username'];
        $this->user->password = $userRow['password'];
        $this->user->id = $userRow['id'];
        $this->user->gold = $userRow['gold'];
        $this->user->food = $userRow['food'];

        return $this->user;
    }

    public function edit($user) {
        $db = Database::getInstance('app');

        $result = $db->prepare("UPDATE users SET password = ?, username = ? WHERE id = ?");
        $result->execute([
            $user->getPass(),
            $user->getUsername(),
            $user->getId()
        ]);

        return $result->rowCount() > 0;
    }

    public function createBuildings($user_id) {
        $db = Database::getInstance('app');

        $result = $db->prepare("
            SELECT b.id, b.name, bl.level, bl.gold, bl.food
            FROM users_buildings ub
            LEFT JOIN buildings b ON b.id = ub.building_id
            LEFT JOIN building_levels bl ON bl.building_id = b.id AND bl.level = ub.level + 1
            WHERE user_id = ?");

        $result->execute([ $user_id ]);

        return $result->fetchAll();
    }
}