function findNthDigit(arr) {
    var num, n, result;

    num = arr[0];
    n = arr[1].toString().replace(/[\.-]+/g, '');

    result = n[n.length - num];

    if(result == undefined) {
        result = 'The number doesn’t have 6 digits';
    }

    return result;
}

console.log(findNthDigit([1, 6]));
console.log(findNthDigit([2, -55]));
console.log(findNthDigit([6, 923456]));
console.log(findNthDigit([3, 1451.78]));
console.log(findNthDigit([6, 888.88]));