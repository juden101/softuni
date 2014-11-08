var lastPosition = 'left';
var rotateDegree = 0;

document.onkeydown = function(e) {
    e = e || window.event;
    switch(e.which || e.keyCode) {
        case 37: // left
            console.log("<-");
            movePlayer('left');

            break;

        case 32: // flip
            console.log("flip");
            movePlayer('flip');
            break;

        case 39: // right
            console.log("->");
            movePlayer('right');

            break;

        case 40: // down
            break;

        default: return; // exit this handler for other keys
    }
    e.preventDefault(); // prevent the default action (scroll / move caret)
}

function movePlayer(position) {
    var player = document.getElementById('player');
    var playerPosition = parseInt(getComputedStyle(player).getPropertyValue('left').replace('px',''));

    if(position == 'left') {
        lastPosition = 'left';

        if(playerPosition > 0) {
            player.style.left = (playerPosition - 35) + 'px';
            player.style.transform = 'scaleX(1)';
            /*-webkit-transform: rotate(170deg);
            transition: transform 2s;*/
            //player.style.transition = 'none';
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
            //rotateDegree += 360;
        }
        else if(playerPosition < 680 && lastPosition == 'right') {
            player.style.left = (playerPosition + 75) + 'px';
            //rotateDegree -= 360;
        }

        player.className = "spin";

        setTimeout(function() {
            player.className = '';
        }, 500);

        //rotateDegree = rotateDegree == 0 ? 360 : 0;

        /*if(!rotate) {
            player.style.transform = 'rotate(0deg)';
            //rotate = false;
        }
        else {
            player.style.transform = 'rotate(360deg)';
            //rotate = true;
        }*/

        //player.style.transform = 'rotate(' + rotateDegree + 'deg)';
        //player.style.transition = 'transform .5s';

    }
}