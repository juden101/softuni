function solve(input){
    var firstLine = input[0].split(/\s+/g);
    var secondLine = input[1].split(/\s+/g);
    var thirdLine = input[2].split(/\s+/g);
    var fourthLine = input[3].split(/\s+/g);
    var fifthLine = input[4].split(/\s+/g);

    var firstSystem = firstLine[0];
    var firstSystemX = parseFloat(firstLine[1]);
    var firstSystemY = parseFloat(firstLine[2]);

    var secondSystem = secondLine[0];
    var secondSystemX = parseFloat(secondLine[1]);
    var secondSystemY = parseFloat(secondLine[2]);

    var thirdSystem = thirdLine[0];
    var thirdSystemX = parseFloat(thirdLine[1]);
    var thirdSystemY = parseFloat(thirdLine[2]);

    var normadyX = parseFloat(fourthLine[0]);
    var normadyY = parseFloat(fourthLine[1]);

    var move = parseInt(fifthLine);

    for(var i = 0; i <= move; i++) {
        if(normadyX <= firstSystemX + 1
            && normadyX >= firstSystemX-1
            && normadyY>= firstSystemY-1
            && normadyY<= firstSystemY+1){
            console.log(firstSystem.toLowerCase());
        } else if(normadyX <= secondSystemX+1
            && normadyX >= secondSystemX-1
            && normadyY >= secondSystemY-1
            && normadyY <= secondSystemY+1) {
            console.log(secondSystem.toLowerCase());
        } else if(normadyX <= thirdSystemX+1
            && normadyX >= thirdSystemX-1
            && normadyY >= thirdSystemY-1
            && normadyY <= thirdSystemY+1) {
            console.log(thirdSystem.toLowerCase());
        } else {
            console.log('space')
        }

        normadyY++;
    }
}