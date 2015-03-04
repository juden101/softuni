function add(n) {
    var f = function (x) {
        return add(n + x);
    };
    
    f.valueOf = f.toString = function () {
        return n;
    };
    
    return f;
}

var addTwo = add(2);

console.log(+addTwo); // 2
console.log(+addTwo(3)); // 5
console.log(+addTwo(3)(5)); // 10