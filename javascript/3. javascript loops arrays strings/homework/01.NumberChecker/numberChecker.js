function printNumbers(number) {
    var result = '';

    for(var i = 1; i <= number; i++) {
        if(i % 4 != 0 && i % 5 != 0) {
            result += i + ', ';
        }
    }

    result = result.substring(0, result.length - 2);

    if(result == '') {
        return 'no';
    }
    
    return result;
}

console.log(printNumbers(20));
console.log(printNumbers(-5));
console.log(printNumbers(13));