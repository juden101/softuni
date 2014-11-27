<?php

function getVariableType($variable) {
    $variableType = gettype($variable);

    if($variableType == 'integer' || $variableType == 'double' || $variableType == 'float') {
        var_dump($variable);
    }
    else {
        echo $variableType . PHP_EOL;
    }
}

getVariableType("hello");
getVariableType(15);
getVariableType(1.234);
getVariableType(array(1,2,3));
getVariableType((object)[2,34]);