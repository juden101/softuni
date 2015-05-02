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
        }
    }

    function loadLoginView(selector) {
        $.get('templates/login.html', function(template) {
            var outputHtml = Mustache.render(template);
            $(selector).html(outputHtml);
        }).then(function() {
            $('#loginButton').click(function() {
                var data = {
                    username: $('#login-username').val(),
                    password: $('#login-password').val()
                };

                $.sammy(function() {
                    this.trigger('login', data);
                });

                return false;
            });
        }).done();
    }

    function loadRegisterView(selector, noty) {
        $.get('templates/register.html', function(template) {
            var outputHtml = Mustache.render(template);
            $(selector).html(outputHtml);
        }).then(function() {
            $(selector).on('click', '#upload-file-button', function() {
                $('#picture').click();
            });

            // Reads the selected file and returns the data as a base64 encoded string
            $(selector).on('change', '#picture', function() {
                var file = this.files[0],
                    reader;

                if (file.type.match(/image\/.*/)) {
                    reader = new FileReader();
                    reader.onload = function(file) {
                        if (file.total <= 131072) {
                            $('#uploaded-picture').attr('src', file.currentTarget.result);
                        }
                        else {
                            noty.showError('#error-message', 'Image size is bigger than 128kb.');
                        }
                    };
                    reader.readAsDataURL(file);
                } else {
                    noty.showError('#error-message', 'Invalid image file.');
                }
            });

            $('#registerButton').click(function() {
                var data = {
                    username: $('#reg-username').val(),
                    password: $('#reg-password').val(),
                    name: $('#reg-name').val(),
                    about: $('#reg-about').val(),
                    gender: $('input[name=gender-radio]:checked').val(),
                    picture: $('#uploaded-picture').attr('src')
                };

                $.sammy(function() {
                    this.trigger('register', data);
                });

                return false;
            });
        }).done();
    }

    function loadEditProfileView(selector, data, noty) {
        $.get('templates/edit-profile.html', function(template) {
            var outputHtml = Mustache.render(template, data);
            $(selector).html(outputHtml);
        }).then(function() {
            $(selector).on('click', '#upload-file-button', function() {
                $('#picture').click();
            });

            // Reads the selected file and returns the data as a base64 encoded string
            $(selector).on('change', '#picture', function() {
                var file = this.files[0],
                    reader;

                if (file.type.match(/image\/.*/)) {
                    reader = new FileReader();
                    reader.onload = function(file) {
                        if (file.total <= 131072) {
                            $('#uploaded-picture').attr('src', file.currentTarget.result);
                        }
                        else {
                            noty.showError('#error-message', 'Image size is bigger than 128kb.');
                        }
                    };
                    reader.readAsDataURL(file);
                } else {
                    noty.showError('#error-message', 'Invalid image file.');
                }
            });

            $('#editProfileButton').click(function() {
                var data = {
                    username: $('#username').val(),
                    password: $('#password').val(),
                    name: $('#name').val(),
                    about: $('#about').val(),
                    gender: $('input[name=gender-radio]:checked').val(),
                    picture: $('#uploaded-picture').attr('src')
                };

                $.sammy(function() {
                    this.trigger('editProfile', data);
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