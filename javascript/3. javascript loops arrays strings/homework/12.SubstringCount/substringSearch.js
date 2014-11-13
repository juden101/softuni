function countSubstringOccur(arr) {
    var keyword = arr[0];
    var text = arr[1].toLowerCase();

    var regex = new RegExp(keyword, 'g');
    var count = text.match(regex).length;

    return count;
}

console.log(countSubstringOccur(['in', 'We are living in a yellow submarine. We don\'t have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.']));
console.log(countSubstringOccur(['your', 'No one heard a single word you said. They should have seen it in your eyes. What was going around your head.']));
console.log(countSubstringOccur(['but', 'But you were living in another world tryin\' to get your message through.']));