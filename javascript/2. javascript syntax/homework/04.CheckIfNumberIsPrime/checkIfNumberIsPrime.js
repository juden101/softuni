function primeNumber(number) {
    if (number < 2) return false;

    var q = parseInt(Math.sqrt(number));
    for (var i = 2; i <= q; i++) {
        if (number % i == 0) {
            return false;
        }
    }

    return true;
}

var numbers = [7, 254, 587];

for(var i = 0; i < numbers.length; i++) {
    var isNumberPrime = primeNumber(numbers[i]);

    console.log(isNumberPrime);
}