Array.prototype.removeItem = function(item) {
    var result = [];

    for(var i = 0; i < this.length; i++) {
        if(this[i] !== item) {
            result.push(this[i]);
        }
    }

    return result;
}

var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];
arr = arr.removeItem(1);
console.log(arr);

var arr = ['hi', 'bye', 'hello' ];
arr = arr.removeItem('bye');
console.log(arr);