var gameGrid = document.getElementById("game-grid");
var boxes = gameGrid.getElementsByTagName("div");

var currentPlayer = 'o'
var grid = ['', '', '', '', '', '', '', '', ''];

for (var i = 0; i < boxes.length; i++) {
    boxes[i].addEventListener("click", function() {
        if(grid[this.id] == '') {
            this.className = currentPlayer;
            grid[this.id] = currentPlayer;

            if(playerWins(grid, currentPlayer)) {
                alert(currentPlayer.toUpperCase() + ' wins!');
                location.reload();
            }
            else {
                var emptyBox = false;

                for(var i = 0; i < grid.length; i++) {
                    if(grid[i] == '') {
                        emptyBox = true;
                    }
                }

                if(!emptyBox) {
                    alert('Draw!');
                    location.reload();
                }
            }

            if(currentPlayer == 'o') {
                currentPlayer = 'x';
            }
            else {
                currentPlayer = 'o';
            }
        }
    });
}

function playerWins(grid, player) {
    if(
        grid[0] == grid[1] && grid[1] == grid[2] && grid[0] == player ||
        grid[3] == grid[4] && grid[4] == grid[5] && grid[3] == player ||
        grid[6] == grid[7] && grid[7] == grid[8] && grid[6] == player ||
        grid[0] == grid[3] && grid[3] == grid[6] && grid[0] == player ||
        grid[1] == grid[4] && grid[4] == grid[7] && grid[1] == player ||
        grid[2] == grid[5] && grid[5] == grid[8] && grid[2] == player ||
        grid[0] == grid[4] && grid[4] == grid[8] && grid[0] == player ||
        grid[2] == grid[4] && grid[4] == grid[6] && grid[2] == player
    ) {
        return true;
    }

    return false;
}