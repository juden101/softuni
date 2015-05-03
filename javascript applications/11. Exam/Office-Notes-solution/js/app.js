var app = app || {};

(function () {
    var apiId = 'XkEWnfL6vCZ2Py338iEYhLnEV8Lx5yLMGGMFGhMz';
    var restAPIKey = 'ooLkJPZgdLOSesEs6Z7wfBoGREnaBr8GNDwG7mvM';
    var baseUrl = 'https://api.parse.com/1/';

    var headers = app.headers.load(apiId, restAPIKey);
    var requester = app.requester.load();
    var noty = app.noty.load();

    // models
    var userModel = app.userModel.load(baseUrl, requester, headers);
    var noteModel = app.noteModel.load(baseUrl, requester, headers);

    //views
    var homeViews = app.homeViews.load();
    var userViews = app.userViews.load();
    var noteViews = app.noteViews.load();

    // controllers
    var homeController = app.homeController.load(homeViews);
    var userController = app.userController.load(userModel, userViews, noty);
    var noteController = app.noteController.load(noteModel, noteViews, noty);

    app.router = Sammy(function () {
        var selector = '#container';

        //authentication page redirects
        this.before(function() {
            var userId = sessionStorage['userId'];

            if (userId) {
                $('#menu').show();
                $('#welcomeMenu').html('Welcome, ' + sessionStorage['fullName']);
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

        this.before('#/login/', function() {
            var userId = sessionStorage['userId'];

            if (userId) {
                this.redirect('#/home/');
                noty.showError('You should be logged out in order to view login page!');

                return false;
            }
        });

        this.before('#/register/', function() {
            var userId = sessionStorage['userId'];

            if (userId) {
                this.redirect('#/home/');
                noty.showError('You should be logged out in order to view register page!');

                return false;
            }
        });

        this.before('#/home/', function() {
            var userId = sessionStorage['userId'];

            if (!userId) {
                this.redirect('#/');
                noty.showError('You should be logged in order to view your home page!');

                return false;
            }
        });

        this.before('#/myNotes/', function() {
            var userId = sessionStorage['userId'];

            if (!userId) {
                this.redirect('#/');
                noty.showError( 'You should be logged in order to view your notes!');

                return false;
            }
        });

        this.before('#/office/', function() {
            var userId = sessionStorage['userId'];

            if (!userId) {
                this.redirect('#/');
                noty.showError('You should be logged in order to view office notes!');

                return false;
            }
        });

        this.before('#/addNote/', function() {
            var userId = sessionStorage['userId'];

            if (!userId) {
                this.redirect('#/');
                noty.showError('You should be logged in order to add note!');

                return false;
            }
        });

        this.before('#/editNote/', function() {
            var userId = sessionStorage['userId'];

            if (!userId) {
                this.redirect('#/');
                noty.showError('You should be logged in order to edit note!');

                return false;
            }
        });

        this.before('#/deleteNote/', function() {
            var userId = sessionStorage['userId'];

            if (!userId) {
                this.redirect('#/');
                noty.showError('You should be logged in order to delete note!');

                return false;
            }
        });

        this.notFound = function() {
            window.location = '#/';
            noty.showError('404 page not found!');
        };

        // pages
        this.get('#/', function () {
            homeController.loadWelcomePage(selector);
        });

        this.get('#/home/', function () {
            homeController.loadHomePage(selector);
        });

        this.get('#/login/', function () {
            userController.loadLoginPage(selector);
        });

        this.get('#/register/', function () {
            userController.loadRegisterPage(selector);
        });

        this.get('#/logout/', function () {
            userController.logout();
        });

        this.get('#/addNote/', function () {
            noteController.loadAddNotePage(selector);
        });

        this.get('#/editNote/:data', function () {
            noteController.loadNotePage(selector, this.params['data'], 'edit');
        });

        this.get('#/deleteNote/:data', function () {
            noteController.loadNotePage(selector, this.params['data'], 'delete');
        });

        this.get('#/myNotes/', function () {
            this.redirect('#/myNotes/1');
        });

        this.get('#/myNotes/:page', function () {
            var page = parseInt(this.params['page']);
            noteController.loadMyNotesPage(selector, page);
        });

        this.get('#/office/', function () {
            this.redirect('#/office/1');
        });

        this.get('#/office/:page', function () {
            var page = parseInt(this.params['page']);
            noteController.loadOfficeNotesPage(selector, page);
        });

        // triggers
        this.bind('login', function(event, data) {
            userController.login(data.username, data.password);
        });

        this.bind('register', function(event, data) {
            userController.register(data.username, data.password, data.fullName);
        });

        this.bind('addNote', function(event, data) {
            noteController.addNote(data.title, data.text, data.deadline);
        });

        this.bind('editNote', function(event, data) {
            noteController.editNote(data.objectId, data.title, data.text, data.deadline);
        });

        this.bind('deleteNote', function(event, data) {
            noteController.deleteNote(data.objectId);
        });
    });

    app.router.run('#/');
}());