'use strict';

SocialNetworkApp.controller('PostController', function ($scope, $routeParams, user, authentication, post, noty) {
    $scope.addPost = function() {
        $scope.postData.username = $routeParams['username'];

        if(authentication.isLogged()) {
            var accessToken = authentication.getAccessToken();

            post(accessToken).addPost($scope.postData).$promise.then(
                function(data){
                    $scope.postData.postContent = '';
                    $scope.posts.unshift(data);

                    noty.showInfo('Post successfuly added.');
                },
                function(error){
                    noty.showError('Unsuccessful post add!', error);
                }
            );
        }
    };

    $scope.likePost = function(postData) {
        if(authentication.isLogged()) {
            var accessToken = authentication.getAccessToken();
            var isWallOwnerFriend = postData.wallOwner.isFriend;
            var isWallOwnerMe = postData.wallOwner.username == authentication.getUsername();

            if (isWallOwnerFriend || isWallOwnerMe) {
                post(accessToken).like(postData.id).$promise.then(
                    function() {
                        postData.liked = true;
                        postData.likesCount++;

                        noty.showInfo('Post successfully liked.');
                    },
                    function(error){
                        noty.showError('Unsuccessful like!', error);
                    }
                );
            }
            else {
                noty.showError('You don\'t have permission to like this post.')
            }
        }
    };

    $scope.unlikePost = function(postData){
        if(authentication.isLogged()) {
            var accessToken = authentication.getAccessToken();
            var isWallOwnerFriend = postData.wallOwner.isFriend;
            var isWallOwnerMe = postData.wallOwner.username == authentication.getUsername();

            if (isWallOwnerFriend || isWallOwnerMe) {
                post(accessToken).unlike(postData.id).$promise.then(
                    function () {
                        postData.liked = false;
                        postData.likesCount--;

                        noty.showInfo('Post successfully disliked.');
                    },
                    function (error) {
                        noty.showError('Unsuccessful dislike!', error);
                    }
                );
            }
        }
    };
});