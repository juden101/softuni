function findMostFreqWord(str) {
    str = str.replace(/\./g, '');
    str = str.replace(/\,/g, '');

    var words = str.toLowerCase().split(' ').sort();
    var wordsCount = [];
    var mostFrequent = 0;
    var result = '';

    for(var i = 0; i < words.length; i++) {
        if(wordsCount[words[i]] == undefined) {
            wordsCount[words[i]] = 1;
        }
        else {
            wordsCount[words[i]]++;

            if(wordsCount[words[i]] > mostFrequent) {
                mostFrequent = wordsCount[words[i]];
            }
        }
    }

    for (number in wordsCount) {
        if(wordsCount[number] == mostFrequent) {
            result += number + ' -> ' + wordsCount[number] + ' times\n';
        }
    }

    console.log(result);
}

findMostFreqWord('in the middle of the night');
findMostFreqWord('Welcome to SoftUni. Welcome to Java. Welcome everyone.');
findMostFreqWord('Hello my friend, hello my darling. Come on, come here. Welcome, welcome darling.');