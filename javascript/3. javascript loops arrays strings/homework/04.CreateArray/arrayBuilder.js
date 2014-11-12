function createArray() {
    var arr = [];
    var result = '';

    for(var i = 0; i <= 20; i++) {
        arr[i] = i * 5;
        result += arr[i] + ' ';
    }

    return result;
}

console.log(createArray());