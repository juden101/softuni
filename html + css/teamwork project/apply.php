<?php
include 'functions.php';
$title = "Условия за кандидатстване в нашия университет | GreenUni";
$description = "Необходими условия за кандидатстване в нашия университет";
$keywords = "кандидатстване,университет";

my_header($title, $description, $keywords);
?>
<!-- Modal -->
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-body">
        <img class="are-you-sure" src="images/are-you-sure1.jpg" alt="" />
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-primary" data-dismiss="modal">Не</button>
        <button type="button" class="btn btn-primary i-am-sure">Да</button>
      </div>
    </div>
  </div>
</div>
<!-- end Modal -->

<section>
    <div class="container">
        <div class="row long">
            <div class="col-md-6">
                <h2 class="top-distance">Кандидатстване</h2>
                <p class="indent">
                    Необходими условия за кандидатстване в нашия университет.
                </p>
            </div>
            <div class="col-md-6">
                <img src="images/apply.jpg" class="right" alt=""  />
            </div>
        </div>

        <div class="row apply">
            <div class="col-md-4">
                <h2>Диплома за завършен SoftUni</h2>
                <p>
                    За да кандидатствате в нашия университет е необходимо да притежавате диплома <span class="important emphasized">ЛИЧНО</span> връчена от <span class="important emphasized">Светлин Наков</span>.
                </p>
                <p>
                    <img class="fancybox" src="images/nakov-award.jpg" alt=""  />
                </p>
            </div>
            <div class="col-md-4">
                <h2>Завършен БЕЗПЛАТЕН курс по озеленяване НИВО #0</h2>
                <p>
                    Ако все още не сте записали БЕЗПЛАТНИЯТ ни курс ниво #0 побързайте да го направите от 
                    <!-- Button trigger modal -->
                    <button class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal">
                      тук
                    </button>
                </p>
                <p>
                    <img class="fancybox" src="images/greening-course.jpg" alt=""  />
                </p>
            </div>
            <div class="col-md-4">
                <h2>Приемен изпит</h2>
                <p>
                    Изпитът се провеждат в случайни офиси на нищо неподозиращи високо поставени в йерархията хора. Разпределението по офиси е строго секретно - постава се в facebook станицата ни  ден преди провеждане на изпита.
                </p>
                <p>
                    Изпитните работи са анонимни. Кандидат-студента попълва данните си във facebook страцита ни. Така се гарантира, че проверяването на изпитните работи ще бъде обективно. При доказан опит за измама или нарушаване на анонимността на конкурса, работата на кандидата се анулира, a участието - прекратява.
                </p>
                <p>
                    <img class="fancybox" src="images/grass-laptop.jpg" alt=""  />
                </p>
            </div>
        </div>

        <div class="row">
            <div class="col-md-4">
                <h2>Хардуерни компетенции</h2>
                <p>
                     Необходимо е да знаете как се разглобяват всякакъв вид офис техника, портативни устройства, домашна техника.
                </p>
                <p>
                    <img class="fancybox" src="images/destinguish.jpg" alt=""  />
                </p>
            </div>
            <div class="col-md-4">
                <h2>Софтуерни компетенции</h2>
                <p>
                     Необходимо е да знаете как се преодоляват дребни и досадни софтуерни пречки.
                </p>
                <p>
                    <img class="fancybox" src="images/hacker.jpg" alt=""  />
                </p>
            </div>
        </div>

        <hr>

    </div>
</section>

<?php
my_foother();
?>      