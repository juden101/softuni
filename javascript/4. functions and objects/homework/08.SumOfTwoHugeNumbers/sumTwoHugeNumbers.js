function sumTwoHugeNumbers(value) {
    var firstNum;
    var secondNum;
    if(value[0].length >= value[1].length) {
        firstNum = value[0];
        secondNum = value[1];
    } else {
        firstNum = value[1];
        secondNum = value[0];
    }

    var resultAndRemainingDigit = ['', 0];

    for(var i = firstNum.length - 1, j = secondNum.length - 1; i >= 0; i--, j--) {
        if (secondNum[j] == undefined) {
            calcNextDigit(firstNum[i], 0, resultAndRemainingDigit[1]);
        } else {
            calcNextDigit(firstNum[i], secondNum[j], resultAndRemainingDigit[1]);
        }
    }

    function calcNextDigit(firstNumDigit, secondNumDigit, remainingDigitToAdd) {
        var digitToAdd = '';
        var firstDigit = parseInt(firstNumDigit);
        var secondDigit = parseInt(secondNumDigit);
        var sum = firstDigit + secondDigit + remainingDigitToAdd;
        if(sum < 10) {
            digitToAdd = sum.toString();
            resultAndRemainingDigit[0] = digitToAdd + resultAndRemainingDigit[0];
            resultAndRemainingDigit[1] = 0;
        } else {
            digitToAdd = sum.toString()[1];
            resultAndRemainingDigit[0] = digitToAdd + resultAndRemainingDigit[0];
            resultAndRemainingDigit[1] = 1;
        }
    }

    return resultAndRemainingDigit[0];
}

console.log(sumTwoHugeNumbers(['155', '65']));
console.log(sumTwoHugeNumbers(['123456789', '123456789']));
console.log(sumTwoHugeNumbers(['887987345974539','4582796427862587']));
console.log(sumTwoHugeNumbers(['347135713985789531798031509832579382573195807',
    '817651358763158761358796358971685973163314321']));