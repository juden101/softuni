<?php

require_once('localization.php');
require_once('database.php');

$db = Database::getInstance()->getConnection();

if (isset($_POST['text_bg'])) {
    foreach ($_POST['text_bg'] as $id => $text_bg) {
        $sql = 'UPDATE translations SET text_bg=:text_bg WHERE id=:id';
        $query = $db->prepare($sql);
        $query->execute(array(':text_bg' => $text_bg, ':id' => (int)$id));
    }
}

$resTranslations = $db->query("SELECT id, tag, text_en, text_bg FROM translations");
$translations = $resTranslations->fetchAll(PDO::FETCH_ASSOC);
?>

<form method="POST">
    <?php foreach ($translations as $translation) : ?>
        <div class="source-translation">
            <?= $translation['text_' . Localization::LANG_DEFAULT]; ?>
        </div>
        <textarea name="text_bg[<?= $translation['id']; ?>]"><?= $translation['text_bg']; ?></textarea>
    <?php endforeach; ?>
    <br />
    <input type="submit" value="Save" />
</form>