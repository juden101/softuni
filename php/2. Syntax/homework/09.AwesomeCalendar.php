<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>Awesome Calendar</title>
    <style>
        body {
            font-family: Verdana, sans-serif;
        }

        div.content {
            width: 615px;
            position:relative;
            margin: 0 auto;
        }

        h2.mainHeading {
            text-align:center;
        }

        input.year {
            border: none;
            font-size: 44px;
            width: 107px;
            outline: none 0;
            text-align: center;
            margin: 0 auto;
            display: block;
            font-weight: bold;
        }

        div.month {
            display:inline;
            font-size:0.7em;
            padding: 10px;
            float:left;
            position:relative;
            height:130px;
        }

        .month table caption, .month table th,  h2.mainHeading {
            border-bottom: 1px solid black;
        }

        table {
            width: 22%;
            display: inline-table;
            border-collapse: collapse;
            margin: 1%;
        }

        table thead tr:nth-of-type(2) th {
            border-bottom: solid 1px #000;
            border-top: solid 1px #000;
        }

        table td, table thead tr th {
            width: 14.28%;
            text-align: right;
        }
    </style>
</head>
<body>
    <?php
    function getDates($year) {
        $dates = array();
        $leapYear = (date('L', strtotime((string)$year)) == 1) ? true : false;
        $days = ($leapYear) ? 366 : 365;

        for($i = 1; $i <= $days; $i++) {
            $month = date('n', mktime(0, 0, 0, 1, $i, $year));
            $wk = date('W', mktime(0, 0, 0, 1, $i, $year));
            $wkDay = date('D', mktime(0, 0, 0, 1, $i, $year));
            $day = date('d', mktime(0, 0, 0, 1, $i, $year));
            $dates[$month][$wk][$wkDay] = $day;
        }

        return $dates;
    }

    $year = (int)date('Y');
    $dates = getDates($year);
    $weekdays = array('По' => 'Mon', 'Вт' => 'Tue', 'Ср' => 'Wed', 'Чт' => 'Thu', 'Пе' => 'Fri', 'Сб' => 'Sat', 'Не' => 'Sun');
    $bgMonths = array('Януари', 'Февруари', 'Март', 'Април', 'Май', 'Юни', 'Юли', 'Август', 'Септември', 'Октомври', 'Ноември', 'Декември');
    ?>
    <div class="content">
        <h2 class="mainHeading">2014</h2>
        <?php foreach($dates as $month => $weeks) { ?>
            <div  class="month">
                <table>
                    <caption><?= $bgMonths[$month-1];?></caption>
                    <thead>
                        <tr>
                            <?php $i = 0; foreach($weekdays as $bg => $en){ ?>
                            <th <?= ($i+1 == count($weekdays))? 'style="color:red;"': '' ?>><?php echo $bg;?></th>
                            <?php $i++;}?>
                        </tr>
                    </thead>
                    <?php foreach($weeks as $week => $days){ ?>
                        <tr>
                            <?php foreach($weekdays as $day) { ?>
                                <td>
                                    <?= (array_key_exists($day, $days)) ? $days[$day] : '&nbsp';?>
                                </td>
                            <?php } ?>
                        </tr>
                    <?php } ?>
                </table>
            </div>
        <?php } ?>
    </div>
</body>
</html>