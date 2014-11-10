function evenNumber(number) {
    return number % 2 == 0;
}

var numbers = [3, 127, 588];

for(var i = 0; i < numbers.length; i++) {
    var isNumberEven = evenNumber(numbers[i]);

    console.log(isNumberEven);
}