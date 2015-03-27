var imdb = imdb || {};

(function (scope) {
    function Theatre(name, length, rating, coutry, isPuppet) {
        scope._Performance.apply(this, arguments);
        this.isPuppet = isPuppet;
    }

    Theatre.extend(scope._Performance);

    scope.getTheatre = function getTheatre(name, length, rating, coutry, isPuppet) {
        return new Theatre(name, length, rating, coutry, isPuppet);
    }
}(imdb));