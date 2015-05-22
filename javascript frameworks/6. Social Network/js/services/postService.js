'use strict';

SocialNetworkApp.factory('post', function($http, $resource, baseServiceUrl){
    return function(accessToken){
        $http.defaults.headers.common['Authorization'] = 'Bearer ' + accessToken;

        var post = {},
            resource = $resource(
                baseServiceUrl + '/Posts/:option1/:option2/:option3',
                {
                    option1: '@option1',
                    option2: '@option2',
                    option3: '@option3'
                }
            );

        post.addPost = function(postData){
            return resource.save(postData);
        };

        post.like = function(postId){
            return resource.save({option1: postId, option2: "likes"})
        };

        post.unlike = function(postId){
            return resource.remove({option1: postId, option2: "likes"})
        };

        return post;
    }
});