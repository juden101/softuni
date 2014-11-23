function solve(input) {
    var allSymbols = input[0];
    var extractedNumbers, result = '';

    String.prototype.extractNumbers = function() {
        var regex = /\d+(\d+)?/g;
        var extractedNumbers = this.match(regex) || [];

        return extractedNumbers.map(Number);
    };

    String.prototype.padZeros = function(length) {
        var padString = '0';
        var str = this;

        while (str.length < length) {
            str = padString + str;
        }

        return str;
    }

    extractedNumbers = allSymbols.extractNumbers();

    for(var number in extractedNumbers) {
        result += '0x' + extractedNumbers[number].toString(16).padZeros(4).toUpperCase() + '-';
    }

    result = result.substring(0, result.length - 1);

    console.log(result);
}