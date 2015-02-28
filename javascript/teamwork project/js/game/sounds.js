define([], function () {
	'use strict';
	
	var PlaySound = (function() {
		function PlaySound (soundPath) {
			var isSoundMuted = document.getElementById('sounds').className;
			
			if(isSoundMuted == 'on') {
				var audio = document.createElement('audio');
				audio.src = soundPath;
				audio.play();
			}
		}

		return PlaySound;
	})();

	return {
		PlaySound: PlaySound
	};
});