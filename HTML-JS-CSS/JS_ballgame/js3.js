// original code modified from https://codepen.io/neilcarpenter/pen/oeGwD
// 

var canvas = document.querySelector('canvas');
canvas.width = 800;
canvas.height = 600;
var c = canvas.getContext('2d');

window.addEventListener('keydown',moveMe,false);
function moveMe(e) {
	switch(e.keyCode) {
		case 37:  //left
			if (me.dx > -6) {
				me.dx += -1
			}
			break;
		case 38:  //up
			if (me.dy > -6) {
				me.dy += -1
			}
			break;
		case 39:  //right
			if (me.dx < 6) {
				me.dx += 1
			}
			break;
		case 40:  //down
			if (me.dx < 6) {
				me.dy += 1
			}
			break;
	}

}

function player() {
	this.x = 400;
	this.y = 300;
	this.radius = 12;
	this.dx = -1;
	this.dy = -1;

	this.draw = function () {
		c.beginPath();
		c.arc(this.x,this.y,this.radius,0,Math.PI * 2,false);
		c.fillStyle = "blue";
		c.fill();
	}

	this.update = function () {
		if (this.x + this.radius > canvas.width ||
		this.x - this.radius < 0) {
			this.dx = -this.dx;
		}
		if (this.y + this.radius > canvas.height ||
		this.y - this.radius < 0) {
			this.dy = -this.dy;
		}
		this.x += this.dx;
		this.y += this.dy;
		this.draw();
	}
}

function Circle(x,y,dx,dy,radius) {
	this.x = x;
	this.y = y;
	this.dx = dx;
	this.dy = dy;
	this.radius = radius;
	this.minRadius = radius;
	this.color = 'green';
	this.notCaught = true;

	this.draw = function() {
		c.beginPath();
		c.arc(this.x,this.y,this.radius,0,Math.PI * 2,false);
		c.fillStyle = this.color;
		c.fill();
	}

	this.update = function() {
		if (this.x + this.radius > canvas.width ||
		this.x - this.radius < 0) {
			this.dx = -this.dx;
		}
		if (this.y + this.radius > canvas.height ||
		this.y - this.radius < 0) {
			this.dy = -this.dy;
		}
		if (me.x - this.x < 6 && me.x - this.x > -6
			&& me.y - this.y < 6 && me.y - this.y > -6) {
			this.color = 'red';
			this.notCaught = false;
		}
		this.x += this.dx;
		this.y += this.dy;

		this.draw();
	}
}

var me = new player();
var circleArray = [];
for (var i=0; i<5; i++) {
	var radius = 10;
	var x = Math.random() * (canvas.width - radius * 2) + radius;
	var y = Math.random() * (canvas.height - radius * 2) + radius;
	var dx = (Math.random() - 0.5) * 8;
	var dy = (Math.random() - 0.5) * 8;
	circleArray.push(new Circle(x,y,dx,dy,radius));
}

var playOn = true;
function animate() {
	if (playOn) {
		requestAnimationFrame(animate);
	}
	c.clearRect(0,0,canvas.width,canvas.height);
	playOn = false;
	for (var i=0; i<circleArray.length; i++) {
		circleArray[i].update();
		if (circleArray[i].notCaught) {
			playOn = true;
		}
	}
	me.update();
}

animate();
