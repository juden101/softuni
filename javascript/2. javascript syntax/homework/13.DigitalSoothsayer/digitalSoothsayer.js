function soothsayer(numsArr, langsArr, citiesArr, carsArr) {
    var result = [];

    result[0] = numsArr[Math.floor(Math.random() * numsArr.length)];
    result[1] = langsArr[Math.floor(Math.random() * langsArr.length)];
    result[2] = citiesArr[Math.floor(Math.random() * citiesArr.length)];
    result[3] = carsArr[Math.floor(Math.random() * carsArr.length)];

    return result;
}

var result = soothsayer(
        [3, 5, 2, 7, 9],
        ['Java', 'Python', 'C#', 'JavaScript', 'Ruby'],
        ['Silicon Valley', 'London', 'Las Vegas', 'Paris', 'Sofia'],
        ['BMW', 'Audi', 'Lada', 'Skoda', 'Opel']
    );

console.log('You will work ' + result[0] + ' years on ' + result[1] + '. You will live in ' + result[2] + ' and drive ' + result[3] + '.');