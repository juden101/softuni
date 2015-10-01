<h2 class="form-group">Username: <?= ucfirst($this->_viewBag['body']->getUsername()) ?>
    <?php if ($this->_viewBag['body']->getIsAdmin()) : ?>
        <span class="label label-danger">Admin</span>
    <?php endif; ?>
</h2>

<?php if (strtolower($this->_viewBag['body']->getUsername()) === strtolower(\Framework\App::getInstance()->getUsername())) {
    \Framework\FormViewHelper::init()
        ->initForm($this->getPath() . 'user/changePass', ['class' => 'form-group'], 'put')
        ->initLabel()->setValue("Old Password")->setAttribute('for', 'oldPassword')->create()
        ->initPasswordBox()->setAttribute('id', 'oldPassword')->setName('oldPassword')->setAttribute('class', 'form-control input-md')->create()
        ->initLabel()->setValue("New Password")->setAttribute('for', 'newPassword')->create()
        ->initPasswordBox()->setAttribute('id', 'newPassword')->setName('newPassword')->setAttribute('class', 'form-control input-md')->create()
        ->initLabel()->setValue("Confirm Password")->setAttribute('for', 'conPassword')->create()
        ->initPasswordBox()->setAttribute('id', 'conPassword')->setName('confirm')->setAttribute('class', 'form-control input-md')->create()
        ->initSubmit()->setAttribute('value', 'Change password')->setAttribute('class', 'btn btn-default')->create()
        ->render();
}