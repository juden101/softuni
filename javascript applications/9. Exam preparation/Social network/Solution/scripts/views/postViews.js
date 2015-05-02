var app = app || {};

app.postViews = (function() {
    function PostViews() {
        this.allPostsView = {
            loadAllPostsView: loadAllPostsView
        };
    }

    function loadAllPostsView(selector, data) {
        $.get('templates/posts.html', function(template) {
            var outputHtml = Mustache.render(template, data);
            $(selector).html(outputHtml);
        }).then(function() {
            $('#postButton').click(function() {
                $('#post-box').toggle(500);

                return false;
            });

            $('#postContent').click(function() {
                var data = {
                    content: $('#post-content').val()
                };

                $.sammy(function() {
                    this.trigger('post', data);
                });

                return false;
            });

            $('.profile-link').tooltipsy({
                content: function (element, tip) {
                    var data = {
                        name: element.attr('data-name'),
                        gender: element.attr('data-gender'),
                        about: element.attr('data-about'),
                        picture: element.attr('data-picture')
                    }

                    $.get('templates/hover-box.html', function(template) {
                        var outputHtml = Mustache.render(template, data);
                        tip.html(outputHtml)
                    })
                }
            });
        }).done();
    }

    return {
        load: function() {
            return new PostViews();
        }
    }
}());