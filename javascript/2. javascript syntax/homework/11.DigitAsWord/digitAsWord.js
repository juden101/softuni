function convertDigitToWord(value) {
    switch(value) {
        case 1:
            return 'one';
            break;
        case 2:
            return 'two';
            break;
        case 3:
            return 'three';
            break;
        case 4:
            return 'four';
            break;
        case 5:
            return 'five';
            break;
        case 6:
            return 'six';
            break;
        case 7:
            return 'seven';
            break;
        case 8:
            return 'eight';
            break;
        case 9:
            return 'nine';
            break;
    }
}

var numbers = [8, 3, 5];

for(var i = 0; i < numbers.length; i++) {
    var numberToWord = convertDigitToWord(numbers[i]);

    console.log(numberToWord);
}