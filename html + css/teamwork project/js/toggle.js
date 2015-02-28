$(document).ready(function(){

$(".toggle").click(function(){
	event.preventDefault();
	
    $(this).parent().parent().find('img').slideToggle("medium");
  });
});