function fixCasing(str) {
    str = str.replace(/<upcase>([a-zA-Z\s']+)<\/upcase>/gmi, function(match) {
        match = match.replace(/<upcase>([a-zA-Z\s']+)<\/upcase>/gmi, "$1");

        return match.toUpperCase();
    });

    str = str.replace(/<lowcase>([a-zA-Z\s']+)<\/lowcase>/gmi, function(match) {
        match = match.replace(/<lowcase>([a-zA-Z\s']+)<\/lowcase>/gmi, "$1");

        return match.toLowerCase();
    });

    str = str.replace(/<mixcase>([a-zA-Z\s']+)<\/mixcase>/gmi, function(match) {
        match = match.replace(/<mixcase>([a-zA-Z\s']+)<\/mixcase>/gmi, "$1");
        var result = '';

        for(var i = 0; i < match.length; i++) {
            var random = Math.floor(Math.random() * 9) % 2;

            if(random == 0) {
                result += match[i].toUpperCase();
            }
            else {
                result += match[i].toLowerCase();
            }
        }

        return result;
    });

    return str;
}

console.log(fixCasing("We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else."));