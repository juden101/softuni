'use strict';

SocialNetworkApp.controller('CommentController', function ($scope, authentication, comment, noty) {
    $scope.addComment = function(postData){
        if(authentication.isLogged()) {
            var accessToken = authentication.getAccessToken();
            var isWallOwnerFriend = postData.wallOwner.isFriend;
            var isWallOwnerMe = postData.wallOwner.username == authentication.getUsername();

            if (isWallOwnerFriend || isWallOwnerMe) {
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

    $scope.editComment = function(postData, commentData) {
        if(authentication.isLogged()) {
            var accessToken = authentication.getAccessToken();

            comment(accessToken).editComment(postData.id, commentData.id, commentData.newCommentContent).$promise.then(
                function(){
                    noty.showInfo('Comment successfully edited.');
                    commentData.commentContent = commentData.newCommentContent;
                },
                function(error) {
                    noty.showError('Unsuccessful comment edit!', error);
                }
            );
        }
    };

    $scope.deleteComment = function(postData, commentData){
        if(authentication.isLogged()) {
            var accessToken = authentication.getAccessToken();

            comment(accessToken).removeComment(postData.id, commentData.id).$promise.then(
                function(){
                    var index =  postData.comments.indexOf(commentData);
                    postData.comments.splice(index, 1);
                    postData.totalCommentsCount--;

                    noty.showInfo('Comment successfully removed.');
                },
                function(error) {
                    noty.showError('Unsuccessful comment edit!', error);
                }
            );
        }
    };
});