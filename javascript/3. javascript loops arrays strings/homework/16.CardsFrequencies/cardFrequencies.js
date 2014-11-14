function findCardFrequency(str) {
    var cards = str.replace(/[♥♣♠♦]+/g, '').split(" ");
    var counter = 1;
    var cardsFrequency = [];
    var n = cards.length;
    var result = '';

    for (var i = 0; i < cards.length; i++) {
        for (var j = 0; j < cards.length; j++) {
            if (cards[i] == cards[j] && i != j && j > i) {
                counter++;
                cards.splice(j, 1);
                j--;
            }
        }

        cardsFrequency.push(((counter / n) * 100).toFixed(2) + '%');
        counter = 1;
    }

    for (i = 0; i < cards.length; i++) {
        result += cards[i] + " -> " + cardsFrequency[i] + '\n';
    }

    return result;
}

console.log(findCardFrequency('8♥ 2♣ 4♦ 10♦ J♥ A♠ K♦ 10♥ K♠ K♦'));
console.log(findCardFrequency('J♥ 2♣ 2♦ 2♥ 2♦ 2♠ 2♦ J♥ 2♠'));
console.log(findCardFrequency('10♣ 10♥'));