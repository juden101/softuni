var game = document.getElementById('game');
var player = document.getElementById('player');
var lastPosition = 'left';

player.style.top = "380px";
player.style.left = "380px";

setInterval(function() {
    moveRocks();
}, 25);
setInterval(function() {
    increaseTime();
}, 1000);
setInterval(function() {
    //TODO ROCK POSITION
    var rockPosition = random(0, 730);
    var rock = document.createElement('div');
    rock.className = 'rock';
    rock.style.top = 0 + 'px';
    rock.style.left = random(0, 730) + 'px';

    game.appendChild(rock);
}, 1500);

document.onkeydown = function(e) {
    e = e || window.event;

    switch(e.which || e.keyCode) {
        case 32:
            movePlayer('flip');

            break;
        case 37:
            movePlayer('left');

            break;
        case 39:
            movePlayer('right');

            break;
        default: return;
    }

    e.preventDefault();
}

function moveRocks() {
    var playerTop = player.style.top.replace('px', '');
    var playerLeft = player.style.left.replace('px', '');

    var rocks = game.getElementsByClassName('rock');

    for (var i = 0; i < rocks.length; i++) {
        var currentRockTop = rocks[i].style.top.replace('px', '');
        var currentRockLeft = rocks[i].style.left.replace('px', '');

        //CHECKS COLLISION
        console.log("rock => " + currentRockTop + ", " + currentRockLeft);
        console.log("player => " + playerTop + ", " + playerLeft);

        console.log(Math.abs(currentRockTop - playerTop) + ", " + Math.abs(currentRockLeft - playerLeft));

        if(Math.abs(currentRockTop - playerTop) < 100 && Math.abs(currentRockLeft - playerLeft) < 100) {
            var points = document.getElementById('points').innerText;
            var time = document.getElementById('time').innerText;

            alert("You gained " + points + " points in " + time + " seconds!");
            location.reload();
        }

        //REMOVES ROCK WHEN HIT THE GROUND
        if(currentRockTop > 380) {
            game.getElementsByClassName('rock')[i].remove();
            increasePoints();

            continue;
        }

        rocks[i].style.top = (parseInt(currentRockTop) + 3) + 'px';
    }
}
function movePlayer(position) {
    var player = document.getElementById('player');
    var playerPosition = parseInt(getComputedStyle(player).getPropertyValue('left').replace('px',''));

    if(position == 'left') {
        lastPosition = 'left';

        if(playerPosition > 0) {
            player.style.left = (playerPosition - 35) + 'px';
            player.style.transform = 'scaleX(1)';
        }
    }
    else if(position == 'right') {
        lastPosition = 'right';

        if(playerPosition < 730) {
            player.style.left = (playerPosition + 35) + 'px';
            player.style.transform = 'scaleX(-1)';
        }
    }
    else if(position == 'flip') {
        if(playerPosition > 50 && lastPosition == 'left') {
            player.style.left = (playerPosition - 75) + 'px';
            player.style.transform = 'scaleX(1)';
        }
        else if(playerPosition < 680 && lastPosition == 'right') {
            player.style.left = (playerPosition + 75) + 'px';
        }

        player.className = "spin-player";

        setTimeout(function() {
            player.className = '';
        }, 500);
    }
}
function increasePoints() {
    var currentPoints = parseInt(document.getElementById('points').innerText);
    document.getElementById('points').innerHTML = currentPoints + 1;
}
function increaseTime() {
    var currentTime = parseInt(document.getElementById('time').innerText);
    document.getElementById('time').innerHTML = currentTime + 1;
}
function random(min, max) {
    return Math.floor(Math.random() * (max - min + 1) + min);
}