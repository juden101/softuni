<?php

namespace SoftUni\Models;

use SoftUni\Core\Database;
use SoftUni\BindingModels;

class Todos
{
    public function getTodoItems($user_id) {
        $db = Database::getInstance('app');

        $result = $db->prepare("
            SELECT *
            FROM todos
            WHERE user_id = ?");

        $result->execute([ $user_id ]);

        return $result->fetch();
    }

    public function addTodoItem($user_id, $todo_text) {
        $db = Database::getInstance('app');

        $result = $db->prepare("
            INSERT INTO todos (user_id, todo_item)
            VALUES (?, ?)
        ");

        $result->execute(
            [
                $user_id,
                $todo_text
            ]
        );

        if ($result->rowCount() > 0)
        {
            $todo_id = $db->lastId();
            return $todo_id;
        }

        throw new \Exception('Cannot add todo item');
    }

    public function deleteTodoItem($user_id, $todo_id) {
        $db = Database::getInstance('app');

        $result = $db->prepare("
            DELETE FROM todos
            WHERE user_id = ? AND id = ?");

        $result->execute([ $user_id, $todo_id ]);
    }
}