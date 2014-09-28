expression = "";

function put(char) {
    if(char == "C") {
        expression = "";
    }
    else if(char == "=") {
        expression = eval(expression);
    }
    else {
        expression += "" + char;
    }

    document.getElementById("display").value = expression;
}