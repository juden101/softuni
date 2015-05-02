var app = app || {};

(function () {
    var apiId = 'sJX9NjNveeWLnMNVmCWPxRKcB6wQqrNaS5TQroo7';
    var restAPIKey = 'LfAoJY5aJJ1I3Pt1RYtNYLRx0GfQDPBTmIYuwCcH';
    var baseUrl = 'https://api.parse.com/1/';

    var headers = app.headers.load(apiId, restAPIKey);
    var requester = app.requester.load();
    var noty = app.noty.load();

    // views
    var homeViews = app.homeViews.load();
    var userViews = app.userViews.load(noty);
    var postViews = app.postViews.load(noty);

    // models
    var userModel = app.userModel.load(baseUrl, requester, headers);
    var postModel = app.postModel.load(baseUrl, requester, headers);

    // controllers
    var homeController = app.homeController.load(homeViews);
    var userController = app.userController.load(userModel, userViews, noty);
    var postController = app.postController.load(postModel, postViews, noty);

    app.router = Sammy(function () {
        var selector = '#main';

        this.before(function() {
            var userId = sessionStorage['userId'];

            if (userId) {
                $('header').show();
            } else {
                $('header').hide();
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

        this.before('#/login/', function() {
            var userId = sessionStorage['userId'];
            if(userId) {
                this.redirect('#/home/');
                return false;
            }
        });

        this.before('#/register/', function() {
            var userId = sessionStorage['userId'];
            if(userId) {
                this.redirect('#/home/');
                return false;
            }
        });

        this.get('#/', function () {
            homeController.loadGuestHomePage(selector);
        });

        this.get('#/home/', function () {
            homeController.loadHomePage('#header');
            postController.loadAllPostsPage(selector);
        });

        this.get('#/login/', function () {
            userController.loadLoginPage(selector);
        });

        this.get('#/register/', function () {
            userController.loadRegisterPage(selector);
        });

        this.get('#/editProfile/', function () {
            homeController.loadHomePage('#header');
            userController.loadEditProfilePage(selector);
        });

        this.get('#/logout/', function () {
            userController.logout();
        });

        // triggers
        this.bind('login', function(event, data) {
            userController.login(data.username, data.password);
        });

        this.bind('register', function(event, data) {
            userController.register(data.username, data.password, data.name, data.about, data.gender, data.picture);
        });

        this.bind('post', function(event, data) {
            postController.post(data.content);
        });

        this.bind('editProfile', function(event, data) {
            userController.editProfile(data.username, data.password, data.name, data.about, data.gender, data.picture);
        });
    });

    app.router.run('#/');
}());