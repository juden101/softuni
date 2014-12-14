<?php

$db = [];
$allCommands = $_GET['commands'];
$errors = 0;
$user_id_ai = 0;
$tableKeys = [ 'user_id', 'login', 'age', 'gender' ];

foreach($allCommands as $command) {
    $splitCommand = explode(' ', $command);

    if($splitCommand[0] == 'INSERT' && $splitCommand[1] == 'INTO') {
        $table = $splitCommand[2];

        preg_match_all('/\((.+?)\)/', $command, $matches);
        $fields = explode(', ', $matches[1][0]);

        if(!isset($matches[1][1]) || $matches[1][1] == '') {
            $errors++;
            continue;
        }
        $values = explode(', ', $matches[1][1]);

        if(count($fields) != count($values)) {
            $errors++;
            continue;
        }

        if(!isset($db[$table])) {
            $db[$table] = [];
        }

        $dbRow = array_combine($fields, $values);

        if(!isset($dbRow['login'])) {
            $errors++;
            continue;
        }
        !isset($dbRow['user_id']) ? $dbRow['user_id'] = $user_id_ai : null;
        !isset($dbRow['age']) ? $dbRow['age'] = 'undefined' : null;
        !isset($dbRow['gender']) ? $dbRow['gender'] = 'undefined' : null;

        $db[$table][] = $dbRow;

        $user_id_ai = $dbRow['user_id'] + 1;
    }
    else if($splitCommand[0] == 'UPDATE') {
        $table = $splitCommand[1];

        preg_match_all('/\((.+?)\)/', $command, $matches);
        $set = explode('=', $matches[1][0]);
        $where = explode('=', $matches[1][1]);

        $setKey = trim($set[0]);
        $setValue = trim($set[1]);

        if(!in_array($setKey, $tableKeys)) {
            $errors++;
            continue;
        }

        $whereKey = trim($where[0]);
        $whereValue = trim($where[1]);

        if(!in_array($whereKey, $tableKeys)) {
            $errors++;
            continue;
        }

        if(isset($db[$table]) && count($db[$table]) > 0) {
            $updated = false;

            foreach($db[$table] as $rowKey => $row) {
                if($row[$whereKey] == $whereValue) {
                    if($setKey != 'user_id') {
                        $db[$table][$rowKey][$setKey] = $setValue;
                        $updated = true;
                        break;
                    }
                }
            }

            if(!$updated) {
                $errors++;
                continue;
            }
        }
        else {
            $errors++;
            continue;
        }
    }
    else if($splitCommand[0] == 'DELETE' && $splitCommand[1] == 'FROM') {
        $table = $splitCommand[2];

        preg_match_all('/\((.+?)\)/', $command, $matches);
        $result = explode('=', $matches[1][0]);

        $field = trim($result[0]);
        $value = trim($result[1]);

        if($field == 'login' || !in_array($field, $tableKeys)) {
            $errors++;
            continue;
        }

        if(isset($db['users']) && count($db['users']) > 0) {
            foreach($db[$table] as $rowKey => $row) {
                if(isset($row[$field])) {
                    if($row[$field] == $value) {
                        $found = true;
                        unset($db[$table][$rowKey]);
                    }
                }
            }
        }
    }
    else {
        $errors++;
    }
}

if(isset($db['users']) && count($db['users']) > 0) {
    echo '<table><thead><tr><th>user_id</th><th>login</th><th>gender</th><th>age</th></tr></thead><tbody>';
    foreach($db['users'] as $row) {
        echo "<tr><td>{$row['user_id']}</td><td>{$row['login']}</td><td>{$row['gender']}</td><td>{$row['age']}</td></tr>";
    }
    echo "</tbody><tfoot><tr><td colspan=\"4\">Errors={$errors}</td></tr></tfoot></table>";
}
else {
    echo "You have {$errors} error/s";
}