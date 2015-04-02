$(function() {
    var currentObject,
        jsonObjects = JSON.parse('[{"manufacturer":"BMW","model":"E92 320i","year":2011,"price":50000,"class":"Family"},\
    {"manufacturer":"Porsche","model":"Panamera","year":2012,"price":100000,"class":"Sport"},\
    {"manufacturer":"Peugeot","model":"305","year":1978,"price":1000,"class":"Family"}]');

    for (var objectIndex in jsonObjects) {
        currentObject = jsonObjects[objectIndex];

        $('table').append($('<tr>')
                .append($('<td>').text(currentObject.manufacturer))
                .append($('<td>').text(currentObject.model))
                .append($('<td>').text(currentObject.year))
                .append($('<td>').text(currentObject.price))
                .append($('<td>').text(currentObject.class))
        );
    }
});