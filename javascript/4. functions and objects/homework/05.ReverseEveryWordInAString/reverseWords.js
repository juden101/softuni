function reverseWordsInString(str) {
    var result = '';
    var splitedString = str.split(' ');

    for(word in splitedString) {
        result += splitedString[word].split("").reverse().join("") + ' ';
    }

    return result;
}

console.log(reverseWordsInString('Hello, how are you.'));
console.log(reverseWordsInString('Life is pretty good, isn’t it?'));