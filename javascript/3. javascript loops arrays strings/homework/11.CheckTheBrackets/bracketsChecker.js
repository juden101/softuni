function checkBrackets(str) {
    var leftBrackets = 0;
    var rightBrackets = 0;

    for(var i = 0; i < str.length; i++) {
        if(str[i] == '(') {
            leftBrackets++;
        }
        else if(str[i] == ')') {
            rightBrackets++;
        }
    }

    if(leftBrackets == rightBrackets) {
        return 'correct';
    }

    return 'incorrect';
}

console.log(checkBrackets('( ( a + b ) / 5 – d )'));
console.log(checkBrackets(') ( a + b ) )'));
console.log(checkBrackets('( b * ( c + d *2 / ( 2 + ( 12 – c / ( a + 3 ) ) ) )'));