function solve(input) {
    var html = input.join('\n');
    var regex = /<a\s+([^>]+\s+)?href\s*=\s*('([^']*)'|"([^"]*)|([^\s>]+))[^>]*>/g;
    var match;

    while(match = regex.exec(html)) {
        var hrefValue = match[3];

        if (hrefValue == undefined) {
            var hrefValue = match[4];
        }

        if (hrefValue == undefined) {
            var hrefValue = match[5];
        }

        console.log(hrefValue);
    }
}