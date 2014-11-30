<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Annual Expenses</title>
    <link rel="stylesheet" type="text/css" href="table-style.css" />
</head>
<body>
<?php
$inputYears = '';
$months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
$yearsAnnualExpenses = [];

if(isset($_POST['years']) && $_POST['years'] != '') {
    $inputYears = $_POST['years'];

    $currentYear = date("Y");
    for($i = $currentYear; $i > $currentYear - $inputYears; $i--) {
        $yearsAnnualExpenses[$i] = [];

        $totalSum = 0;
        foreach ($months as $month) {
            $yearsAnnualExpenses[$i][$month] = mt_rand(1, 999);
            $totalSum += $yearsAnnualExpenses[$i][$month];
        }
        $yearsAnnualExpenses[$i]['total'] = $totalSum;
    }
}
?>

<form method="POST">
    <input type="text" name="years" value="<?= $inputYears;?>" />
    <input type="submit" value="Show costs" />
</form>

<?php
if(isset($yearsAnnualExpenses) && count($yearsAnnualExpenses) > 0) {
?>
    <table>
        <tr>
            <td class="title">Year</td>

            <?php
            foreach($months as $month):
            ?>
                <td class="title"><?= $month;?></td>
            <?php
            endforeach;
            ?>

            <td class="title">Total</td>
        </tr>

        <?php
        foreach($yearsAnnualExpenses as $year => $yearAnnualExpenses):
        ?>
            <tr>
                <td><?= $year;?></td>

                <?php
                foreach($yearAnnualExpenses as $monthAnnualExpenses):
                ?>
                    <td><?= $monthAnnualExpenses;?></td>
                <?php
                endforeach;
                ?>
            </tr>
        <?php
        endforeach;
        ?>
    </table>
<?php
}
?>
</body>
</html>