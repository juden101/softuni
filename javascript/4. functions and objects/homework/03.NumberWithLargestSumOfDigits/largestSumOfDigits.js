﻿function findLargestBySumOfDigits(arr) {
    if (arr.length == 0) {
        return undefined;
    }

    var maxSum = Number.MIN_VALUE;
    var maxNumBySum;

    for (var i = 0; i < arr.length; i++) {
        if (Math.floor(arr[i]) != arr[i]) {
            return undefined;
        }

        var currentNum = Math.abs(arr[i]);
        var currentSum = 0;

        while (currentNum != 0) {
            currentSum += currentNum % 10;
            currentNum = Math.floor(currentNum / 10);
        }

        if (maxSum < currentSum) {
            maxSum = currentSum;
            maxNumBySum = arr[i];
        }
    }

    return maxNumBySum;
}

console.log(findLargestBySumOfDigits([5, 10, 15, 111]));
console.log(findLargestBySumOfDigits([33, 44, -99, 0, 20]));
console.log(findLargestBySumOfDigits(['hello']));
console.log(findLargestBySumOfDigits([5, 3.3]));