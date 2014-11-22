function solve(input) {
    var concerts = {};

    function sortObjectProperties(obj) {
        var keysSorted = Object.keys(obj).sort();
        var sortedObj = {};
        for (var i = 0; i < keysSorted.length; i++) {
            var key = keysSorted[i];
            sortedObj[key] = obj[key];
        }

        return sortedObj;
    }

    for(var row in input) {
        var band, town, venue;
        var splitedRow = input[row].split('|');

        band = splitedRow[0].trim();
        town = splitedRow[1].trim();
        venue = splitedRow[3].trim();

        if(!concerts[town]) {
            concerts[town] = {};
        }

        if(!concerts[town][venue]) {
            concerts[town][venue] = [];
        }

        if(concerts[town][venue].indexOf(band) == -1) {
            concerts[town][venue].push(band);
        }
    }

    concerts = sortObjectProperties(concerts);
    for(town in concerts) {
        concerts[town] = sortObjectProperties(concerts[town]);

        for (var venue in concerts[town]) {
            concerts[town][venue].sort();
        }
    }

    console.log(JSON.stringify(concerts));
}