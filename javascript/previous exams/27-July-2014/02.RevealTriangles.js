function solve(input) {
    var matrix = [];
    for (var i = 0; i < input.length; i++) {
        matrix.push(input[i].split(''));
    }

    for(var row = 0; row < input.length - 1; row++) {
        for(var col = 0; col < input[row].length; col++) {
            var a = input[row][col];
            var b = input[row + 1][col - 1];
            var c = input[row + 1][col];
            var d = input[row + 1][col + 1];

            if(a == b && b == c && c == d) {
                matrix[row][col] = '*';
                matrix[row + 1][col - 1] = '*';
                matrix[row + 1][col] = '*';
                matrix[row + 1][col + 1] = '*';
            }
        }
    }

    matrix = matrix.join("\n").replace(/\,/g, '');
    console.log(matrix);
}