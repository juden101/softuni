function solve(input) {
    var start = Number(input[0]);
    var end = Number(input[1]);

    var regex = /(\d{2})\d*\1/g;

    console.log('<ul>');
    for(var i = start; i <=end; i++) {
        if(i.toString().match(regex)) {
            console.log('<li><span class=\'rakiya\'>' + i + '</span><a href="view.php?id=' + i + '>View</a></li>');
        }
        else {
            console.log('<li><span class=\'num\'>' + i + '</span></li>');
        }
    }
    console.log('</ul>');
}