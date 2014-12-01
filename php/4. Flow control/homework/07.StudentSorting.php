<?php

class Student {

    private $firstName;
    private $lastName;
    private $email;
    private $examScore;

    public function __construct($firstName, $lastName, $email, $examScore) {
        $this->firstName = $firstName;
        $this->lastName = $lastName;
        $this->email = $email;
        $this->examScore = $examScore;
    }

    public function __get($name) {
        return $this->$name;
    }

}

?>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Student Sorting</title>
    <link rel="stylesheet" type="text/css" href="table-style.css" />
</head>
<body>
    <?php
        $studentsResult = [];
        $sortBy = '';
        $order = '';
        $studentsAverageScore = 0;

        $allFilled = true;

        if(isset($_POST) && count($_POST) > 0) {
            for ($i = 0; $i < count($_POST['firstName']); $i++) {
                if (!isset($_POST['firstName'][$i], $_POST['lastName'][$i], $_POST['email'][$i], $_POST['examScore'][$i]) ||
                    $_POST['firstName'][$i] == '' || $_POST['lastName'][$i] == '' || $_POST['email'][$i] == '' || $_POST['examScore'][$i] == '') {
                    $allFilled = false;
                }
            }

            if(isset($_POST['sortBy'], $_POST['order']) && $allFilled && $_POST['sortBy'] != '' && $_POST['order'] != '') {
                $sortBy = $_POST['sortBy'];
                $order = $_POST['order'];
                for($i = 0; $i < count($_POST['firstName']); $i++) {
                    $firstName = $_POST['firstName'][$i];
                    $lastName = $_POST['lastName'][$i];
                    $email = $_POST['email'][$i];
                    $examScore = $_POST['examScore'][$i];
                    $studentsAverageScore += $examScore;

                    $studentsResult[] = new Student($firstName, $lastName, $email, $examScore);
                }
                $studentsAverageScore = (int)($studentsAverageScore / count($_POST['firstName']));

                usort($studentsResult, function($a, $b) use ($sortBy) {
                    return strcmp($a->$sortBy, $b->$sortBy);
                });

                if($order == 'descending') {
                    rsort($studentsResult);
                }
            }
        }
    ?>
    <form method="POST" id="formRows">
    <table>
        <tr class="title">
            <td>First name:</td>
            <td>Last name:</td>
            <td>Email:</td>
            <td>Exam score:</td>
        </tr>

        <?php
        if(isset($studentsResult) && count($studentsResult) > 0) {
            foreach($studentsResult as $student) {
            ?>
            <tr>
                <td><?= $student->firstName;?></td>
                <td><?= $student->lastName;?></td>
                <td><?= $student->email;?></td>
                <td><?= $student->examScore;?></td>
            </tr>
            <?php
            }
            ?>

            <tr>
                <td colspan="3">Average score:</td>
                <td><?= $studentsAverageScore;?></td>
            </tr>
        <?php
        }
        else {
        ?>
        <tr>
            <td><input type="text" name="firstName[]"/></td>
            <td><input type="text" name="lastName[]"/></td>
            <td><input type="email" name="email[]"/></td>
            <td><input type="number" name="examScore[]"/></td>
            <td>
                <button onClick="removeRow(this); return false;">-</button>
            </td>
        </tr>

        <tr>
            <td>
                <button id="addRow">+</button>
            </td>
            <td>
                <label for="sortBy">Sort by:</label>

                <select name="sortBy" id="sortBy">
                    <option value="firstName">First name</option>
                    <option value="lastName">Last name</option>
                    <option value="email">Email</option>
                    <option value="examScore">Exam score</option>
                </select>
            </td>
            <td>
                <label for="order">Order:</label>

                <select name="order" id="order">
                    <option value="ascending">Ascending</option>
                    <option value="descending">Descending</option>
                </select>
            </td>
            <td>
                <input type="submit" value="Submit"/>
            </td>
        </tr>
        <?php
        }
        ?>
    </table>
    </form>

    <script type="text/javascript">
        var addRowButton = document.getElementById('addRow');
        addRowButton.addEventListener('click', function(e) {
            e.preventDefault();

            var newRow = document.createElement('tr');

            newRow.innerHTML = '\
            <td><input type="text" name="firstName[]" /></td>\
            <td><input type="text" name="lastName[]" /></td>\
            <td><input type="email" name="email[]" /></td>\
            <td><input type="number" name="examScore[]" /></td>\
            <td><button onClick="removeRow(this); return false;">-</button></td>';

            var table = document.getElementsByTagName('table')[0].getElementsByTagName('tbody')[0];
            table.insertBefore(newRow, table.childNodes[table.childNodes.length - 2]);
        });

        function removeRow(button) {
            var table = document.getElementsByTagName('table')[0].getElementsByTagName('tbody')[0];
            var rowsCount = table.childNodes.length - 5;

            if(rowsCount > 1) {
                button.parentNode.parentNode.remove();
            }
        }
    </script>
</body>
</html>