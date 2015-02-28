var musicButton = document.getElementById('music');
var soundsButton = document.getElementById('sounds');

var backgroundMusic = document.getElementById('background-music');

backgroundMusic.volume = 0.5;

musicButton.addEventListener('click', function() {
	if(this.className == 'off') {
		this.className = 'on';
		backgroundMusic.play();
	}
	else {
		this.className = 'off';
		backgroundMusic.pause();
	}
});

soundsButton.addEventListener('click', function() {
	if(this.className == 'off') {
		this.className = 'on';
	}
	else {
		this.className = 'off';
	}
});