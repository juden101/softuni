<?php

function validateField($name, $value) {
    if($name == 'firstName') {
        if(!preg_match('/^[a-zA-Z]{2,20}$/', $value)) {
            return 'First name should be between 2 and 20 letters!';
        }
    }
    else if($name == 'lastName') {
        if(!preg_match('/^[a-zA-Z]{2,20}$/', $value)) {
            return 'Last name should be between 2 and 20 letters!';
        }
    }
    else if($name == 'languageName') {
        $result = '';
        $looped = false;

        foreach($value as $languageName) {
            if(!$looped) {
                $looped = true;
            }
            else {
                if($languageName == '') {
                    continue;
                }
            }

            if(!preg_match('/^[a-zA-Z]{2,20}$/', $languageName)) {
                $result = 'Language name should be between 2 and 20 letters!';
            }
        }

        if($result != '') {
            return $result;
        }
    }
    else if($name == 'programmingLanguageName') {
        $result = '';
        $looped = false;

        foreach($value as $languageName) {
            if(!$looped) {
                $looped = true;
            }
            else {
                if($languageName == '') {
                    continue;
                }
            }

            if(!preg_match('/^[a-zA-Z#\.]{2,20}$/', $languageName)) {
                $result = 'Programming language name should be between 2 and 20 letters!';
            }
        }

        if($result != '') {
            return $result;
        }
    }
    else if($name == 'companyName') {
        if(!preg_match('/^[a-zA-Z0-9]{2,20}$/', $value)) {
            return 'Company name should be between 2 and 20 letters and numbers!';
        }
    }
    else if($name == 'phoneNumber') {
        if(!preg_match('/^[0-9\+\-\s]+$/', $value)) {
            return 'Phone number should consist only numbers, and the symbols +, - and white space!';
        }
    }
    else if($name == 'email') {
        if(!preg_match('/^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+$/', $value)) {
            return 'Invalid email!';
        }
    }
}

function fieldValue($fieldName) {
    return isset($_POST[$fieldName]) && $_POST[$fieldName] != null ? $_POST[$fieldName] : null;
}

