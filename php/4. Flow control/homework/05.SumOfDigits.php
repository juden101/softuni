<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Sum Of Digits</title>
    <link rel="stylesheet" type="text/css" href="table-style.css" />
</head>
<body>
    <?php
    $numbersInput = '';
    $digitsSum = [];

    if(isset($_POST['numbers']) && $_POST['numbers'] != '') {
        $numbersInput = $_POST['numbers'];
        $splitNumbers = explode(',', $numbersInput);

        foreach($splitNumbers as $number) {
            $currentNumber = trim($number);
            $currentSum = 0;

            if(is_numeric($currentNumber)) {
                for($i = 0; $i <= strlen($currentNumber); $i++) {
                    $char = substr($currentNumber, $i, 1);
                    $currentSum += (int)$char;
                }
            }
            else {
                $currentSum = 'I cannot sum that';
            }

            $digitsSum[] = [
                'number' => $currentNumber,
                'sum' => $currentSum
            ];
        }
    }
    ?>

    <form method="POST">
        <label for="numbers">Input string:</label>
        <input type="text" name="numbers" id="numbers" value="<?= $numbersInput;?>" />
        <input type="submit" value="Submit" />
    </form>

    <?php
    if(isset($digitsSum) && count($digitsSum) > 0) {
    ?>
        <table>
        <?php
            foreach($digitsSum as $currentNumber) {
            ?>
            <tr>
                <td><?= $currentNumber['number'];?></td>
                <td><?= $currentNumber['sum'];?></td>
            </tr>
            <?php
            }
        ?>
        </table>
    <?php
    }
    ?>
</body>
</html>