var imdb = imdb || {};

(function (scope) {
    var id = 0;

    function Performance(title, length, rating, country) {
        this.title = title;
        this.length = length;
        this.rating = rating;
        this.country = country;
        this._actors = [];
        this._reviews = [];
        this._id = ++id;
    }

    Performance.prototype.addActor = function addActor(actor) {
        if(!actor instanceof scope._Actor) {
            throw {
                message: "Invalid actor!"
            };
        }

        this._actors.push(actor);
    }

    Performance.prototype.getActors = function getActors() {
        return this._actors;
    }

    Performance.prototype.addReview = function addReview(review) {
        if(!review instanceof scope._Review) {
            throw {
                message: "Invalid actor!"
            };
        }

        this._reviews.push(review);
    }

    Performance.prototype.deleteReview = function deleteReview(review) {
        var reviewIndex = this._reviews.indexOf(review);

        if (reviewIndex > -1) {
            delete this._reviews[reviewIndex];
        }
    }

    Performance.prototype.deleteReviewById = function deleteReviewById(reviewId) {
        var reviews;

        reviews = this._reviews;
        this._reviews.forEach(function (review, index) {
            if (review._id === reviewId) {
                delete reviews[index];
            }
        });
    }

    Performance.prototype.getReviews = function getReviews() {
        return this._reviews;
    }

    scope._Performance = Performance;
}(imdb));