function solve(input) {
    var table = [];

    for(var i = 2; i < input.length - 1; i++) {
        var matcher = /<td>([\d\.]+)<\/td>/g.exec(input[i]);

        var currentPrice = matcher[1];
        var currentRow = matcher.input;

        var row = {
            'price' : Number(currentPrice),
            'row' : currentRow
        }

        table.push(row);
    }

    table.sort(function(a, b) {
        if(a.price == b.price) {
            return a.row.localeCompare(b.row);
        }
        else {
            return a.price - b.price;
        }
    });

    console.log(input[0]);
    console.log(input[1]);

    for(var i = 0; i < table.length; i++) {
        console.log(table[i].row);
    }

    console.log(input[input.length - 1]);
}