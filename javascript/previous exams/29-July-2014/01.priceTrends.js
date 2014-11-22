function solve(input) {
    var prices = input.map(Number);
    var prevPrice = undefined;

    console.log("<table>");
    console.log("<tr><th>Price</th><th>Trend</th></tr>");

    for (var i = 0; i < prices.length; i++) {
        var price = prices[i];
        var priceStr = price.toFixed(2);

        if (prevPrice == undefined || priceStr == prevPrice) {
            var trend = "fixed.png";
        }
        else if (price < prevPrice) {
            var trend = "down.png";
        }
        else {
            var trend = "up.png";
        }

        console.log("<tr><td>" + priceStr + "</td><td><img src=\"" + trend + "\"/></td></td>");
        prevPrice = priceStr;
    }

    console.log("</table>");
}