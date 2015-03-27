var imdb = imdb || {};

(function (scope) {
	function loadHtml(selector, data) {
		var container = document.querySelector(selector),
			moviesContainer = document.getElementById('movies'),
			detailsContainer = document.getElementById('details'),
			genresUl = loadGenres(data),
            genreId;

		container.appendChild(genresUl);

		genresUl.addEventListener('click', function (ev) {
			if (ev.target.tagName === 'LI') {
				var genre,
					moviesHtml;

				genreId = parseInt(ev.target.getAttribute('data-id'));
				genre = data.filter(function (genre) {
					return genre._id === genreId;
				})[0];

				moviesHtml = loadMovies(genre.getMovies());
				moviesContainer.innerHTML = moviesHtml.outerHTML;
				moviesContainer.setAttribute('data-genre-id', genreId);
			}
		});

		// Task 2 - Add event listener for movies boxes
        moviesContainer.addEventListener('click', function (ev) {
            if (ev.target.tagName === 'LI') {
                var movieId,
                    movie,
                    movieInformationHtml;

                // get movie id
                movieId = parseInt(ev.target.getAttribute('data-id'));

                // get movie
                movie = getMovie(data, genreId - 1, movieId);

                // load movie
                movieInformationHtml = loadMovieInformation(movie);
                detailsContainer.innerHTML = movieInformationHtml.outerHTML;
            }
        });

		// Task 3 - Add event listener for delete button (delete movie button or delete review button)
        detailsContainer.addEventListener('click', function (ev) {
            if (ev.target.tagName === 'BUTTON') {
                var movie,
                    movieId,
                    reviewId;

                // get movie id, review id and movie
                movieId = parseInt(document.getElementById('movieId').getAttribute('data-id'));
                reviewId = parseInt(ev.target.parentNode.parentNode.getAttribute('data-id'));
                movie = getMovie(data, genreId - 1, movieId);

                // delete review from data and DOM
                movie.deleteReviewById(reviewId);

                // reload movie information
                var movieInformationHtml = loadMovieInformation(movie);
                detailsContainer.innerHTML = movieInformationHtml.outerHTML;
            }
        });
	}

	function loadGenres(genres) {
		var genresUl = document.createElement('ul');
		genresUl.setAttribute('class', 'nav navbar-nav');
		genres.forEach(function (genre) {
			var liGenre = document.createElement('li');
			liGenre.innerHTML = genre.name;
			liGenre.setAttribute('data-id', genre._id);
			genresUl.appendChild(liGenre);
		});

		return genresUl;
	}

	function loadMovies(movies) {
		var moviesUl = document.createElement('ul');
		movies.forEach(function (movie) {
			var liMovie = document.createElement('li');
			liMovie.setAttribute('data-id', movie._id);

			liMovie.innerHTML = '<h3>' + movie.title + '</h3>';
			liMovie.innerHTML += '<div>Country: ' + movie.country + '</div>';
			liMovie.innerHTML += '<div>Time: ' + movie.length + '</div>';
			liMovie.innerHTML += '<div>Rating: ' + movie.rating + '</div>';
			liMovie.innerHTML += '<div>Actors: ' + movie._actors.length + '</div>';
			liMovie.innerHTML += '<div>Reviews: ' + movie._reviews.length + '</div>';

			moviesUl.appendChild(liMovie);
		});

		return moviesUl;
	}

    function loadMovieInformation(movie) {
        var movieInformationDiv,
            actorsUl,
            reviewsUl;

        movieInformationDiv = document.createElement('div');
        movieInformationDiv.setAttribute('id', 'movieId');
        movieInformationDiv.setAttribute('data-id', movie._id);

        // load actors and reviews
        actorsUl = loadMovieActors(movie._actors);
        reviewsUl = loadMovieReviews(movie._reviews);

        // attach to DOM
        movieInformationDiv.innerHTML = '<h3>Actors</h3>';
        movieInformationDiv.appendChild(actorsUl);

        if(reviewsUl.innerHTML) {
            movieInformationDiv.innerHTML += '<h3>Reviews</h3>';
            movieInformationDiv.appendChild(reviewsUl);
        }

        return movieInformationDiv;
    }

    function loadMovieActors(actors) {
        var actorsUl = document.createElement('ul');
        actors.forEach(function (actor) {
            var liActor = document.createElement('li');

            liActor.innerHTML = '<h5>' + actor.name + '</h5>';
            liActor.innerHTML += '<div><b>Bio:</b> ' + actor.bio + '</div>';
            liActor.innerHTML += '<div><b>Born:</b> ' + actor.born + '</div>';

            actorsUl.appendChild(liActor);
        });

        return actorsUl;
    }

    function loadMovieReviews(reviews) {
        var reviewsUl = document.createElement('ul');
        reviews.forEach(function (review) {
            var liReview = document.createElement('li');
            liReview.setAttribute('data-id', review._id);

            liReview.innerHTML = '<h5>' + review.author + '</h5>';
            liReview.innerHTML += '<div><b>Content:</b> ' + review.content + '</div>';
            liReview.innerHTML += '<div><b>Date:</b> ' + review.date + '</div>';
            liReview.innerHTML += '<div><button type="button">Delete review</button></div>';

            reviewsUl.appendChild(liReview);
        });

        return reviewsUl;
    }

    function getMovie(data, genreId, movieId) {
        var movie = data[genreId]['_movies'].filter(function (movie) {
            return movie._id === movieId;
        })[0];

        return movie;
    }

	scope.loadHtml = loadHtml;
}(imdb));