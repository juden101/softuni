<?php
include 'functions.php';
$title = "Галерия | GreenUni";
$description = "Галерия на зелен университет Salal Berry";
$keywords = "галерия, университет";

my_header($title, $description, $keywords);
?>
      <section>
         <div class="container">
             <div class="row long">
                 <div class="col-md-6">
                     <h2 class="top-distance">ГАЛЕРИЯ</h2>
                        <div class="about-us">
                            <p class="indent">
                                Из живота на един студент от <span class="important">SoftUni</span>.
                            </p>
                        </div>
                 </div>

                 <div class="col-md-6">
                     <img src="images/homework.jpg" class="right" alt="" />
                 </div>
             </div>

            <div class="row about">
               <div class="col-md-4">
                  <p>
                      <img class="fancybox" src="images/lection.jpg" alt="" />
                  </p>
               </div>
               <div class="col-md-4">
                   <p>
                       <img class="fancybox" src="images/cheat.jpg" alt="" />
                   </p>
               </div>
               <div class="col-md-4">
                   <p>
                       <img class="fancybox" src="images/problem-one.jpg" alt="" />
                   </p>
               </div>
            </div>

            <div class="row about">
               <div class="col-md-4">
                  <p>
                      <img class="fancybox" src="images/490-point.jpg" alt="" />
                  </p>
               </div>
               <div class="col-md-4">
                   <p>
                       <img class="fancybox" src="images/after-exam.jpg" alt="" />
                   </p>
               </div>
               <div class="col-md-4">
                   <p>
                       <img class="fancybox" src="images/fast-trackr.jpg" alt="" /> 
                   </p>
               </div>
            </div>

            <div class="row about">
               <div class="col-md-4">
                  <p>
                      <img class="fancybox" src="images/first-real-job.jpg" alt="" />
                  </p>
               </div>
               <div class="col-md-8">
                   <p>
                       <img class="fancybox" src="images/software_engineer-life.jpg" alt="" />
                   </p>
               </div>
            </div>

             

             <hr>
         </div>
      </section>
<?php 
my_foother();
?>      