var app = app || {};

app.homeController = (function() {
    function HomeController(views) {
        this.viewBag = views;
    }

    HomeController.prototype.loadGuestHomePage = function(selector) {
        this.viewBag.guestHomeView.loadGuestHomeView(selector);
    };

    HomeController.prototype.loadHomePage = function(selector) {
        var data = {
            username: sessionStorage['username'],
            name: sessionStorage['name'],
            picture: sessionStorage['picture']
        };

        this.viewBag.homeView.loadHomeView(selector, data);
    };

    return {
        load: function(views) {
            return new HomeController(views)
        }
    }
}());