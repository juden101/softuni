function circleArea(radius) {
    return radius * radius * Math.PI;
}

function addNewInput(input) {
    var circleAreaContent = document.getElementById('circle-area');

    var content = document.createElement('p');
    content.innerHTML = 'r = ' + input + '; area = ' + circleArea(input);
    circleAreaContent.appendChild(content);
}

addNewInput(7);
addNewInput(1.5);
addNewInput(20);