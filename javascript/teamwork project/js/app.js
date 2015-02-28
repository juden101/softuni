require.config({
	paths: {
		// Libraries
		jquery: 'bower_components/jquery/dist/jquery',
		kinetic: 'bower_components/kineticjs//kinetic',
		raphael: 'bower_components/raphael/raphael',

		// Modules
		renderer: 'game/renderer',
		config: 'game/config',
		objects: 'game/objects',
		gameManager: 'game/game-manager',
		menu: 'game/menu',
		sounds: 'game/sounds',
		globalConstants: 'game/global-constants'
	}
});

requirejs(['renderer', 'objects', 'gameManager', 'menu'], function(renderer, GameObjects, GameManager, menu) {
	// console.log(renderer.status);
	GameManager.init();
});