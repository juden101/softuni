<!DOCTYPE html>
<html>
<head>
    <title>HTML Table</title>
    <style>
        table {
            margin-top: 10px;
            border-collapse: collapse;
        }

        table tr td {
            padding: 5px;
            border: 1px solid #000;
            text-align: right;
        }

        table tr td:first-child {
            background: orange;
            font-weight: bold;
            text-align: left;
        }
    </style>
</head>
<body>
    <?php

    function generateTable($name, $phone, $age, $address) {
    ?>
        <table>
            <tr><td>Name</td><td><?= $name?></td></tr>
            <tr><td>Phone number</td><td><?= $phone?></td></tr>
            <tr><td>Age</td><td><?= $age?></td></tr>
            <tr><td>Address</td><td><?= $address?></td></tr>
        </table>
    <?php
    }

    generateTable('Gosho', '0882-321-423', 24, 'Hadji Dimitar');
    generateTable('Pesho', '0884-888-888', 67, 'Suhata Reka');
    ?>
</body>
</html>