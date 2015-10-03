<div class="container">
    <div class="row">
        <div class="col-sm-6 col-md-4 col-md-offset-4">
            <h1 class="text-center login-title">Login</h1>
            <div class="account-wall">
                <?php
                \Framework\FormViewHelper::init()
                    ->initForm($this->getPath() . 'user/login', ['class' => 'form-group'], 'post')
                    ->initLabel()->setValue("Username")->setAttribute('for', 'username')->create()
                    ->initTextBox()->setName('username')->setAttribute('id', 'username')->setAttribute('class', 'form-control input-md')->create()
                    ->initLabel()->setValue("Password")->setAttribute('for', 'password')->create()
                    ->initPasswordBox()->setName('password')->setAttribute('id', 'password')->setAttribute('class', 'form-control input-md')->create()
                    ->initSubmit()->setAttribute('value', 'Login')->setAttribute('class', 'btn btn-default')->create()
                    ->render();
                ?>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6 col-md-4 col-md-offset-4">
            <h1 class="text-center login-title">Register</h1>
            <div class="account-wall">
                <?php
                \Framework\FormViewHelper::init()
                    ->initForm($this->getPath() . 'user/register', ['class' => 'form-group'], 'post')
                    ->initLabel()->setValue("Username")->setAttribute('for', 'username')->create()
                    ->initTextBox()->setName('username')->setAttribute('id', 'username')->setAttribute('class', 'form-control input-md')->create()
                    ->initLabel()->setValue("Password")->setAttribute('for', 'password')->create()
                    ->initPasswordBox()->setName('password')->setAttribute('id', 'password')->setAttribute('class', 'form-control input-md')->create()
                    ->initLabel()->setValue("Confirm Password")->setAttribute('for', 'confPassword')->create()
                    ->initPasswordBox()->setName('confirm')->setAttribute('id', 'confPassword')->setAttribute('class', 'form-control input-md')->create()
                    ->initSubmit()->setAttribute('value', 'Register')->setAttribute('class', 'btn btn-default')->create()
                    ->render(true);
                ?>
            </div>
        </div>
    </div>
</div>