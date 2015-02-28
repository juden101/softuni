define(['globalConstants', 'sounds'], function (Constant, Sounds) {
	var Castle = (function () {
		function Castle (startX, startY, imagePath) {
			this.x = startX;
			this.y = startY;
			this.width = Constant.castle.width;
			this.height = Constant.castle.height;
			this.health = 100;

			this.image = new Image();
			this.image.src = imagePath;
		}

		Castle.prototype = {
			update: function () {
				return;
			},
			takeHit: function (damage) {
				this.health -= damage;
			}
		};

		return Castle;
	})();

	var Ninja = (function () {
		var images = {
			straight: new Image(),
			crouchLeft: new Image(),
			crouchLeftShoot: new Image(),
			crouchRight: new Image(),
			shootLeft: new Image(),
			shootRight: new Image(),
			fall: new Image(),
			dead: new Image()
		};

		function Ninja (startX, startY, imagePath) {
			this.x = startX;
			this.y = startY;
			this.width = Constant.ninja.width;
			this.height = Constant.ninja.height;
			this.health = 100;
			this.state = "steady";

			// Initialize images
			images.straight.src = imagePath + "/Ninja-Straight.png";
			images.crouchLeft.src = imagePath + "/Ninja-Crouch-Left.png";
			images.crouchLeftShoot.src = imagePath + "/Ninja-Crouch-Left-Shoot.png";
			images.crouchRight.src = imagePath + "/Ninja-Crouch-Right.png";
			images.shootLeft.src = imagePath + "/Ninja-Shoot-Left.png";
			images.shootRight.src = imagePath + "/Ninja-Shoot-Right.png";
			images.fall.src = imagePath + "/Ninja-Fall.png";
			images.dead.src = imagePath + "/Ninja-Dead.png";

			// Initial object image
			this.image = images.straight;
		}
		
		Ninja.prototype = {
			jump: function () {
				if (this.state == "jump" || this.state == "fall") {
					return;
				}

				this.state = "jump";
				this.image = images.straight;
				
				Sounds.PlaySound(Constant.sounds.jump);
			},
			update: function () {
				// this.image = images.straight;

				if (this.state == "steady") {
					return;
				}

				if (this.state == "jump") {
					if (this.y <= Constant.boundry.top) {
						this.state = "fall";
						this.image = images.fall;
					}
					else {
						this.y -= Constant.ninja.jumpHeight;
					}
				}
				else if (this.state == "fall") {
					if (this.y >= Constant.boundry.bottom) {
						this.state = "steady";
						this.image = images.straight;
					}
					else {
						this.y += Constant.ninja.fallHeight;
					}
				}
			},
			moveLeft: function () {
		        if (this.x > Constant.boundry.left) {
		           this.x -= Constant.ninja.moveDistance;
		        }
			},
			moveRight: function () {
		        if (this.x < Constant.boundry.right) {
		            this.x += Constant.ninja.moveDistance;
		        }
			},
	       	crouch: function () {
				if (this.state == "steady") {
					this.state = "crouch";
					this.image = images.crouchLeft;
				}
	        },
			shoot: function () {
				var that = this;
				var previousImg = this.image;

				if (this.state == "crouch") {
					this.image = images.crouchLeftShoot;
				}
				else {
		            this.image = images.shootLeft;
				}

	            setTimeout(function () {
	            	that.image = previousImg;
	            }, 100);
				
				Sounds.PlaySound(Constant.sounds.shoot);
	        },
	        takeHit: function (damage) {
	        	this.health -= damage;
	        },
	        die: function () {
	        	this.image = images.dead;
	        }
		}

		return Ninja;
	})();

	var Wizard = (function () {
		var images = {
			idle: new Image(),
			attack: new Image(),
			dead: new Image()
		};

		function Wizard (startX, startY, imagePath) {
			this.x = startX;
			this.y = startY;
			this.width = Constant.wizard.width;
			this.height = Constant.wizard.height;

			images.idle.src = imagePath + '/wizard-idle.png';
			images.attack.src = imagePath + '/wizard-attack.png';
			images.dead.src = imagePath + '/wizard-dead.png';

			this.image = images.idle;
		}
		
		Wizard.prototype = {
			update: function () {
				return;
			},
			shoot: function () {
				var that = this;
				this.image = images.attack;

	            setTimeout(function () {
	            	that.image = images.idle;
	            }, 100);
			},
			die: function () {
				this.image = images.dead;
			}
		};

		return Wizard;
	})();

	var Shuriken = (function () {
		function Shuriken (startX, startY) {
			this.x = startX;
			this.y = startY;
			this.numPoints = Constant.shuriken.numPoints;
			this.innerRadius = Constant.shuriken.innerRadius;
			this.outerRadius = Constant.shuriken.outerRadius;
			this.fill = Constant.shuriken.fill;
			this.stroke = Constant.shuriken.stroke;
			this.strokeWidth = Constant.shuriken.strokeWidth;
			this.width = Constant.shuriken.width;
			this.height = Constant.shuriken.height;
			this.angle = 0;
			this.damage = 5;
		}

		Shuriken.prototype = {
			update: function () {
				this.x -= Constant.shuriken.moveDistance;
				this.angle += 25;
			}
		};

		return Shuriken;
	})();

	var Bolt = (function () {
		function Bolt (startX, startY, imageSrc) {
			this.x = startX;
			this.y = startY;
			this.width = 150;
			this.height = 79;
			this.damage = 5;
			this._yDeviation = (Math.random() - 0.5) * 10;

			this.image = new Image();
			this.image.src = imageSrc;
		}

		Bolt.prototype = {
			update: function () {
				this.x += 10;
				this.y += this._yDeviation;
			}
		};

		return Bolt;
	})();

	return {
		Castle: Castle,
		Ninja: Ninja,
		Shuriken: Shuriken,
		Wizard: Wizard,
		Bolt: Bolt
	};
});
