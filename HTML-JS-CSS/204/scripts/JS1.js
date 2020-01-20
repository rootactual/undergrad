// variables
var canvas = document.querySelector('canvas');//looks for <canvas> in html
var c = canvas.getContext('2d'); // drawing variables to just 'c'
canvas.width = 1000; // set wid, do not add 'px' to the end
canvas.height = 600; // set hei, ^^

// functions
//function rCol() {
//    var r = ('0' + Math.floor(Math.random() * 256).toString(16)).substr(-2), 
//        g = ('0' + Math.floor(Math.random() * 256).toString(16)).substr(-2),
//        b = ('0' + Math.floor(Math.random() * 256).toString(16)).substr(-2);
//    return '#' + r + g + b;
//}

// array

//var cArr = ['#FF6633', '#FFB399', '#FF33FF', '#FFFF99', '#00B3E6', 
//		  		  '#E6B333', '#3366E6', '#999966', '#99FF99', '#B34D4D',
//		  		  '#80B300', '#809900', '#E6B3B3', '#6680B3', '#66991A', 
//		  		  '#FF99E6', '#CCFF1A', '#FF1A66', '#E6331A', '#33FFCC',
//		  		  '#66994D', '#B366CC', '#4D8000', '#B33300', '#CC80CC', 
//				  '#66664D', '#991AFF', '#E666FF', '#4DB3FF', '#1AB399',
//		  		  '#E666B3', '#33991A', '#CC9999', '#B3B31A', '#00E680', 
//		  		  '#4D8066', '#809980', '#E6FF80', '#1AFF33', '#999933',
//		 		  '#FF3380', '#CCCC00', '#66E64D', '#4D80CC', '#9900B3', 
//		  		  '#E64D66', '#4DB380', '#FF4D4D', '#99E6E6', '#6666FF'];
//				  Array courtesy of https://gist.github.com/mucar/3898821

// circs loop
for (var i = 0; i < 100; i++) {
    var j = Math.floor(Math.random() * 50) + 1;
    var x = Math.random() * canvas.width;
    var y = Math.random() * canvas.height;
    //var col = cArr(Math.floor(Math.random() * cArr.length));
    //var col = rCol();
    //var col = '#' + Math.floor(Math.random() * 16777215).toString(16); // 'one-liner' courtesy of Paul Irish @ www.paulirish.com, concantenation is wonderful
    var col = '#' + ('00000' + (Math.random() * 16777216 << 0).toString(16)).substr(-6); // Concept and code: https://www.redips.net/javascript/random-color-generator/
    c.beginPath();
    c.arc(x, y, j, 0, Math.PI * 2, false);
    c.strokeStyle = col;
    c.stroke();
}