?>
<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>CV Generator</title>
    <style type="text/css">
        form {
            width: 550px;
        }

        #personal-info input[type="text"],
        #personal-info input[type="date"],
        #personal-info select {
            display: block;
        }

        #computerSkills label,
        #otherSkills label {
            display: block;
        }

        #computerSkills .programmingLanguages,
        #languages .languages {
            display: block;
        }

        #otherSkills #drivingSkills label {
            display: inline-block;
        }

        .error-messages p {
            display: block;
            width: 30%;
            padding: 15px;

            background-color: pink;
            border: 1px solid #f00;
            font-weight: bold;
            color: #f00;
            text-align: center;
        }

        table, table td {
            border: 1px solid #000;
        }

        body > table {
            margin-bottom: 15px;
        }

        table tr:first-child {
            text-align: center;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <?php
        $errorMessages = [];

        if(isset($_POST) && $_POST != null) {
            foreach($_POST as $fieldName => $fieldValue) {
                $currentResult = validateField($fieldName, $fieldValue);

                if($currentResult != '') {
                    $errorMessages[] = $currentResult;
                }
            }
        }

        if(isset($errorMessages) && $errorMessages != null) {
            echo '<section class="error-messages">';
            foreach ($errorMessages as $errorMessage) {
                echo '<p>' . $errorMessage . '</p>';
            }
            echo '</section>';
        }

        if(count($_POST) == 0 || count($errorMessages) > 0) {
            ?>
            <form method="POST">
                <fieldset id="personal-info">
                    <legend>Personal Information</legend>

                    <section>
                        <input type="text" name="firstName" placeholder="First Name"
                               value="<?= fieldValue('firstName'); ?>"/>
                        <input type="text" name="lastName" placeholder="Last Name"
                               value="<?= fieldValue('lastName'); ?>"/>
                        <input type="text" name="email" placeholder="Email" value="<?= fieldValue('email'); ?>"/>
                        <input type="text" name="phoneNumber" placeholder="Phone Number"
                               value="<?= fieldValue('phoneNumber'); ?>"/>
                    </section>

                    <section>
                        <label for="female">Female</label>
                        <input type="radio" name="gender" id="female"
                               value="female" <?= fieldValue('gender') == 'male' ? null : 'checked'; ?> />
                        <label for="male">Male</label>
                        <input type="radio" name="gender" id="male"
                               value="male" <?= fieldValue('gender') == 'male' ? 'checked' : null; ?> />
                    </section>

                    <section>
                        <label for="birthDate">Birth Date</label>
                        <input type="date" id="birthDate" name="birthDate" value="<?= fieldValue('birthDate'); ?>"/>
                        <label for="nationality">Nationality</label>
                        <select id="nationality" name="nationality">
                            <option value="Bulgarian" selected>Bulgarian</option>
                            <option value="British" <?= fieldValue('nationality') == 'British' ? 'selected' : null; ?>>
                                British
                            </option>
                            <option value="German" <?= fieldValue('nationality') == 'German' ? 'selected' : null; ?>>
                                German
                            </option>
                        </select>
                    </section>
                </fieldset>

                <fieldset>
                    <legend>Last Work Position</legend>
                    <section>
                        <label for="companyName">Company Name</label>
                        <input type="text" id="companyName" name="companyName"
                               value="<?= fieldValue('companyName'); ?>"/>
                    </section>

                    <section>
                        <label for="companyFrom">From</label>
                        <input type="date" id="companyFrom" name="companyFrom"
                               value="<?= fieldValue('companyFrom'); ?>"/>
                    </section>

                    <section>
                        <label for="companyTo">To</label>
                        <input type="date" id="companyTo" name="companyTo" value="<?= fieldValue('companyTo'); ?>"/>
                    </section>
                </fieldset>

                <fieldset id="computerSkills">
                    <legend>Computer Skills</legend>
                    <section id="computerLanguages">
                        <label for="programmingLanguageName">Programming Languages</label>

                        <?php

                        if (isset($_POST['programmingLanguageName']) && $_POST['programmingLanguageName'] != null) {
                            for ($i = 0; $i < count($_POST['programmingLanguageName']); $i++) {
                                if ($_POST['programmingLanguageName'][$i] == '') {
                                    continue;
                                }
                                ?>
                                <section class="programmingLanguages">
                                    <input type="text" id="programmingLanguageName" name="programmingLanguageName[]"
                                           value="<?= $_POST['programmingLanguageName'][$i]; ?>"/>
                                    <select name="programmingLanguageSkill[]">
                                        <option value="beginner" selected>Beginner</option>
                                        <option
                                            value="programmer" <?= $_POST['programmingLanguageSkill'][$i] == 'programmer' ? 'selected' : null; ?>>
                                            Programmer
                                        </option>
                                        <option
                                            value="ninja" <?= $_POST['programmingLanguageSkill'][$i] == 'ninja' ? 'selected' : null; ?>>
                                            Ninja
                                        </option>
                                    </select>
                                </section>
                            <?php
                            }
                        }
                        ?>

                        <section class="programmingLanguages">
                            <input type="text" id="programmingLanguageName" name="programmingLanguageName[]"/>
                            <select name="programmingLanguageSkill[]">
                                <option value="beginner">Beginner</option>
                                <option value="programmer">Programmer</option>
                                <option value="ninja">Ninja</option>
                            </select>
                        </section>
                    </section>

                    <section>
                        <button type="button" id="remove-computer-language">Remove Language</button>
                        <button type="button" id="add-computer-language">Add Language</button>
                    </section>
                </fieldset>

                <fieldset id="otherSkills">
                    <legend>Other Skills</legend>
                    <section id="languages">
                        <label for="languageName">Languages</label>

                        <?php
                        if (isset($_POST['languageName']) && $_POST['languageName'] != null) {
                            for ($i = 0; $i < count($_POST['languageName']); $i++) {
                                if ($_POST['languageName'][$i] == '') {
                                    continue;
                                }
                                ?>
                                <section class="languages">
                                    <input type="text" id="languageName" name="languageName[]"
                                           value="<?= $_POST['languageName'][$i]; ?>"/>

                                    <select name="languageComprehension[]">
                                        <option selected>-Comprehension-</option>
                                        <option
                                            value="beginner" <?= $_POST['languageComprehension'][$i] == 'beginner' ? 'selected' : null; ?>>
                                            Beginner
                                        </option>
                                        <option
                                            value="intermediate" <?= $_POST['languageComprehension'][$i] == 'intermediate' ? 'selected' : null; ?>>
                                            Intermediate
                                        </option>
                                        <option
                                            value="advanced" <?= $_POST['languageComprehension'][$i] == 'advanced' ? 'selected' : null; ?>>
                                            Advanced
                                        </option>
                                    </select>

                                    <select name="languageReading[]">
                                        <option selected>-Reading-</option>
                                        <option
                                            value="beginner" <?= $_POST['languageReading'][$i] == 'beginner' ? 'selected' : null; ?>>
                                            Beginner
                                        </option>
                                        <option
                                            value="intermediate" <?= $_POST['languageReading'][$i] == 'intermediate' ? 'selected' : null; ?>>
                                            Intermediate
                                        </option>
                                        <option
                                            value="advanced" <?= $_POST['languageReading'][$i] == 'advanced' ? 'selected' : null; ?>>
                                            Advanced
                                        </option>
                                    </select>

                                    <select name="languageWriting[]">
                                        <option selected>-Writing-</option>
                                        <option
                                            value="beginner" <?= $_POST['languageWriting'][$i] == 'beginner' ? 'selected' : null; ?>>
                                            Beginner
                                        </option>
                                        <option
                                            value="intermediate" <?= $_POST['languageWriting'][$i] == 'intermediate' ? 'selected' : null; ?>>
                                            Intermediate
                                        </option>
                                        <option
                                            value="advanced" <?= $_POST['languageWriting'][$i] == 'advanced' ? 'selected' : null; ?>>
                                            Advanced
                                        </option>
                                    </select>
                                </section>
                            <?php
                            }
                        }
                        ?>

                        <section class="languages">
                            <input type="text" id="languageName" name="languageName[]"/>

                            <select name="languageComprehension[]">
                                <option>-Comprehension-</option>
                                <option value="beginner">Beginner</option>
                                <option value="intermediate">Intermediate</option>
                                <option value="advanced">Advanced</option>
                            </select>

                            <select name="languageReading[]">
                                <option>-Reading-</option>
                                <option value="beginner">Beginner</option>
                                <option value="intermediate">Intermediate</option>
                                <option value="advanced">Advanced</option>
                            </select>

                            <select name="languageWriting[]">
                                <option>-Writing-</option>
                                <option value="beginner">Beginner</option>
                                <option value="intermediate">Intermediate</option>
                                <option value="advanced">Advanced</option>
                            </select>
                        </section>
                    </section>

                    <section>
                        <button type="button" id="remove-language">Remove Language</button>
                        <button type="button" id="add-language">Add Language</button>
                    </section>

                    <section id="drivingSkills">
                        <label for="b-category">B</label>
                        <input type="checkbox" name="b-category" id="b-category"
                               value="1"  <?= fieldValue('b-category') == '1' ? 'checked' : null; ?> />

                        <label for="c-category">C</label>
                        <input type="checkbox" name="c-category" id="c-category"
                               value="1"  <?= fieldValue('c-category') == '1' ? 'checked' : null; ?> />

                        <label for="a-category">A</label>
                        <input type="checkbox" name="a-category" id="a-category"
                               value="1"  <?= fieldValue('a-category') == '1' ? 'checked' : null; ?> />
                    </section>
                </fieldset>

                <input type="submit" value="Generate CV"/>
            </form>
    <?php
        }
        else {
            ?>
            <table>
                <tr>
                    <td colspan="2">Personal Information</td>
                </tr>
                <tr>
                    <td>First Name</td>
                    <td><?= $_POST['firstName']; ?></td>
                </tr>
                <tr>
                    <td>Last Name</td>
                    <td><?= $_POST['lastName']; ?></td>
                </tr>
                <tr>
                    <td>Email</td>
                    <td><?= $_POST['email']; ?></td>
                </tr>
                <tr>
                    <td>Phone Number</td>
                    <td><?= $_POST['phoneNumber']; ?></td>
                </tr>
                <tr>
                    <td>Gender</td>
                    <td><?= $_POST['gender']; ?></td>
                </tr>
                <tr>
                    <td>Birth Date</td>
                    <td><?= $_POST['birthDate']; ?></td>
                </tr>
                <tr>
                    <td>Nationality</td>
                    <td><?= $_POST['nationality']; ?></td>
                </tr>
            </table>

            <table>
                <tr>
                    <td colspan="2">Last Work Position</td>
                </tr>
                <tr>
                    <td>Company Name</td>
                    <td><?= $_POST['companyName']; ?></td>
                </tr>
                <tr>
                    <td>From</td>
                    <td><?= $_POST['companyFrom']; ?></td>
                </tr>
                <tr>
                    <td>To</td>
                    <td><?= $_POST['companyTo']; ?></td>
                </tr>
            </table>

            <table>
                <tr>
                    <td colspan="2">Computer Skills</td>
                </tr>
                <tr>
                    <td>Languages</td>
                    <td>
                        <table>
                            <tr>
                                <td>Programming Language</td>
                                <td>Skill Level</td>
                            </tr>
                            <?php
                            for ($i = 0; $i < count($_POST['programmingLanguageName']); $i++) {
                                if ($_POST['programmingLanguageName'][$i] == '') {
                                    continue;
                                }

                                echo '<tr><td>' . $_POST['programmingLanguageName'][$i] . '</td><td>' . $_POST['programmingLanguageSkill'][$i] . '</td></tr>';
                            }
                            ?>
                        </table>
                    </td>
                </tr>
            </table>

            <table>
                <tr>
                    <td colspan="2">Other Skills</td>
                </tr>
                <tr>
                    <td>Languages</td>
                    <td>
                        <table>
                            <tr>
                                <td>Language</td>
                                <td>Comprehension</td>
                                <td>Reading</td>
                                <td>Writing</td>
                            </tr>
                            <?php
                            for ($i = 0; $i < count($_POST['languageName']); $i++) {
                                if ($_POST['languageName'][$i] == '') {
                                    continue;
                                }

                                echo '<tr><td>' . $_POST['languageName'][$i] . '</td><td>' . $_POST['languageComprehension'][$i] . '</td><td>' . $_POST['languageReading'][$i] . '</td><td>' . $_POST['languageWriting'][$i] . '</td></tr>';
                            }
                            ?>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>Driver's license</td>
                    <?php
                    $licenses = '';

                    if(isset($_POST['b-category']) && $_POST['b-category'] != null) {
                        $licenses .= 'B, ';
                    }
                    if(isset($_POST['c-category']) && $_POST['c-category'] != null) {
                        $licenses .= 'C, ';
                    }
                    if(isset($_POST['a-category']) && $_POST['a-category'] != null) {
                        $licenses .= 'A, ';
                    }

                    if(mb_strlen($licenses) > 0) {
                        $licenses = mb_substr($licenses, 0, -2);
                    }
                    ?>
                    <td><?= $licenses;?></td>
                </tr>
            </table>
        <?php
        }
    ?>
    <script type="text/javascript">
        var addComputerLanguageButton = document.getElementById('add-computer-language');
        var removeComputerLanguageButton = document.getElementById('remove-computer-language');

        var addLanguageButton = document.getElementById('add-language');
        var removeLanguageButton = document.getElementById('remove-language');

        addComputerLanguageButton.addEventListener('click', function(e) {
            e.preventDefault();

            var newLanguageFields = document.createElement('section');
            newLanguageFields.className = 'programmingLanguages';

            newLanguageFields.innerHTML = '\
            <input type="text" id="programmingLanguageName" name="programmingLanguageName[]" />\
                <select name="programmingLanguageSkill[]">\
                    <option value="beginner" selected>Beginner</option>\
                    <option value="programmer">Programmer</option>\
                    <option value="ninja">Ninja</option>\
                </select>\
            </section>';

            document.getElementById('computerLanguages').appendChild(newLanguageFields);
        });

        removeComputerLanguageButton.addEventListener('click', function(e) {
            e.preventDefault();

            var languages = document.getElementById('computerLanguages');
            var languageFields = languages.getElementsByTagName('section');

            if(languageFields.length > 1) {
                languages.removeChild(languageFields[languageFields.length - 1]);
            }
        });

        addLanguageButton.addEventListener('click', function(e) {
            e.preventDefault();

            var newLanguageFields = document.createElement('section');
            newLanguageFields.className = 'languages';

            newLanguageFields.innerHTML = '\
            <input type="text" id="languageName" name="languageName[]" />\
                <select name="languageComprehension[]">\
                    <option>-Comprehension-</option>\
                    <option value="beginner">Beginner</option>\
                    <option value="intermediate">Intermediate</option>\
                    <option value="advanced">Advanced</option>\
                </select>\
                <select name="languageReading[]">\
                    <option>-Reading-</option>\
                    <option value="beginner">Beginner</option>\
                    <option value="intermediate">Intermediate</option>\
                    <option value="advanced">Advanced</option>\
                </select>\
                <select name="languageWriting[]">\
                    <option>-Writing-</option>\
                    <option value="beginner">Beginner</option>\
                    <option value="intermediate">Intermediate</option>\
                    <option value="advanced">Advanced</option>\
                </select>\
            </section>';

            document.getElementById('languages').appendChild(newLanguageFields);
        });

        removeLanguageButton.addEventListener('click', function(e) {
            e.preventDefault();

            var languages = document.getElementById('languages');
            var languageFields = languages.getElementsByTagName('section');

            if(languageFields.length > 1) {
                languages.removeChild(languageFields[languageFields.length - 1]);
            }
        });
    </script>
</body>
</html>