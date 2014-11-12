function findMaxSequence(arr) {
    var bestSequenceElement;
    var bestSequenceLength;
    var bestSequence = [];

    var lastSequenceElement;
    var lastSequenceLength;
    var lastSequence = [];

    for(var i = 0; i < arr.length; i++) {
        if(lastSequenceLength == undefined) {
            lastSequenceElement = arr[i];
            lastSequenceLength = 1;
            lastSequence = [];
            lastSequence.push(arr[i]);
        }
        else {
            if(lastSequenceElement < arr[i]) {
                lastSequenceLength++;
                lastSequence.push(arr[i]);
            }
            else {
                lastSequenceElement = arr[i];
                lastSequenceLength = 1;
                lastSequence = [];
                lastSequence.push(arr[i]);
            }
        }

        if(bestSequenceLength == undefined) {
            bestSequenceElement = lastSequenceElement;
            bestSequenceLength = lastSequenceLength;
            bestSequence = lastSequence;
        }
        else {
            if(lastSequenceLength >= bestSequenceLength) {
                bestSequenceElement = lastSequenceElement;
                bestSequenceLength = lastSequenceLength;
                bestSequence = lastSequence;
            }
        }
    }

    if(bestSequence.length == 1) {
        return 'no';
    }

    return bestSequence;
}

console.log(findMaxSequence([3, 2, 3, 4, 2, 2, 4]));
console.log(findMaxSequence([3, 5, 4, 6, 1, 2, 3, 6, 10, 32]));
console.log(findMaxSequence([3, 2, 1]));