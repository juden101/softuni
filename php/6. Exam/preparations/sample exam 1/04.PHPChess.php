<?php

$chessBoard = [];
$figuresCount = [];
$figureNames = [
    'B' => 'Bishop',
    'H' => 'Horseman',
    'K' => 'King',
    'P' => 'Pawn',
    'Q' => 'Queen',
    'R' => 'Rook',
    ' ' => ' ',
];

$board = explode('/', $_GET['board']);
if(count($board) != 8) {
    invalidChessBoard();
}

foreach($board as $rowCount => $row) {
    $figures = explode('-', $row);

    if(count($figures) != 8) {
        invalidChessBoard();
    }

    foreach($figures as $figureCount => $figure) {
        if(!array_key_exists($figure, $figureNames)) {
            invalidChessBoard();
        }

        $chessBoard[$rowCount][$figureCount] = $figure;

        if($figure != ' ') {
            if(!isset($figuresCount[$figureNames[$figure]])) {
                $figuresCount[$figureNames[$figure]] = 0;
            }
            $figuresCount[$figureNames[$figure]]++;
        }
    }
}

echo '<table>';
for($row = 0; $row < count($chessBoard); $row++) {
    echo '<tr>';
    for($figure = 0; $figure < count($chessBoard[$row]); $figure++) {
        echo '<td>' . $chessBoard[$row][$figure] . '</td>';
    }
    echo '</tr>';
}
echo '</table>';

ksort($figuresCount);

echo json_encode($figuresCount);

function invalidChessBoard() {
    die('<h1>Invalid chess board</h1>');
}