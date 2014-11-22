function solve(args) {
    var start = parseInt(args[0], 10);
    var end = parseInt(args[1], 10);
    var result = '<table>\n<tr><th>Num</th><th>Square</th><th>Fib</th></tr>\n';

    function isNumberFib(n){
        function isPerfectSquare(n) {
            var s = Math.sqrt(n).toFixed(0);
            return (s * s === n);
        }

        if (n === 0) {
            return 'no';
        }

        return (isPerfectSquare(5 * n * n + 4) || isPerfectSquare(5 * n * n - 4)) ? 'yes' : 'no';
    }

    for(var i = start; i <= end; i++) {
        result += '<tr><td>' + i + '</td><td>' + i * i + '</td><td>' + isNumberFib(i) + '</td></tr>\n';
    }

    result += '</table>\n';

    return result;
}

console.log(solve([999999, 1000000]));