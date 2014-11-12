function checkDigit(number) {
    var reversedNumber = number.toString().split("").reverse().join("");

    if(reversedNumber[2] == 3) {
        return true;
    }

    return false;
}

var numbers = [1235, 25368, 123456];

for(var i = 0; i < numbers.length; i++) {
    var isDigit3 = checkDigit(numbers[i]);

    console.log(isDigit3);
}