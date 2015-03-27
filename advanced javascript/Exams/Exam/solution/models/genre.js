var imdb = imdb || {};

(function (scope) {
    var genreId = 0;

    function Genre(name) {
        this.name = name;
        this._movies = [];
        this._id = ++genreId;
    }

    Genre.prototype.addMovie = function addMovie(movie) {
        if(!movie instanceof scope._Movie) {
            throw {
                message: "Invalid movie!"
            };
        }

        this._movies.push(movie);
    }

    Genre.prototype.deleteMovie = function deleteMovie(movie) {
        var movieIndex = this._movies.indexOf(movie);

        if (movieIndex > -1) {
            delete this._movies[movieIndex];
        }
    }

    Genre.prototype.deleteMovieById = function deleteMovieById(movieId) {
        var movies;

        movies = this._movies;
        this._movies.forEach(function (movie, index) {
            if (movie._id === movieId) {
                delete movies[index];
            }
        });
    }

    Genre.prototype.getMovies = function getMovies() {
        return this._movies;
    }

    scope.getGenre = function getGenre(name) {
        return new Genre(name);
    }
}(imdb));