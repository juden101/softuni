<?php
include 'functions.php';
$title = "Обучение | GreenUni";
$description = "Обучението за образователно-квалификационната степен";
$keywords = "обучение, специалности";

my_header($title, $description, $keywords);
?>
<section>
    <div class="container">
        <div class="row long">
            <div class="col-md-6">
                <h2 class="top-distance">Специалности</h2>
                <p class="indent">
                    Зеленият университет "Salal Berry" е единственото специализирано висше училище в България, което предлага образование на университетско ниво по три основни направления - архитектурен дизайн, планиране, администриране и тестване на посеви в бизнес сгради.
                </p>

                <p class="indent">
                    Обучението за образователно-квалификационната степен <span class="important">"GREEN PERSON"</span> е присъствено и онлайн. След успешно полагане на
                    <span class="important">GREEN-EXAM</span>, завършилите получават диплома за зелено образование с професионална квалификация <span class="important">"GREEN OFFICE PRANKSTER"</span>”.
                </p>
            </div>

            <div class="col-md-6">
                <img src="images/speciality_2.jpg" class="right" alt="" />
            </div>
        </div>

        <div class="row majors">
            <div class="col-md-4">
                <h2>Администриране на РедРоузес (RedRoses)</h2>
                <p>
                    <img class="fancybox" src="images/redroses.jpg" alt=""  />
                </p>
            </div>
            <div class="col-md-4">
                <h2>Цветово кодиране на скрити послания с цветни лехи</h2>
                <p>
                    <img class="fancybox" src="images/promotion.jpg" alt="" />
                </p>
            </div>
            <div class="col-md-4">
                <h2>Хардуер за поддържане на оптимални условия за растеж</h2>
                <p>
                    <img class="fancybox" src="images/plant.jpg" alt="" />
                </p>
            </div>
        </div>

        <div class="row">
            <div class="col-md-4">
                <h2>Планиране на посевните дейности в офиса</h2>
                <p>
                    <img class="fancybox" src="images/planting.jpg" alt="" />
                </p>
            </div>
            <div class="col-md-4">
                <h2>Архитектурен дизайн на зелени площи</h2>
                <p>
                    <img class="fancybox" src="images/architecture_design.jpg" alt="" />
                </p>
            </div>
            <div class="col-md-4">
                <h2>Тестване мекотата на тревните площи в бизнес сграда</h2>
                <p>
                    <img class="fancybox" src="images/testing.jpg" alt="" />
                </p>
            </div>
        </div>

        <hr>
    </div>
</section>
<?php
my_foother();
?>      