<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Modify String</title>
</head>
<body>
    <?php
    $stringInput = '';
    $optionInput = '';
    $result = '';

    if(isset($_POST['input'], $_POST['option']) && $_POST['input'] != '' && $_POST['option'] != '') {
        $stringInput = $_POST['input'];
        $optionInput = $_POST['option'];

        if($optionInput == 'checkPalindrome') {
            $currentString = strtolower(preg_replace('/[^A-Za-z0-9]/', '', $stringInput));

            if($currentString == strrev($currentString)) {
                $result = $stringInput . ' is a palindrome!';
            }
            else {
                $result = $stringInput . ' is not a palindrome!';
            }
        }
        else if($optionInput == 'reverseString') {
            $result = strrev($stringInput);
        }
        else if($optionInput == 'split') {
            $stringInput = preg_replace('/[\s]/', '', $stringInput);
            $result = implode(' ', str_split($stringInput));
        }
        else if($optionInput == 'hashString') {
            $result = crypt($stringInput);
        }
        else if($optionInput == 'shuffleString') {
            $result = str_shuffle($stringInput);
        }
    }
    ?>

    <form method="POST">
        <input type="text" name="input" value="<?= $stringInput;?>" />

        <input type="radio" name="option" value="checkPalindrome" id="checkPalindrome" <?= $optionInput == 'checkPalindrome' ? 'checked' : null;?> />
        <label for="checkPalindrome">Check Palindrome</label>

        <input type="radio" name="option" value="reverseString" id="reverseString" <?= $optionInput == 'reverseString' ? 'checked' : null;?> />
        <label for="reverseString">Reverse String</label>

        <input type="radio" name="option" value="split" id="split" <?= $optionInput == 'split' ? 'checked' : null;?> />
        <label for="split">Split</label>

        <input type="radio" name="option" value="hashString" id="hashString" <?= $optionInput == 'hashString' ? 'checked' : null;?> />
        <label for="hashString">Hash String</label>

        <input type="radio" name="option" value="shuffleString" id="shuffleString" <?= $optionInput == 'shuffleString' ? 'checked' : null;?> />
        <label for="shuffleString">Shuffle String</label>

        <input type="submit" value="Submit" />
    </form>

    <?php
    if($result != '') {
    ?>
        <p><?= $result;?></p>
    <?php
    }
    ?>
</body>
</html>