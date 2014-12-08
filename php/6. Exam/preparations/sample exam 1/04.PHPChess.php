<?php

$_GET['board'] = 'R-H-B-K-Q-B-H-R/P-P- -P-P- -P-P/ - -P- - - - - / - - - - -P- - / - - - - - - - / -P- - - - - -H/P- -P-P-P-P-P-P/R-H-B-K-Q-B- -R';

$board = explode('/', $_GET['board']);

if(count($board) != 8) {
    invalidChessBoard();
}

function invalidChessBoard() {
    die('<h1>Invalid chess board</h1>');
}