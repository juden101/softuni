<?php
	function my_header($title, $description, $keywords){
?>
<!doctype html>
<html lang="en">
   <head>
      <meta charset="utf-8">
      <meta name="viewport" content="width=device-width, initial-scale=1">
      <meta name="description" content="<?php echo $description ?>">
      <meta name="keywords" content="<?php echo $keywords ?>">
      <meta name="author" content="Salal Berry Team">
      <link rel="icon" href="images/favicon.png">
      <title><?php echo $title ?></title>
  	  <script src="http://code.jquery.com/jquery-1.11.0.min.js"></script>
      <link href="css/bootstrap.css" rel="stylesheet" />
      <link href="css/styles.css" rel="stylesheet" />
      <link rel="stylesheet" type="text/css" media="screen" href="http://cdnjs.cloudflare.com/ajax/libs/fancybox/1.3.4/jquery.fancybox-1.3.4.css" />
   	  <script src="http://code.jquery.com/jquery-migrate-1.2.1.min.js"></script>
	  <script src="http://cdnjs.cloudflare.com/ajax/libs/fancybox/1.3.4/jquery.fancybox-1.3.4.pack.min.js"></script>
	  <script src="js/fancybox.js"></script>
	  <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>	  <script src="js/toggle.js"></script>
	  <script src="js/are-you-sure.js"></script>
   </head> 
   <body>
          
		
      <header>
            <div class="navbar navbar-inverse navbar-fixed-top green" role="navigation">
               <div class="container">
    
    

<nav>
   <div class="container">
      <div class="navbar-header">
         <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar-collapse-8">
         <span class="sr-only">Toggle navigation</span>
         <span class="icon-bar"></span>
         <span class="icon-bar"></span>
         <span class="icon-bar"></span>
         </button>
         <div class="navbar-header">
            <h1><a class="navbar-brand" href="index.php"><strong>green</strong>uni<sup>&reg;</sup></a></h1>
         </div>
      </div>
      <div class="collapse navbar-collapse" id="navbar-collapse-8">
         <ul class="nav navbar-nav">
            <li><a title="news" href="index.php" role="button">Начало</a></li>
            <li>
               <div class="dropdown">
                  <button class="btn btn-default dropdown-toggle" type="button" id="dropdownMenu1" data-toggle="dropdown">
                  Университетът
                  <span class="caret"></span>
                  </button>
                  <ul class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1">
                     <li role="presentation"><a role="menuitem" tabindex="-1" href="about.php">За нас</a></li>
                     <li role="presentation" class="divider"></li>
                     <li role="presentation"><a role="menuitem" tabindex="-1" href="apply.php">Кандидатстване</a></li>
                     <li role="presentation"><a role="menuitem" tabindex="-1" href="hostel.php">Общежития</a></li>
                     <li role="presentation" class="divider"></li>
                     <li role="presentation"><a role="menuitem" tabindex="-1" href="staff.php">Състав</a></li>
                     <li role="presentation"><a role="menuitem" tabindex="-1" href="gallery.php">Галерия</a></li>
                  </ul>
               </div>
            </li>
            <li><a title="mission" href="majors.php" role="button">Специалности</a></li>
            <li><a title="funny" href="initiatives.php" role="button">Инициативи</a></li>
            <li><a title="gallery" href="science.php" role="button">Наука</a></li>
            <li><a title="cotacts" href="contacts.php" role="button">Контакти</a></li>
         </ul>
      </div>
      <!-- /.navbar-collapse -->
   </div>
</nav>
    
   

        
               </div>
            </div>
       
      </header>
<?php
} // end my_header()

	function my_foother(){
?>		
		<footer>
			<div class="container">
				<p class="text-muted">&copy; Salal Berry Team 2014<a href="http://softuni.bg">SoftUni.bg</a>
	
	  <a href="http://validator.w3.org/check?uri=referer" target="_blank">
                    <img src="images/html5-validator-icon.png" alt="HTML5 Validator">
                </a>
                <a href="http://jigsaw.w3.org/css-validator/check/referer" target="_blank">
                    <img src="images/css3-validator-icon.png" alt="CSS3 Validator">
                </a>
	
			</p>
			
			</div>
      </footer>
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script> 
           <script src="js/bootstrap.min.js"></script>
   </body>
</html>
<?php 
	}
?>