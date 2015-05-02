var app = app || {};

app.userController = (function() {
    function UserController(model, views, noty) {
        this.model = model;
        this.viewBag = views;
        this.noty = noty;
    }

    UserController.prototype.loadLoginPage = function(selector) {
        this.viewBag.loginView.loadLoginView(selector);
    };

    UserController.prototype.loadRegisterPage = function(selector) {
        this.viewBag.registerView.loadRegisterView(selector);
    };

    UserController.prototype.loadEditProfilePage = function(selector) {
        var data = {
            username: sessionStorage['username'],
            fullName: sessionStorage['fullName']
        };

        this.viewBag.editProfileView.loadEditProfileView(selector, data);
    };

    UserController.prototype.login = function(username, password) {
        var _this = this;

        return this.model.login(username, password)
            .then(function(loginData) {
                setUserToStorage(loginData);
                window.location = '#/home/';
                _this.noty.showSuccess('#success-message', 'Login successful.');
            }, function(error) {
                _this.noty.showError('#error-message', error.responseJSON.error);
            });
    };

    UserController.prototype.register = function(username, password, fullName) {
        var _this = this;

        return this.model.register(username, password, fullName)
            .then(function(registerData) {
                var registerData = {
                    objectId: registerData.objectId,
                    username: username,
                    fullName: fullName,
                    sessionToken: registerData.sessionToken
                };

                setUserToStorage(registerData);
                window.location = '#/home/';
                _this.noty.showSuccess('#success-message', 'Register successful.');
            }, function(error) {
                _this.noty.showError('#error-message', error.responseJSON.error);
            });
    };

    UserController.prototype.logout = function() {
        var _this = this;

        return this.model.logout()
            .then(function() {
                clearUserFromStorage();
                window.location = '#/';
                _this.noty.showSuccess('#success-message', 'You successfully logged out.');
            }, function(error) {
                _this.noty.showError('#error-message', error.responseJSON.error);
            });
    };

    UserController.prototype.editProfile = function(username, password, fullName) {
        var userId = sessionStorage['userId'];

        return this.model.editProfile(userId, username, password, fullName)
            .then(function() {
                if (username !== '') {
                    sessionStorage['username'] = username;
                }

                if (fullName !== '') {
                    sessionStorage['fullName'] = fullName;
                }

                window.location = '#/home/';
            });
    };

    function setUserToStorage(data) {
        sessionStorage['userId'] = data.objectId;
        sessionStorage['username'] = data.username;
        sessionStorage['fullName'] = data.fullName;
        sessionStorage['sessionToken'] = data.sessionToken;
    }

    function clearUserFromStorage() {
        delete sessionStorage['userId'];
        delete sessionStorage['username'];
        delete sessionStorage['fullName'];
        delete sessionStorage['sessionToken'];
    }

    return {
        load: function(model, views, noty) {
            return new UserController(model, views, noty);
        }
    }
}());