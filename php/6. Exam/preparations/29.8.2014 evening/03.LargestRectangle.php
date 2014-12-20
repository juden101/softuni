<?php

$jsonTable = $_GET['jsonTable'];
$matrix = json_decode($jsonTable);

$tableWidth = sizeof($matrix[0]);
$tableHeight = sizeof($matrix);

$biggestRectangle = [
    'startRow' => 0,
    'startColumn' => 0,
    'width' => 1,
    'height' => 1,
    'area' => 1
];

for ($i = 0; $i < $tableHeight ; $i++) {
    for ($j = 0; $j < $tableWidth; $j++) {
        for ($k = $i; $k < $tableHeight; $k++) {
            for ($l = $j; $l < $tableWidth ; $l++) {
                $isRectangle = isRectangle($i, $j, $k, $l, $matrix);

                if($isRectangle) {
                    rectangleUpdate($i, $j, $k, $l, $biggestRectangle);
                }
            }
        }
    }
}

$table = "<table border='1' cellpadding='5'>";
for ($i = 0; $i < $tableHeight; $i++) {
    $table .= "<tr>";
    for ($j=0; $j < $tableWidth; $j++) {
        if(isOnBorder($i, $j, $biggestRectangle)){
            $table .= "<td style='background:#CCC'>" . htmlspecialchars($matrix[$i][$j]) . "</td>";
        }
        else{
            $table .= "<td>" . htmlspecialchars($matrix[$i][$j]) . "</td>";
        }
    }
    $table .= "</tr>";
}
$table .= "</table>";
echo $table;

function isRectangle($startRow, $startColumn, $endRow, $endColumn, $matrix) {
    $symbol = $matrix[$startRow][$startColumn];

    for ($i = $startRow; $i <= $endRow; $i++) {
        if(($matrix[$i][$startColumn] != $symbol) || ($matrix[$i][$endColumn] != $symbol)){
            return false;
        }
    }

    for ($i = $startColumn; $i <= $endColumn; $i++) {
        if(($matrix[$startRow][$i] != $symbol) || ($matrix[$endRow][$i] != $symbol)){
            return false;
        }
    }

    return true;
}

function rectangleUpdate($startRow, $startColumn, $endRow, $endColumn, &$biggestRectangle){
    $height = $endRow - $startRow + 1;
    $width = $endColumn - $startColumn + 1;
    $area = $width * $height;

    if($area > $biggestRectangle['area']) {
        $biggestRectangle['startRow'] = $startRow;
        $biggestRectangle['startColumn'] = $startColumn;
        $biggestRectangle['width'] = $width;
        $biggestRectangle['height'] = $height;
        $biggestRectangle['area'] = $area;
    }

}
function isOnBorder($row, $column, $biggestRectangle) {
    $startRow = $biggestRectangle['startRow'];
    $endRow = $biggestRectangle['startRow'] + $biggestRectangle['height'] - 1;
    $startColumn = $biggestRectangle['startColumn'];
    $endColumn = $biggestRectangle['startColumn'] + $biggestRectangle['width'] - 1;

    if(((($row == $startRow) || ($row == $endRow)) && ($column >= $startColumn) && ($column <= $endColumn)) || ((($column == $startColumn) || ($column == $endColumn)) && ($row >= $startRow) && ($row <= $endRow))) {
        return true;
    }
    else{
        return false;
    }
}