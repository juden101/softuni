function clone(obj) {
    if (null == obj || "object" != typeof obj) {
        return obj;
    }

    var copy = obj.constructor();

    for (var attr in obj) {
        if (obj.hasOwnProperty(attr)) copy[attr] = obj[attr];
    }

    return copy;
}

function compareObjects(obj, objCopy) {
    var compared = obj == objCopy;

    return 'a == b --> ' + compared;
}

var a = {name: 'Pesho', age: 21}
var b = clone(a); // a deep copy
console.log(compareObjects(a, b));

var a = {name: 'Pesho', age: 21}
var b = a; // not a deep copy
console.log(compareObjects(a, b));