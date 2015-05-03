var app = app || {};

app.homeViews = (function() {
    function HomeViews() {
        this.welcomeView = {
            loadWelcomeView: loadWelcomeView
        };

        this.homeView = {
            loadHomeView: loadHomeView
        };
    }

    function loadWelcomeView(selector) {
        $.get('templates/welcome.html', function(template) {
            var outputHtml = Mustache.render(template);
            $(selector).html(outputHtml);
        });
    }

    function loadHomeView(selector, data) {
        $.get('templates/home.html', function(template) {
            var outputHtml = Mustache.render(template, data);
            $(selector).html(outputHtml);
        });
    }

    return {
        load: function() {
            return new HomeViews();
        }
    }
}());