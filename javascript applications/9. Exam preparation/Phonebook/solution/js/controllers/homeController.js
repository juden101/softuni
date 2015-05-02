var app = app || {};

app.homeController = (function() {
    function HomeController(views) {
        this.viewBag = views;
    }

    HomeController.prototype.loadWelcomePage = function(selector) {
        this.viewBag.welcomeView.loadWelcomeView(selector);
    };

    HomeController.prototype.loadHomePage = function(selector) {
        var data = {
            username: sessionStorage['username'],
            fullName: sessionStorage['fullName']
        };

        this.viewBag.homeView.loadHomeView(selector, data);
    };

    return {
        load: function(views) {
            return new HomeController(views)
        }
    }
}());