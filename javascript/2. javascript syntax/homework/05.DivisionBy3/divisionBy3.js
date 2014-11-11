function divisionBy3(number) {
    var sum = 0;

    while(true) {
        var currentDigit = Math.floor(number % 10);
        if(currentDigit == 0) {
            break;
        }

        sum += currentDigit;
        number /= 10;
    }

    if(sum % 3 == 0) {
        return true;
    }
    return false;
}

var numbers = [12, 188, 591];

for(var i = 0; i < numbers.length; i++) {
    var isDividedBy3 = divisionBy3(numbers[i]);

    if(isDividedBy3) {
        console.log('the number is divided by 3 without remainder');
    }
    else {
        console.log('the number is not divided by 3 without remainder');
    }
}