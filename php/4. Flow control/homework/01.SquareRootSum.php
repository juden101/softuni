<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Square Root Sum</title>
    <link rel="stylesheet" type="text/css" href="table-style.css" />
</head>
<body>
    <table>
        <tr class="title">
            <td class="title">Number</td>
            <td class="title">Square</td>
        </tr>

        <?php
            $sumOfAllRoots = 0;

            for($n = 0; $n <= 100; $n++) {
                if($n % 2 == 0) {
                    $squareRootOfN = sqrt($n);
                    $squareRootOfN = (float)round($squareRootOfN, 2);

                    $sumOfAllRoots += $squareRootOfN;

                ?>
                    <tr>
                        <td><?= $n;?></td>
                        <td><?= $squareRootOfN;?></td>
                    </tr>
                <?php
                }
            }

            $sumOfAllRoots = (float)round($sumOfAllRoots, 2);
        ?>
        <tr class="title">
            <td>Total:</td>
            <td><?= $sumOfAllRoots;?></td>
        </tr>
    </table>
</body>
</html>