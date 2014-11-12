function orderBy(a, b) {
    return a - b;
}

function findMinAndMax(arr) {
    arr.sort(orderBy);

    return { 'min' : arr[0], 'max' : arr[arr.length - 1] }
}

var firstResult = findMinAndMax([1, 2, 1, 15, 20, 5, 7, 31]);
console.log('Min -> ' + firstResult.min + '\nMax -> ' + firstResult.max + '\n');

var secondResult = findMinAndMax([2, 2, 2, 2, 2]);
console.log('Min -> ' + secondResult.min + '\nMax -> ' + secondResult.max + '\n');

var thirdResult = findMinAndMax([500, 1, -23, 0, -300, 28, 35, 12]);
console.log('Min -> ' + thirdResult.min + '\nMax -> ' + thirdResult.max + '\n');