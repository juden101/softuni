var app = app || {};

(function () {
    var apiId = 'jWGF8luCkWueZWSkdhTVhwbg6U4XchWYfiCvaDLM';
    var restAPIKey = 'oRZrLdYZo4mD5WV9le6Q6XWT3Ol0pfpMAvKga0KT';
    var baseUrl = 'https://api.parse.com/1/';

    var headers = app.headers.load(apiId, restAPIKey);
    var requester = app.requester.load();

    /*var dataModel = app.forumDataModel.load(apiURL, requester, headers, 'Question/');
    var authModel = app.forumAuthModel.load(apiURL, requester, headers);
    var rankingModel = app.forumAuthModel.load(apiURL, requester, headers);

    var questionController = app.questionController.load(dataModel);
    var authController = app.authController.load(authModel, cookies);
    var rankingController = app.rankingController.load(dataModel);
    var navigationController = app.navigationController.load(null);*/


    app.router = Sammy(function () {
        var selector = '#wrapper';

        this.get('#/', function () {
            $('#menu').hide();
        });

        /*this.before(function() {
            var userId = sessionStorage['userId'];

            if (userId) {
                $('#menu').show();
            } else {
                $('#menu').hide();
            }
        });

        this.get('#/', function () {
            app.loadNavigationMenu('home-page');

            questionController.loadQuestions(selector);
        });

        this.notFound = function() {
            window.location = '#/';
        }*/
    });

    app.loadNavigationMenu = function loadNavigationMenu(activePage) {
        navigationController.loadNavigationMenu('#forum-menu', activePage);
    };

    app.router.run('#/');
}());