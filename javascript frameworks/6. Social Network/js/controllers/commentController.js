'use strict';

SocialNetworkApp.controller('CommentController', function ($scope, authentication, comment, noty) {
    $scope.addComment = function(postData){
        if(authentication.isLogged()) {
            var accessToken = authentication.getAccessToken();
            var isWallOwnerFriend = postData.wallOwner.isFriend;

            if (isWallOwnerFriend) {
                comment(accessToken).addComment(postData.id, $scope.commentData).$promise.then(
                    function(data){
                        $scope.commentData.commentContent = '';
                        postData.comments.unshift(data);
                        postData.totalCommentsCount++;

                        noty.showInfo('Comment successfuly added.');
                    },
                    function(error){
                        noty.showError('Unsuccessful comment add!', error);
                    }
                );
            }
            else {
                noty.showError('You are not allowed to comment non-friend posts.');
            }
        }
    };

    $scope.getPostComments = function(postData){
        if(authentication.isLogged()) {
            var accessToken = authentication.getAccessToken();

            comment(accessToken).getPostComments(postData.id).$promise.then(
                function(data){
                    postData.comments = data;
                },
                function(error){
                    noty.showError('Unable to retrieve comments!', error);
                }
            );
        }
    };

    $scope.likeComment= function(postData, commentData){
        if(authentication.isLogged()) {
            var accessToken = authentication.getAccessToken();

            comment(accessToken).like(postData.id, commentData.id).$promise.then(
                function(){
                    commentData.liked = true;
                    commentData.likesCount++;

                    noty.showInfo('Comment successfully liked.');
                },
                function(error){
                    noty.showError('Unsuccessful like!', error);
                }
            );
        }
    };

    $scope.unlikeComment = function(postData, commentData){
        if(authentication.isLogged()) {
            var accessToken = authentication.getAccessToken();

            comment(accessToken).unlike(postData.id, commentData.id).$promise.then(
                function(){
                    commentData.liked = false;
                    commentData.likesCount--;

                    noty.showInfo('Comment successfully disliked.');
                },
                function(error){
                    noty.showError('Unsuccessful unlike!', error);
                }
            );
        }
    };
});