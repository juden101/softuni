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
        this.viewBag.registerView.loadRegisterView(selector, this.noty);
    };

    UserController.prototype.loadEditProfilePage = function(selector) {
        var data = {
            username: sessionStorage.username,
            name: sessionStorage.name,
            about: sessionStorage.about,
            gender: sessionStorage.gender
        };

        this.viewBag.editProfileView.loadEditProfileView(selector, data, this.noty);
    };

    UserController.prototype.login = function(username, password) {
        var _this = this;

        return this.model.login(username, password)
            .then(function(loginData) {
                var data = {
                    objectId: loginData.objectId,
                    username: username,
                    name: loginData.name,
                    about: loginData.about,
                    gender: loginData.gender,
                    picture: loginData.picture,
                    sessionToken: loginData.sessionToken
                };

                setUserToStorage(data);
                window.location = '#/home/';
                _this.noty.showSuccess('#success-message', 'Login successful.');
            }, function(error) {
                _this.noty.showError('#error-message', error.responseJSON.error);
            });
    };

    UserController.prototype.register = function(username, password, name, about, gender, picture) {
        var _this = this;

        return this.model.register(username, password, name, about, gender, picture)
            .then(function(registerData) {
                var data = {
                    objectId: registerData.objectId,
                    username: username,
                    name: name,
                    about: about,
                    gender: gender,
                    picture: picture,
                    sessionToken: registerData.sessionToken
                };

                setUserToStorage(data);
                window.location = '#/home/';
                _this.noty.showSuccess('#success-message', 'Register successful.');
            }, function(error) {
                _this.noty.showError('#error-message', error.responseJSON.error);
            });
    };

    UserController.prototype.editProfile = function(username, password, name, about, gender, picture) {
        var _this = this;

        return this.model.editProfile(sessionStorage.userId, username, password, name, about, gender, picture)
            .then(function(editProfileData) {
                var data = {
                    objectId: sessionStorage.userId,
                    username: username,
                    name: name || sessionStorage.name,
                    about: about || sessionStorage.about,
                    gender: gender || sessionStorage.gender,
                    picture: picture || sessionStorage.picture,
                    sessionToken: sessionStorage.sessionToken
                };

                setUserToStorage(data);
                window.location = '#/';
                _this.noty.showSuccess('#success-message', 'Profile updated successfully.');
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

    function setUserToStorage(data) {
        sessionStorage['userId'] = data.objectId;
        sessionStorage['username'] = data.username;
        sessionStorage['name'] = data.name;
        sessionStorage['about'] = data.about;
        sessionStorage['gender'] = data.gender;
        sessionStorage['picture'] = data.picture;
        sessionStorage['sessionToken'] = data.sessionToken;
    }

    function clearUserFromStorage() {
        delete sessionStorage['userId'];
        delete sessionStorage['username'];
        delete sessionStorage['name'];
        delete sessionStorage['about'];
        delete sessionStorage['gender'];
        delete sessionStorage['picture'];
        delete sessionStorage['sessionToken'];
    }

    return {
        load: function(model, views, noty) {
            return new UserController(model, views, noty);
        }
    }
}());