var canvas = document.querySelector('canvas');
var c = canvas.getContext('2d');

canvas.width = window.innerWidth;
canvas.height = window.innerHeight;
//console.log(canvas);

var mouse = {
	x: undefined,
	y: undefined

}

var maxRadius = 40;
//var minRadius = 2;

var colorArray = [
	'#FF0D73',
	'#E80CD8',
	'#C300FF',
	'#780CE8',
	'#410DFF',
];

window.addEventListener('mousemove', function(event) {
	mouse.x = event.x;
	mouse.y = event.y;
	//console.log(mouse);
})

window.addEventListener('resize', function(){
	canvas.width = window.innerWidth;
	canvas.height = window.innerHeight;

	init();
});

function Circle(x, y, dx, dy, radius) {//capital letter for object
	this.x = x;
	this.y = y
	this.dx = dx;
	this.dy = dy;
	this.radius = radius;
	this.minRadius = radius; // minRad set by func, return to set
	this.color = colorArray[Math.floor(Math.random() * colorArray.length)]//.length changes with array updates

	this.draw = function(){//anonymous function
		c.beginPath();//begin circle drawing loop
		c.arc(this.x, this.y, this.radius, 0, Math.PI * 2, false);//x y var used
		c.fillStyle = this.color;
		c.fill();
	}

	this.update = function() {
			if (this.x + this.adius > innerWidth || this.x - this.radius < 0) {
				this.dx = -this.dx;//switch direction at right limit || for left limit
			}
			if (this.y + this.radius > innerHeight || this.y - this.radius < 0) {
				this.dy = -this.dy;
			}

			this.x += this.dx; //create circles +1 to x value, speed in particular direction
			this.y += this.dy; //y value

			//interactivity
			if (mouse.x - this.x < 50 && mouse.x - this.x > -50 && mouse.y -this.y < 50 && mouse.y - this.y > -50) {
				if (this.radius < maxRadius){
					this.radius += 1;
				}
			} else if (this.radius > this.minRadius){
				this.radius -= 1;
			}

	this.draw();

	}

}

var circleArray = [];
//console.log(circleArray);
function init() {

	circleArray = [];

	for (var i=0; i<800; i++){
			var radius = Math.random() * 3 + 1;//min 1.___ max 4.0
			var x = Math.random() * (innerWidth - radius * 2) + radius;//random x coord
			var y = Math.random() * (innerHeight- radius * 2) + radius;//random y coord
			var dx = (Math.random() - 0.5);//velocity, possibility +/-
			var dy = (Math.random() - 0.5);//velocity, possibility +/-

		circleArray.push(new Circle(x,y,dx,dy,radius));
	}
};

function animate(){
	requestAnimationFrame(animate); //animation request to animate func
	c.clearRect(0,0,innerWidth,innerHeight);//x,y,wid,height, clears old circle

	for (var i = 0; i < circleArray.length; i++){
		circleArray[i].update();
	}

}

init();

animate();//call function
