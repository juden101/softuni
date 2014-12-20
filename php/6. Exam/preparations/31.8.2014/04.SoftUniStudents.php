<?php

$students_rows = $_GET['students'];
$column = $_GET['column'];
$order = $_GET['order'];

preg_match_all('/^.*$/m', $students_rows, $matches);
$students = [];

for ($i = 0; $i < count($matches[0]); $i++) {
    $props = explode(', ', $matches[0][$i]);

    $students[] = [
        'id' => $i + 1,
        'username' => $props[0],
        'email' => $props[1],
        'type' => $props[2],
        'result' => (int)$props[3]
    ];
}

usort($students, function ($a, $b) use ($column) {
    if($column == 'id') {
        return $a['id'] - $b['id'];
    }
    else if($column == 'username') {
        if ($a[$column] == $b[$column]) {
            return $a['id'] - $b['id'];
        }

        return strcmp($a[$column], $b[$column]);
    }
    else {
        if ($a[$column] == $b[$column]) {
            return $a['id'] - $b['id'];
        }

        return $a[$column] - $b[$column];
    }
});

if($order == 'descending') {
    $students = array_reverse($students);
}

echo '<table><thead><tr><th>Id</th><th>Username</th><th>Email</th><th>Type</th><th>Result</th></tr></thead>';
foreach($students as $student) {
    echo '<tr><td>' . $student['id'] . '</td><td>' . htmlspecialchars($student['username']) . '</td><td>' . htmlspecialchars($student['email']) . '</td><td>' . htmlspecialchars($student['type']) . '</td><td>' . htmlspecialchars($student['result']) . '</td></tr>';
}
echo '</table>';