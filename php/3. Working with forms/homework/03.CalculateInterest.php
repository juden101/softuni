<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Calculate Interest</title>
</head>
<body>
    <form method="POST">
        <section>
            <label for="amount">Enter Amount</label>
            <input type="number" name="amount" id="amount" />
        </section>
        <section>
            <input type="radio" name="currency" id="usd" value="usd" checked />
            <label for="usd">USD</label>
            <input type="radio" name="currency" id="eur" value="eur" />
            <label for="eur">EUR</label>
            <input type="radio" name="currency" id="bgn" value="bgn" />
            <label for="bgn">BGN</label>
        </section>
        <section>
            <label for="interest">Compound Interest Amount</label>
            <input type="number" name="interest" id="interest" />
        </section>
        <section>
            <select name="period">
                <option value="6">6 Months</option>
                <option value="12">1 Year</option>
                <option value="24">2 Years</option>
                <option value="60">5 Years</option>
            </select>
            <input type="submit" value="Submit" />
        </section>
    </form>
    <?php

    if(isset($_POST['amount'], $_POST['currency'], $_POST['interest'], $_POST['period']) &&
        $_POST['amount'] != null && $_POST['currency'] != null && $_POST['interest'] != null && $_POST['period'] != null) {

        $amount = $_POST['amount'];
        $currency = $_POST['currency'];
        $interest = $_POST['interest'];
        $period = $_POST['period'];

        $result = round($amount * pow(1 + (($interest / 100) / 12), $period / 12 * 12), 2);

        if($currency == 'usd') {
            $result = '$ ' . $result;
        }
        else if($currency == 'eur') {
            $result = '€ ' . $result;
        }
        else {
            $result .= " Lv.";
        }

        echo $result;
    }
    ?>
</body>
</html>