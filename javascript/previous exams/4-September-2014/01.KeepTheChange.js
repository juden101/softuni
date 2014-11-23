function solve(input) {
    var bill = Number(input[0]);
    var mood = input[1];
    var tip = 0;

    if(mood == 'happy') {
        tip = 0.1 * bill;
    }
    else if(mood == 'married') {
        tip = 0.0005 * bill;
    }
    else if(mood == 'drunk') {
        tip = 0.15 * bill;
        tip = Math.pow(tip, tip.toString().charAt(0));
    }
    else {
        tip = 0.05 * bill;
    }

    console.log(tip.toFixed(2));
}