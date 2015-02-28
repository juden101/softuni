$(document).ready(function(){
	$(".i-am-sure").click(function() {
		//event.preventDefault();
		var currentImage = $(document).find('img.are-you-sure').attr("src");
		
		if(currentImage == "images/are-you-sure1.jpg") {
			$(document).find('img.are-you-sure').attr("src", "images/are-you-sure2.jpg");
		} else if(currentImage == "images/are-you-sure2.jpg") {
			$(document).find('img.are-you-sure').attr("src", "images/are-you-sure3.jpg");
		} else if(currentImage == "images/are-you-sure3.jpg") {
			$(document).find('img.are-you-sure').attr("src", "images/are-you-sure4.jpg");
		} else if(currentImage == "images/are-you-sure4.jpg") {
			$(document).find('img.are-you-sure').attr("src", "images/are-you-sure1.jpg");
		}
	});
});