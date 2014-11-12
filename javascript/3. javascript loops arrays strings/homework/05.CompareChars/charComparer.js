function compareChars(arr1, arr2) {
    var result = 'Equal';

    for(var i = 0; i < arr1.length; i++) {
        if(arr1[i] != arr2[i]) {
            result = 'Not equal';
        }
    }

    return result;
}

var firstArr, secondArr;

firstArr = ['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q'];
secondArr = ['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q'];
console.log(compareChars(firstArr, secondArr));

firstArr = ['3', '5', 'g', 'd'];
secondArr = ['5', '3', 'g', 'd'];
console.log(compareChars(firstArr, secondArr));