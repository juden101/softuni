define(['kinetic', 'config', 'globalConstants'], function (Kinetic, config, Constant) {
	'use strict';

	// Kinetic setup
	var stage = new Kinetic.Stage({
		container: 'game-container',
		width: config.screen.width,
		height: config.screen.height
	});

	// Setting background layer
	var backgroundLayer = new Kinetic.Layer();
	var backgroundImageObj = new Image();
	backgroundImageObj.src = 'img/background.jpg';

	stage.add(backgroundLayer); 
	backgroundLayer.setZIndex(0);

	// Setting front layer
	var frontLayer = new Kinetic.Layer();
	stage.add(frontLayer);
	frontLayer.setZIndex(1);

	var infoLayer = new Kinetic.Layer();
	stage.add(infoLayer); 
	infoLayer.setZIndex(2);

	var questionLayer = new Kinetic.Layer();
	stage.add(questionLayer);

	function drawImageObjects (gameObjects) {
		if (!gameObjects) {
			return;
		}

		for (var i = 0; i < gameObjects.length; i++) {
			var currentObject = gameObjects[i];

			var currentImage = new Kinetic.Image({
				x: currentObject.x,
				y: currentObject.y,
				image: currentObject.image,
				width: currentObject.width,
				height: currentObject.height
			});

			frontLayer.add(currentImage);
			frontLayer.draw();
		}
	}

	function drawShurikenObjects (shurikenObjects) {
		if (!shurikenObjects) {
			return;
		}

		for (var i = 0; i < shurikenObjects.length; i++) {
			var currentShurikenObject = shurikenObjects[i];

			var shuriken = new Kinetic.Star({
				x: currentShurikenObject.x,
				y: currentShurikenObject.y,
				numPoints: currentShurikenObject.numPoints,
				innerRadius: currentShurikenObject.innerRadius,
				outerRadius: currentShurikenObject.outerRadius,
				fill: currentShurikenObject.fill,
				stroke: currentShurikenObject.stroke,
				strokeWidth: currentShurikenObject.strokeWidth
			});

			shuriken.rotate(currentShurikenObject.angle);

			frontLayer.add(shuriken);
			frontLayer.draw();

		}
	}

	function drawBoltObjects (boltObjects) {
		if (!boltObjects) {
			return;
		}

		for (var i = 0; i < boltObjects.length; i++) {
			var currentBoltObject = boltObjects[i];

			var currentBoltImage = new Kinetic.Image({
				x: currentBoltObject.x,
				y: currentBoltObject.y,
				image: currentBoltObject.image,
				width: currentBoltObject.width,
				height: currentBoltObject.height
			});

			frontLayer.add(currentBoltImage);
			frontLayer.draw();
		}
	}

	function drawQuestionBox (questionBox) {
		var questionBox = new Kinetic.Rect({
			x: stage.width() / 1.9 - (stage.width() * 0.75) / 5,
			y: stage.height() / 2 - (stage.height() * 0.75) / 2,	
			width: stage.width() * 0.35,
			height: stage.height() * 0.2,
			fill: 'white',
			opacity: 0.4,
			stroke: 'black',
			strokeWidth: 4,
			cornerRadius: 10,
			dash: [103, 1],
			shadowColor: 'gray',
			shadowBlur: 10,
			shadowOffset: {x:10,y:10},
			shadowOpacity: 0.2,
		});

		var questionText = new Kinetic.Text({
			x: stage.width() / 1.9 - (stage.width() * 0.75) / 5,
			y: stage.height() / 2 - (stage.height() * 0.75) / 2,	
			text: Constant.jokes.joke[Math.floor(Math.random() * Constant.jokes.joke.length)],
			fontSize: 18,
			fontFamily: 'Calibri',
			fill: '#555',
			width: stage.width() * 0.35,
			height: stage.height() * 0.3,
			padding: 20,
			align: 'center'
		});

		questionLayer.add(questionBox);
		questionLayer.add(questionText);
		questionLayer.draw();
	}

	var damageBar;
	
	function drawHealthBar() {
		var healthBarBackground = new Kinetic.Rect({
			x: 100,
			y: 30,
			width: 150,
			height: 30,
			fill: 'white',
			stroke: 'black',
			strokeWidth: 5
		});

		damageBar = new Kinetic.Rect({
			x: 100,
			y: 30,
			width: 150,
			height: 30,
			fill: 'red',
			stroke: 'black',
			strokeWidth: 5
		});

		infoLayer.add(healthBarBackground);
		infoLayer.draw();

		infoLayer.add(damageBar);
		infoLayer.draw();
	}

	function updateHealthBar (health) {
		var damage = (health / 100) * 150
		damageBar.size({width: damage})

		if(damage == 0){
			damageBar.remove();
			drawQuestionBox();
		}

		infoLayer.draw();
	}


	var ninjaDamageBar;
	function drawNinjaHealthBar() {
		var ninjaHealthBarBackground = new Kinetic.Rect({
			x: 800,
			y: 30,
			width: 150,
			height: 30,
			fill: 'white',
			stroke: 'black',
			strokeWidth: 5
		});

		ninjaDamageBar = new Kinetic.Rect({
			x: 800,
			y: 30,
			width: 150,
			height: 30,
			fill: 'red',
			stroke: 'black',
			strokeWidth: 5
		});

		infoLayer.add(ninjaHealthBarBackground);
		infoLayer.draw();

		infoLayer.add(ninjaDamageBar);
		infoLayer.draw();
	}

	function updateNinjaHealthBar (health) {
		var damage = (health / 100) * 150
		ninjaDamageBar.size({width: damage})

		if(damage == 0){
			ninjaDamageBar.remove();
		}

		infoLayer.draw();
	}


	function clear() {
		frontLayer.destroyChildren();
	}

	// Adding the background image
	backgroundImageObj.addEventListener('load', function () {
		var backgroundImage = new Kinetic.Image({
			image: backgroundImageObj
		});

		backgroundLayer.add(backgroundImage);
		backgroundLayer.draw();
	});

	return {
		drawImageObjects: drawImageObjects,
		clear: clear,
		drawShurikenObjects: drawShurikenObjects,
		drawHealthBar: drawHealthBar,
		updateHealthBar: updateHealthBar,
		drawNinjaHealthBar: drawNinjaHealthBar,
		updateNinjaHealthBar: updateNinjaHealthBar,
		drawBoltObjects: drawBoltObjects,
		drawQuestionBox: drawQuestionBox
	};
});