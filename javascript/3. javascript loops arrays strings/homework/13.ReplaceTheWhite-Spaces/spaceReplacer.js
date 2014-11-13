function replaceSpaces(str) {
    return str.replace(new RegExp(' ', 'g'), '');
}

console.log(replaceSpaces('But you were living in another world tryin\' to get your message through'));