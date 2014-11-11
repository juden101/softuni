function bitChecker(number) {
    var checkBit = ((number >> 3) & 1) == 1;

    return checkBit;
}

var numbers = [333, 425, 2567564754];

for(var i = 0; i < numbers.length; i++) {
    var isThirdBitOne = bitChecker(numbers[i]);

    console.log(isThirdBitOne);
}