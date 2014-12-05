<?php

class Seminar {

    private $name;
    private $lecturersName;
    private $date;
    private $info;

    public function __construct($name, $lecturersName, $date, $info) {
        $this->name = $name;
        $this->lecturersName = $lecturersName;
        $this->date = $date;
        $this->info = $info;
    }

    public function __get($property) {
        if($this->$property != null) {
            return $this->$property;
        }
    }

}

?>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>SoftUni Seminar Generator</title>
    <style>
        textarea {
            display: block;
            margin-bottom: 5px;
        }

        span.title {
            text-decoration: underline;
            font-weight: bold;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="table-style.css" />
    <link rel="stylesheet" type="text/css" href="tipped.css" />

    <script type="text/javascript" src="http://code.jquery.com/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="tipped.js"></script>
</head>
<body>
<form method="POST">
    <textarea name="text" rows="15" cols="120" placeholder="Seminars..."><?= isset($_POST['text']) && $_POST['text'] != '' ? $_POST['text'] : null;?></textarea>

    <label for="sort">Sort by:</label>
    <select name="sort" id="sort">
        <option value="name" <?= isset($_POST['sort']) && $_POST['sort'] != null && $_POST['sort'] == 'name' ? 'selected' : null;?>>Name</option>
        <option value="date" <?= isset($_POST['sort']) && $_POST['sort'] != null && $_POST['sort'] == 'date' ? 'selected' : null;?>>Date</option>
    </select>

    <label for="order">Order by:</label>
    <select name="order" id="order">
        <option value="descending" <?= isset($_POST['order']) && $_POST['order'] != null && $_POST['order'] == 'descending' ? 'selected' : null;?>>Descending</option>
        <option value="ascending" <?= isset($_POST['order']) && $_POST['order'] != null && $_POST['order'] == 'ascending' ? 'selected' : null;?>>Ascending</option>
    </select>

    <input type="submit" value="Generate seminars" />
</form>

<?php
if(isset($_POST['text']) && $_POST['text'] != '') {

    $sortBy = $_POST['sort'];
    $orderBy = $_POST['order'];

    $allSeminars = [];
    $rawSeminars = explode("\n", $_POST['text']);
    $seminarRegex = '/([\w\s\.\,]+)-([\w\s\.\,]+)-([0-9]{1,2}-[0-9]{1,2}-[0-9]{1,4}\s[0-9]{1,2}:[0-9]{1,2})\s(.+)/';

    foreach($rawSeminars as $seminar) {
        preg_match($seminarRegex, $seminar, $seminarProperties);

        if(count($seminarProperties) > 0) {
            $seminarName = $seminarProperties[1];
            $seminarLecturersName = $seminarProperties[2];
            $seminarDate = $seminarProperties[3];
            $seminarInfo = $seminarProperties[4];

            $allSeminars[] = new Seminar($seminarName, $seminarLecturersName, $seminarDate, $seminarInfo);
        }
    }

    usort($allSeminars, function($a, $b) use ($sortBy) {
        if($sortBy == 'date') {
            $datePattern = "m-d-Y H:i";

            $date1 = date($datePattern, strtotime($a->date));
            $date2 = date($datePattern, strtotime($b->date));

            return strcmp($date1, $date2);
        }

        return strcmp($a->$sortBy, $b->$sortBy);
    });

    if($orderBy == 'descending') {
        $allSeminars = array_reverse($allSeminars, true);
    }

?>
    <table>
        <tr class="title">
            <td>Seminar name</td>
            <td>Date</td>
            <td>Participate</td>
        </tr>

        <?php
        if(isset($allSeminars) && count($allSeminars) > 0):
            foreach($allSeminars as $seminar):
                ?>
                <tr>
                    <td><a href="#" class="tooltip" title="<p><span class=title>Lecturer:</span> <?= $seminar->lecturersName;?></p><p><span class=title>Details:</span> <?= addslashes(htmlentities($seminar->info));?></p>"><?= $seminar->name;?></a></td>
                    <td><?= $seminar->date;?></td>
                    <td><a href="#" class="participate">Sign up</a></td>
                </tr>
            <?php
            endforeach;
            ?>
        <?php
        endif;
        ?>
    </table>
<?php
}
?>
    <script type="text/javascript">
        $(document).ready(function() {
            Tipped.create('.tooltip');
        });
    </script>
</body>
</html>