function findMostFreqNum(arr) {
    var numberFrequency = [];
    var mostFreqNum, mostFreqNumLength;

    for(var i = 0; i < arr.length; i++) {
        if(numberFrequency[arr[i]] == undefined) {
            numberFrequency[arr[i]] = 1;
        }
        else {
            numberFrequency[arr[i]]++;
        }
    }

    for (var num in numberFrequency) {
        if(mostFreqNumLength == undefined) {
            mostFreqNum = num;
            mostFreqNumLength = numberFrequency[num];
        }
        else {
            if(mostFreqNumLength < numberFrequency[num]) {
                mostFreqNum = num;
                mostFreqNumLength = numberFrequency[num];
            }
        }
    }

    return {
        number : mostFreqNum,
        length : mostFreqNumLength
    }
}

var firstFreq = findMostFreqNum([4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3]);
console.log(firstFreq.number + ' (' + firstFreq.length + ' times)');

var secondFreq = findMostFreqNum([2, 1, 1, 5, 7, 1, 2, 5, 7, 3, 87, 2, 12, 634, 123, 51, 1]);
console.log(secondFreq.number + ' (' + secondFreq.length + ' times)');

var thirdFreq = findMostFreqNum([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]);
console.log(thirdFreq.number + ' (' + thirdFreq.length + ' times)');