var app = app || {};

app.userViews = (function() {
    function UserViews() {
        this.loginView = {
            loadLoginView: loadLoginView
        };

        this.registerView = {
            loadRegisterView: loadRegisterView
        };

        this.editProfileView = {
            loadEditProfileView: loadEditProfileView
        };
    }

    function loadLoginView (selector) {
        $.get('templates/login.html', function(template) {
            var outputHtml = Mustache.render(template);
            $(selector).html(outputHtml);
        }).then(function() {
            $('#loginButton').click(function() {
                var data = {
                    username: $('#username').val(),
                    password: $('#password').val()
                };

                $.sammy(function() {
                    this.trigger('login', data)
                });

                return false;
            });
        }).done();
    }

    function loadRegisterView (selector) {
        $.get('templates/register.html', function(template) {
            var outputHtml = Mustache.render(template);
            $(selector).html(outputHtml);
        }).then(function() {
            $('#registerButton').click(function() {
                var data = {
                    username: $('#username').val(),
                    password: $('#password').val(),
                    fullName: $('#fullName').val()
                };

                $.sammy(function() {
                    this.trigger('register', data)
                });

                return false;
            });
        }).done();
    }

    function loadEditProfileView (selector, data) {
        $.get('templates/edit-user.html', function(template) {
            var outputHtml = Mustache.render(template, data);
            $(selector).html(outputHtml);
        }).then(function() {
            $('#editProfileButton').click(function() {
                var data = {
                    username: $('#username').val(),
                    password: $('#password').val(),
                    fullName: $('#fullName').val()
                };

                $.sammy(function() {
                    this.trigger('editProfile', data)
                });

                return false;
            });
        }).done();
    }

    return {
        load: function() {
            return new UserViews();
        }
    }
}());