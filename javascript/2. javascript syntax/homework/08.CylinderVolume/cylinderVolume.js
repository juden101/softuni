function calcCylinderVol(arr) {
    return parseFloat(Math.PI * arr[0] * arr[0] * arr[1]).toFixed(3);
}

console.log(calcCylinderVol([2, 4]));
console.log(calcCylinderVol([5, 8]));
console.log(calcCylinderVol([12, 3]));