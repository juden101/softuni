function solve(input) {
    var links = [];
    var result = '';

    for(var i = 0; i < input.length; i++) {
        var currentRowProperties = input[i].split('&');

        for(var j = 0; j < currentRowProperties.length; j++) {
            var cleanedLink = currentRowProperties[j].replace(/%20/g, ' ');
            cleanedLink = cleanedLink.replace(/[\+]+/g, ' ');
            cleanedLink = cleanedLink.replace(/\s{2,}/g, ' ');

            var splittedLink = cleanedLink.split('?');
            var currentKeyValue = splittedLink[0].split('=');

            if(splittedLink.length > 1) {
                currentKeyValue = splittedLink[1].split('=');
            }

            var currentKey = currentKeyValue[0].trim();
            var currentValue = currentKeyValue[1].trim();

            if(!links[i]) {
                links[i] = [];
            }

            if(!links[i][currentKey]) {
                links[i][currentKey] = [];
            }

            links[i][currentKey].push(currentValue);
        }
    }

    for(var i = 0; i < links.length; i++) {
        for(var key in links[i]) {
            result += key + '=[';

            for(var value = 0; value < links[i][key].length; value++) {
                result += links[i][key][value] + ', ';
            }
            result = result.substring(0, result.length - 2);
            result += ']';
        }

        result += '\n';
    }

    console.log(result);
}