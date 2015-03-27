var imdb = imdb || {};

(function (scope) {
    function Movie(title, length, rating, country) {
        scope._Performance.apply(this, arguments);
    }

    Movie.extend(scope._Performance);

    scope.getMovie = function getMovie(title, length, rating, country) {
        return new Movie(title, length, rating, country);
    }

    scope._Movie = Movie;
}(imdb));