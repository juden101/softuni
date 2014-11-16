function biggerThanNeighbors(index, arr) {
    if(index > arr.length - 1) {
        return 'invalid index';
    }

    if(index == 0 || index == arr.length - 1) {
        return 'only one neighbor'
    }

    var number = arr[index];
    var numberLeftNeighbor = arr[index - 1];
    var numberRightNeighbor = arr[index + 1];

    if(number > numberLeftNeighbor && number > numberRightNeighbor) {
        return 'bigger';
    }

    return 'not bigger';
}

console.log(biggerThanNeighbors(2, [1, 2, 3, 3, 5]));
console.log(biggerThanNeighbors(2, [1, 2, 5, 3, 4]));
console.log(biggerThanNeighbors(5, [1, 2, 5, 3, 4]));
console.log(biggerThanNeighbors(0, [1, 2, 5, 3, 4]));