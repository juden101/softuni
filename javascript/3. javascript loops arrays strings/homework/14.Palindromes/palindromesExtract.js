function findPalindromes(str) {
    str = str.replace(',', '').replace('.', '').toLowerCase();

    var palindromes = [];
    var words = str.split(' ');
    var result = '';

    for(var i = 0; i < words.length; i++) {
        var isPalindrome = true;

        for(var j = 0; j < words[i].length / 2; j++) {
            var first = words[i][j];
            var second = words[i][words[i].length - j - 1];

            if(first !== second) {
                isPalindrome = false;
                break;
            }
        }

        if(isPalindrome) {
            palindromes.push(words[i]);
        }
    }

    for(var i = 0; i < palindromes.length; i++) {
        result += palindromes[i];
        i < palindromes.length - 1 ? result += ', ' : null;
    }

    return result;
}

console.log(findPalindromes('There is a man, his name was Bob.'));