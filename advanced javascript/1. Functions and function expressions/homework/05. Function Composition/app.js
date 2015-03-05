function compose(f, g) {
    return function (x) {
        return f.call(this, g.apply(this, arguments));
    };
}

function add(x, y) {
    return x + y;
}

function addOne(x) {
    return x + 1;
}

function square(x) {
    return x * x;
}

console.log(compose(addOne, square)(5)); // 26 -> addOne(square(5)) = 5 * 5 + 1 = 26
console.log(compose(addOne, add)(5, 6)); // 12
console.log(compose(Math.cos, addOne)(-1)); // 1 -> cos(0) = 1
console.log(compose(addOne, Math.cos)(-1)); // 1.5403023058681398

var compositeFunction = compose(Math.sqrt, Math.cos);
console.log(compositeFunction(0.5)); // 0.9367937670001721
console.log(compositeFunction(1)); // 0.7350525871447157
console.log(compositeFunction(-1)); // 0.7350525871447157