function roundNumber(number) {
    var roundNumber = Math.round(number);
    var floorNumber = Math.floor(number);

    return {'round' : roundNumber, 'floor' : floorNumber};
}

var numbers = [22.7, 12.3, 58.7];

for(var i = 0; i < numbers.length; i++) {
    var currentNumber = roundNumber(numbers[i]);

    console.log(currentNumber.floor + "\n" + currentNumber.round + "\n");
}