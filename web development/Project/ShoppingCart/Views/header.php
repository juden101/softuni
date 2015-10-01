<header>
    <h1 style="color: blue">Header</h1>
    <?php
    if (!\Framework\App::getInstance()->getSession()->_login) {
        echo '<h1>Login</h1>';

        \Framework\FormViewHelper::init()
            ->initForm('../home/login')
            ->initLabel()->setValue("Username")->setAttribute('for', 'username')->create()
            ->initTextBox()->setName('username')->setAttribute('id', 'username')->create()
            ->initLabel()->setValue("Password")->setAttribute('for', 'password')->create()
            ->initPasswordBox()->setName('password')->setAttribute('id', 'password')->create()
            ->initSubmit()->setAttribute('value', 'Login')->create()
            ->render();

            echo '<h1>Register</h1>';

            \Framework\FormViewHelper::init()
                ->initForm('../home/register')
                ->initLabel()->setValue("Username")->setAttribute('for', 'username')->create()
                ->initTextBox()->setName('username')->setAttribute('id', 'username')->create()
                ->initLabel()->setValue("Password")->setAttribute('for', 'password')->create()
                ->initPasswordBox()->setName('password')->setAttribute('id', 'password')->create()
                ->initSubmit()->setAttribute('value', 'Register')->create()
                ->render(true);
    } else {
        \Framework\FormViewHelper::init()
            ->initLink()->setAttribute('href', '../home/logout')->setValue('Logout')->create()
            ->render();
    }
    ?>
</header>