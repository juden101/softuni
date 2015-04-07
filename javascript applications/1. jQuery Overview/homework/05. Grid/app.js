(function() {
    function makeRow(values, columnHTMLType) {
        var $newRow = $('<tr>'),
            i = 0,
            len = values.length;

        for (i = 0 ; i < len; i++) {
            $(columnHTMLType).text(values[i]).appendTo($newRow);
        }

        return $newRow;
    }

    $.fn.grid = function() {
        this.addHeader = function(values) {
            var $newRow = makeRow(values, '<th>');
            this.find('thead').empty().append($newRow);

            return this;
        };

        this.addRow = function(values) {
            var $newRow = makeRow(values, '<td>');
            this.find('tbody').append($newRow);

            return this;
        };

        return this.empty().append('<tbody>').append('<thead>');
    };
}());

$('#gridTable')
    .grid()
    .addHeader(['First Name', 'Last Name', 'Age'])
    .addRow(['Pesho', 'Goshov', 20])
    .addRow(['Gosho', 'Peshev', 23]);