var app = app || {};

app.postModel = (function() {
    function PostModel(baseUrl, requester, headers) {
        this.serviceUrl = baseUrl + 'classes/Post/';
        this.requester = requester;
        this.headers = headers;
    }

    PostModel.prototype.listAllPosts = function() {
        return this.requester.get(this.serviceUrl + '?include=createdBy&order=-createdAt', this.headers.getHeaders());
    };

    PostModel.prototype.post = function(content) {
        var data = {
            content: content,
            createdBy : {
                '__type': 'Pointer',
                'className': '_User',
                'objectId': sessionStorage.userId
            }
        };

        return this.requester.post(this.serviceUrl, this.headers.getHeaders(true), data);
    };

    return {
        load: function(baseUrl, requester, headers) {
            return new PostModel(baseUrl, requester, headers);
        }
    }
}());