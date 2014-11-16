function lastDigitAsText(number) {
    var result, lastDigit;

    lastDigit = number % 10;
    if(lastDigit < 0) {
        lastDigit *= -1;
    }

    switch(lastDigit) {
        case 0:
            result = 'Zero';
            break;
        case 1:
            result = 'One';
            break;
        case 2:
            result = 'Two';
            break;
        case 3:
            result = 'Three';
            break;
        case 4:
            result = 'Four';
            break;
        case 5:
            result = 'Five';
            break;
        case 6:
            result = 'Six';
            break;
        case 7:
            result = 'Seven';
            break;
        case 8:
            result = 'Eight';
            break;
        case 9:
            result = 'Nine';
            break;
        default:
            result = undefined;
            break;
    }

    return result;
}

console.log(lastDigitAsText(6));
console.log(lastDigitAsText(-55));
console.log(lastDigitAsText(133));
console.log(lastDigitAsText(14567));