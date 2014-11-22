function solve(input) {
    var stores = [];
    var regex = /<tr><td>[a-zA-Z]+<\/td><td>([0-9\.-]+)<\/td><td>([0-9\.-]+)<\/td><td>([0-9\.-]+)<\/td><\/tr>/;
    var maxFound;
    var maxFoundElements = {};

    for(var i = 2; i < input.length - 1; i++) {
        var result = regex.exec(input[i]);

        var store1 = result[1];
        var store2 = result[2];
        var store3 = result[3];

        stores.push(
            {
                '1' : store1,
                '2' : store2,
                '3' : store3
            }
        );
    }

    for(var store in stores) {
        var currentSum = 0;

        currentSum += stores[store]['1'] != '-' ? Number(stores[store]['1']) : 0;
        currentSum += stores[store]['2'] != '-' ? Number(stores[store]['2']) : 0;
        currentSum += stores[store]['3'] != '-' ? Number(stores[store]['3']) : 0;

        if(maxFound == undefined) {
            maxFound = currentSum;
            maxFoundElements = {
                '1' : stores[store]['1'],
                '2' : stores[store]['2'],
                '3' : stores[store]['3']
            }

            continue;
        }

        if(currentSum > maxFound) {
            maxFound = currentSum;
            maxFoundElements = {
                '1' : stores[store]['1'],
                '2' : stores[store]['2'],
                '3' : stores[store]['3']
            }
        }
    }

    var result = maxFound + ' = ';

    for(var element in maxFoundElements) {
        if(maxFoundElements[element] != '-') {
            result += maxFoundElements[element] + ' + ';
        }
    }

    var result = result.substring(0, result.length - 3);

    if(result == 0) {
        console.log('no data');
    }
    else {
        console.log(result);
    }
}