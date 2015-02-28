define([], function () {
	return {
		keyCode: {
            space: 32,
			left: 37,
			right: 39,
			up: 38,
            down: 40
		},
		sounds: {
			jump: 'music/jump.wav',
			shoot: 'music/shoot.mp3',
			been_shot: 'music/been_shot.wav'
		},
		initialPosition: {
			ninja: {
				x: 800,
				y: 470
			},
			castle: {
				x: 20,
				y: 20
			},
			wizard: {
				x: 440,
				y: 368
			}
		},
        boundry: {
            left: 650,
            right: 980,
            bottom: 470,
            top: 230
        },
		ninja: {
			jumpHeight: 150,
			fallHeight: 20,
	        moveDistance: 50,
			width: 186,
			height: 185,
		},
		castle: {
			width: 537,
			height: 631
		},
		shuriken: {
			numPoints: 5,
			innerRadius: 8,
			outerRadius: 20,
			fill: 'yellow',
			stroke: 'black',
			strokeWidth: 4,
			width: 10,
			height: 10,
			moveDistance: 20,
			reloadTime: 300,
			rotationAngle: 25
		},
		wizard: {
			width: 140,
			height: 141
		},
		jokes: {
			joke: [
				'Q: "Whats the object-oriented way to become wealthy?"\n\nA: Inheritance',
				'Q: "How do you tell an introverted computer scientist from an extroverted computer scientist?"\n\nA: An extroverted computer scientist looks at your shoes when he talks to you.',
				'Q: "Why do programmers always mix up Halloween and Christmas?"\n\nA: Because Oct 31 == Dec 25!'
			]
		}
	};
});
