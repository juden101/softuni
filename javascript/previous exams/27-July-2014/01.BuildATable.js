function solve(input) {
    var start = Number(input[0]);
    var end = Number(input[1]);

    console.log('<table>');
    console.log('<tr><th>Num</th><th>Square</th><th>Fib</th></tr>');

    for(var i = start; i <= end; i++) {
        var row = '<tr><td>';

        row += i;
        row += '</td><td>';
        row += i * i;
        row += '</td><td>'

        row += isNumberFib(i);

        row += '</td></tr>';

        console.log(row);
    }

    function isNumberFib(n) {
        var pos = 2;
        var last = 1;
        var current = 1;
        var temp;

        while (current < n) {
            temp = last;
            last = current;
            current = current + temp;
            pos++;
        }

        if (current == n) {
            return 'yes';
        }

        return 'no';
    }

    console.log('</table>');
}