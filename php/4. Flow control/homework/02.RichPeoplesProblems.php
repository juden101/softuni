<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Car Randomizer</title>
    <link rel="stylesheet" type="text/css" href="table-style.css" />
</head>
<body>
    <?php
    $inputCars = '';
    $cars = [];
    $colors = ['white', 'gray', 'pink', 'red', 'brown', 'orange', 'yellow', 'green', 'cyan', 'blue', 'violet'];

    if(isset($_POST['cars']) && $_POST['cars'] != '') {
        $inputCars = $_POST['cars'];

        $separatedCars = explode(',', $inputCars);
        foreach($separatedCars as $car) {
            $cars[] = [
                'model' => trim($car),
                'color' => $colors[mt_rand(0, count($colors) - 1)],
                'count' => mt_rand(0, 5)
            ];
        }
    }
    ?>

    <form method="POST">
        <input type="text" name="cars" value="<?= $inputCars;?>" />
        <input type="submit" value="Show result" />
    </form>

    <?php
    if(isset($cars) && count($cars) > 0) {
    ?>
        <table>
            <tr class="title">
                <td class="title">Car</td>
                <td class="title">Color</td>
                <td class="title">Count</td>
            </tr>

            <?php
            foreach($cars as $car):
            ?>
                <tr>
                    <td><?= $car['model'];?></td>
                    <td><?= $car['color'];?></td>
                    <td><?= $car['count'];?></td>
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