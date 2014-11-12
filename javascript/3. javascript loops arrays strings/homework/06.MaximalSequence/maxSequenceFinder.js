function findMaxSequence(arr) {
    var bestSequenceElement;
    var bestSequenceLength;

    var lastSequenceElement;
    var lastSequenceLength;

    var result = '';

    for(var i = 0; i < arr.length; i++) {
        if(lastSequenceLength == undefined) {
            lastSequenceElement = arr[i];
            lastSequenceLength = 1;
        }
        else {
            if(lastSequenceElement === arr[i]) {
                lastSequenceLength++;
            }
            else {
                lastSequenceElement = arr[i];
                lastSequenceLength = 1;
            }
        }

        if(bestSequenceLength == undefined) {
            bestSequenceElement = lastSequenceElement;
            bestSequenceLength = lastSequenceLength;
        }
        else {
            if(lastSequenceLength >= bestSequenceLength) {
                bestSequenceElement = lastSequenceElement;
                bestSequenceLength = lastSequenceLength;
            }
        }
    }

    for(var i = 0; i < bestSequenceLength; i++) {
        result += bestSequenceElement + ', ';
    }

    result = '[' + result.substring(0, result.length - 2) + ']';
    return result;
}

console.log(findMaxSequence([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]));
console.log(findMaxSequence(['happy']));
console.log(findMaxSequence([2, 'qwe', 'qwe', 3, 3, '3']));