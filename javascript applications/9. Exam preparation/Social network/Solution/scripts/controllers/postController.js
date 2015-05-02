var app = app || {};

app.postController = (function() {
    function PostController(model, views, noty) {
        this.model = model;
        this.viewBag = views;
        this.noty = noty;
    }

    PostController.prototype.loadAllPostsPage = function(selector) {
        var _this = this;

        return this.model.listAllPosts()
            .then(function(data) {
                for (var postIndex in data.results) {
                    data.results[postIndex].authorUsername = data.results[postIndex].createdBy.username;
                    data.results[postIndex].authorName = data.results[postIndex].createdBy.name;
                    data.results[postIndex].authorPicture = data.results[postIndex].createdBy.picture;
                    data.results[postIndex].authorId = data.results[postIndex].createdBy.objectId;
                    data.results[postIndex].authorAbout = data.results[postIndex].createdBy.about;
                    data.results[postIndex].authorGender = data.results[postIndex].createdBy.gender;
                }

                _this.viewBag.allPostsView.loadAllPostsView(selector, data);
            }, function(error) {
                _this.noty.showError('#error-message', error.responseJSON.error);
            });
    };

    PostController.prototype.post = function(content) {
        var _this = this;

        return this.model.post(content)
            .then(function(postData) {
                console.log(postData);

                window.location = '#/';
                _this.noty.showSuccess('#success-message', 'Post added successfully.');
            }, function(error) {
                _this.noty.showError('#error-message', error.responseJSON.error);
            });
    };

    return {
        load: function(model, views, noty) {
            return new PostController(model, views, noty);
        }
    }
}());