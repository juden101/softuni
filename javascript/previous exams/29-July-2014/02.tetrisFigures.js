function solve(input) {
    var field = input;
    var tetriminosCount = {
        'I': 0,
        'L': 0,
        'J': 0,
        'O': 0,
        'Z': 0,
        'S': 0,
        'T': 0
    }

    //I
    for(var i = 0; i < field.length - 3; i++) {
        var row1 = field[i];
        var row2 = field[i + 1];
        var row3 = field[i + 2];
        var row4 = field[i + 3];

        for(var cell = 0; cell < field[i].length; cell++) {
            if(row1[cell] == 'o' && row2[cell] == 'o' && row3[cell] == 'o' && row4[cell] == 'o') {
                tetriminosCount['I']++;
            }
        }
    }

    //L
    for(var i = 0; i < field.length - 2; i++) {
        var row1 = field[i];
        var row2 = field[i + 1];
        var row3 = field[i + 2];

        for(var cell = 0; cell < field[i].length - 1; cell++) {
            if(row1[cell] == 'o' && row2[cell] == 'o' && row3[cell] == 'o' && row3[cell + 1] == 'o') {
                tetriminosCount['L']++;
            }
        }
    }

    //J
    for(var i = 0; i < field.length - 2; i++) {
        var row1 = field[i];
        var row2 = field[i + 1];
        var row3 = field[i + 2];

        for(var cell = 1; cell < field[i].length; cell++) {
            if(row1[cell] == 'o' && row2[cell] == 'o' && row3[cell] == 'o' && row3[cell - 1] == 'o') {
                tetriminosCount['J']++;
            }
        }
    }

    //O
    for(var i = 0; i < field.length - 1; i++) {
        var row1 = field[i];
        var row2 = field[i + 1];

        for(var cell = 1; cell < field[i].length; cell++) {
            if(row1[cell] == 'o' && row2[cell] == 'o' && row1[cell - 1] == 'o' && row2[cell - 1] == 'o') {
                tetriminosCount['O']++;
            }
        }
    }

    //Z
    for(var i = 0; i < field.length - 1; i++) {
        var row1 = field[i];
        var row2 = field[i + 1];

        for(var cell = 1; cell < field[i].length - 1; cell++) {
            if(row1[cell] == 'o' && row2[cell] == 'o' && row1[cell - 1] == 'o' && row2[cell + 1] == 'o') {
                tetriminosCount['Z']++;
            }
        }
    }

    //S
    for(var i = 0; i < field.length - 1; i++) {
        var row1 = field[i];
        var row2 = field[i + 1];

        for(var cell = 1; cell < field[i].length - 1; cell++) {
            if(row1[cell] == 'o' && row2[cell] == 'o' && row1[cell + 1] == 'o' && row2[cell - 1] == 'o') {
                tetriminosCount['S']++;
            }
        }
    }


    //T
    for(var i = 0; i < field.length - 1; i++) {
        var row1 = field[i];
        var row2 = field[i + 1];

        for(var cell = 1; cell < field[i].length - 1; cell++) {
            if(row1[cell] == 'o' && row2[cell] == 'o' && row1[cell - 1] == 'o' && row1[cell + 1] == 'o') {
                tetriminosCount['T']++;
            }
        }
    }

    console.log(JSON.stringify(tetriminosCount));
}