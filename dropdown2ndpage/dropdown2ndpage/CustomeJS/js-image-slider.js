//the array with the path to the images
var pathToYourImages = ["pic1.jpg", "pic2.jpg", "pic3.jpg", "pic4.jpg"];

//a variable to hold the canvas element
var canvas = null;


//a variable to hold the canvas context
var contextForCanvas = null;
	
//a variable for the image element to be draw
var image = null;

//a variable to control which image to be displayed.
var currentImage = 0;

//when the wondow.onload happen, assing the value to the variables and then call ImageSliding.
window.onload = function() {
    canvas = document.getElementById('theCanvas');
    contextForCanvas = canvas.getContext('2d');
    image = document.createElement("img");

	ImageSliding();
};

//Performs the change on the image path and controls which will be showed
function ImageSliding() {

    //sets the image's path
    image.setAttribute('src', pathToYourImages[currentImage]);

    //control which image is being used
	currentImage = currentImage === (pathToYourImages.length - 1) ? 0 : ++currentImage;

    //sets the transparency value
	contextForCanvas.globalAlpha = 0.1;
	        
    //calls the timeout function
	setTimeout(ShowImage, 200);
}

//clears the canvas and show the new image
function ShowImage() {

    contextForCanvas.save();

    contextForCanvas.clearRect(0, 0, canvas.width, canvas.height);
	contextForCanvas.drawImage(image, 0, 0, 300, 150);
	contextForCanvas.globalAlpha += 0.1;

	contextForCanvas.globalAlpha > 0.9 ? setTimeout(ImageSliding, 3500) : setTimeout(ShowImage, 200);
}