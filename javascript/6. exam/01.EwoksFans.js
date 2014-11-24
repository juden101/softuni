function solve(input) {
    var isBiggestFan = false, isBiggestHater = false,
    biggestFanDate, biggestHaterDate;

    var initDate = new Date(1900, 0, 1);
    var endDate = new Date(2015, 0, 1);
    var ewoksDate = new Date(1973, 4, 25);

    for(var i = 0; i < input.length; i++) {
        var currentDay, currentMonth, currentYear;
        var explodedDate = input[i].split('.');

        currentDay = Number(explodedDate[0]);
        currentMonth = Number(explodedDate[1]);
        currentYear = Number(explodedDate[2]);

        var currentDate = new Date(currentYear, currentMonth - 1, currentDay);

        if(currentDate > initDate && currentDate < endDate) {
            if(currentDate > ewoksDate) {
                if(!isBiggestFan) {
                    isBiggestFan = true;
                    biggestFanDate = currentDate;
                }
                else {
                    if(biggestFanDate < currentDate) {
                        biggestFanDate = currentDate;
                    }
                }
            }
            else {
                if(!isBiggestHater) {
                    isBiggestHater = true;
                    biggestHaterDate = currentDate;
                }
                else {
                    if(biggestHaterDate > currentDate) {
                        biggestHaterDate = currentDate;
                    }
                }
            }
        }
    }

    if(isBiggestFan) {
        console.log('The biggest fan of ewoks was born on ' + biggestFanDate.toDateString());
    }

    if(isBiggestHater) {
        console.log('The biggest hater of ewoks was born on ' + biggestHaterDate.toDateString());
    }

    if(!isBiggestFan && !isBiggestHater) {
        console.log('No result');
    }
}