var app = app || {};

(function () {
    var apiId = 'jWGF8luCkWueZWSkdhTVhwbg6U4XchWYfiCvaDLM';
    var restAPIKey = 'oRZrLdYZo4mD5WV9le6Q6XWT3Ol0pfpMAvKga0KT';
    var baseUrl = 'https://api.parse.com/1/';

    var headers = app.headers.load(apiId, restAPIKey);
    var requester = app.requester.load();
    var noty = app.noty.load();
    var userModel = app.userModel.load(baseUrl, requester, headers);
    var phoneModel = app.phoneModel.load(baseUrl, requester, headers);

    var homeViews = app.homeViews.load();
    var userViews = app.userViews.load();
    var phoneViews = app.phoneViews.load();

    var homeController = app.homeController.load(homeViews);
    var userController = app.userController.load(userModel, userViews, noty);
    var phoneController = app.phoneController.load(phoneModel, phoneViews, noty);

    app.router = Sammy(function () {
        var selector = '#wrapper';

        this.before(function() {
            var userId = sessionStorage['userId'];

            if (userId) {
                $('#menu').show();
            } else {
                $('#menu').hide();
            }
        });

        this.before('#/', function() {
            var userId = sessionStorage['userId'];

            if (userId) {
                this.redirect('#/home/');
                return false;
            }
        });

        this.before('#/home/', function() {
            var userId = sessionStorage['userId'];

            if (!userId) {
                this.redirect('#/');
                return false;
            }
        });

        this.before('#/phones/(.*)', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                return false;
            }
        });

        this.before('#/editProfile/', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                return false;
            }
        });

        this.before('#/logout/', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                return false;
            }
        });

        this.notFound = function() {
            window.location = '#/';
        }

        this.get('#/', function () {
            homeController.loadWelcomePage(selector);
            setPageTitle('Welcome');
        });

        this.get('#/home/', function () {
            homeController.loadHomePage(selector);
            setPageTitle('Home');
        });

        this.get('#/login/', function () {
            userController.loadLoginPage(selector);
            setPageTitle('Login');
        });

        this.get('#/register/', function () {
            userController.loadRegisterPage(selector);
            setPageTitle('Registration');
        });

        this.get('#/logout/', function () {
            userController.logout();
        });

        this.get('#/editProfile/', function () {
            userController.loadEditProfilePage(selector);
            setPageTitle('Edit profile');
        });

        this.get('#/phones/', function () {
            phoneController.loadAllPhonesPage(selector);
            setPageTitle('Phones');
        });

        this.get('#/phones/add/', function () {
            phoneController.loadAddPhonePage(selector);
            setPageTitle('Add phone');
        });

        this.get('#/phones/edit/:id', function () {
            phoneController.loadPhonePage(selector, this.params['id'], 'edit');
            setPageTitle('Edit phone');
        });

        this.get('#/phones/delete/:id', function () {
            phoneController.loadPhonePage(selector, this.params['id'], 'delete');
            setPageTitle('Delete phone');
        });


        // triggers
        this.bind('login', function(event, data) {
            userController.login(data.username, data.password);
        });

        this.bind('register', function(event, data) {
            userController.register(data.username, data.password, data.fullName);
        });

        this.bind('editProfile', function(event, data) {
            userController.editProfile(data.username, data.password, data.fullName);
        });

        this.bind('addPhone', function(event, data) {
            phoneController.addPhone(data.name, data.phoneNumber);
        });

        this.bind('editPhone', function(event, data) {
            phoneController.editPhone(data.id, data.name, data.phoneNumber);
        });

        this.bind('deletePhone', function(event, data) {
            phoneController.deletePhone(data.id);
        });
    });

    var setPageTitle = function(title) {
        $('#page-title').text(title);
    }

    app.router.run('#/home/');
}());