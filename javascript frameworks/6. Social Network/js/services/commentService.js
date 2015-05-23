'use strict';

SocialNetworkApp.factory('comment', function($http, $resource, baseServiceUrl){
    return function(token){
        $http.defaults.headers.common['Authorization'] = 'Bearer ' + token;

        var comment = {},
            resource = $resource(
                baseServiceUrl + '/Posts/:option1/comments/:option2/:option3',
                {
                    option1: '@option1',
                    option2: '@option2',
                    option3: '@option3'
                }
            );

        comment.addComment = function(postId, commentData){
            return resource.save({option1: postId}, commentData);
        };

        comment.getPostComments = function(postId){
            return resource.query({option1: postId});
        };

        comment.like = function(postId, commentId){
            return resource.save({option1: postId, option2: commentId, option3: "likes"})
        };

        comment.unlike = function(postId, commentId){
            return resource.remove({option1: postId, option2: commentId, option3: "likes"})
        };

        return comment;
    }
});