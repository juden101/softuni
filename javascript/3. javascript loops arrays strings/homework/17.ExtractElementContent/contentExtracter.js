function extractContent(str) {
    var regex = /<[a-z0-9 =':///.]+>([\s\S]*?)<\/[\w]+>/gmi;
    var result = str.replace(regex, "$1");

    return result;
}

console.log(extractContent("<p class='asd'>Hello</p><a href='http://w3c.org'>W3C</a>"));