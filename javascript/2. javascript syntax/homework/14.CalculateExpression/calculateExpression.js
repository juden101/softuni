var button = document.getElementById('calculate-button');

button.addEventListener("click", function(e) {
    var expression = document.getElementById('calculate-expression').value;

    if (expression != '') {
        expression = expression.replace(/[^0-9\-+*/()%|&^><!~]/g, '');
        var result = eval(expression);
        document.getElementById('result').innerHTML = result;
    } else {
        document.getElementById('result').innerHTML = 'The expression is empty.';
    }

    document.getElementById('calculate-expression').focus();
});