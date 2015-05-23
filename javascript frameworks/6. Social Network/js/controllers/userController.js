'use strict';

SocialNetworkApp.controller('UserController', function ($scope, $location, $routeParams, user, authentication, PAGE_SIZE, noty, DEFAULT_PROFILE_IMAGE, DEFAULT_COVER_IMAGE) {
    $scope.posts = [];
    $scope.defaultImage = DEFAULT_PROFILE_IMAGE;
    $scope.defaultCoverImage = DEFAULT_COVER_IMAGE;
    $scope.busy = false;
    var feedStartPostId;

    $scope.showUserPreview = function(username) {
        $scope.previewData = {};

        if (authentication.isLogged()) {
            var accessToken = authentication.getAccessToken();

            user(accessToken).getUserPreviewData(username).$promise.then(
                function(data){
                    $scope.previewData = {
                        image: data.profileImageData ? data.profileImageData : $scope.defaultImage,
                        name: data.name,
                        username: data.username,
                        status: false
                    };

                    if(authentication.getUsername() !== $scope.wallOwner.username) {
                        if(data.isFriend) {
                            $scope.previewData.status = 'friend';
                        } else if(data.hasPendingRequest){
                            $scope.previewData.status = 'pending';
                        } else {
                            $scope.previewData.status = 'invite';
                        }
                    }
                },
                function(error){
                    noty.showError('Unsuccessful user preview!', error);
                }
            );
        }
    };

    $scope.getWallOwner = function() {
        if (authentication.isLogged()) {
            var accessToken = authentication.getAccessToken();
            var loggedUsername = authentication.getUsername();
            var wallUsername = $routeParams['username'];

            user(accessToken).getUserFullData(wallUsername).$promise.then(
                function(data) {
                    $scope.wallOwner = data;

                    if(loggedUsername !== $scope.wallOwner.username) {
                        if(data.isFriend) {
                            $scope.wallOwner.status = 'friend';
                        } else if(data.hasPendingRequest) {
                            $scope.wallOwner.status = 'pending';
                        } else {
                            $scope.wallOwner.status = 'invite';
                        }
                    }

                    if((loggedUsername === $scope.wallOwner.username || $scope.wallOwner.isFriend) && $location.path() === '/user/' + wallUsername + '/wall/') {
                        $scope.getUserFriendsListPreview();
                    }

                    if(!$scope.wallOwner.isFriend && $routeParams['username'] !== $scope.username && $location.path() === '/user/' + $routeParams['username'] + '/friends/'){
                        $location.path('/');
                    }
                },
                function(error) {
                    noty.showError('Unsuccessful user load!', error);
                }
            );
        }
    };

    $scope.loadUserWall = function() {
        if(authentication.isLogged()) {
            if ($scope.busy) {
                return;
            }

            $scope.busy = true;
            var accessToken = authentication.getAccessToken();
            var wallUsername = $routeParams['username'];

            user(accessToken).getUserWall(wallUsername, PAGE_SIZE, feedStartPostId).$promise.then(
                function (data) {
                    $scope.posts = $scope.posts.concat(data);

                    if($scope.posts.length > 0){
                        feedStartPostId = $scope.posts[$scope.posts.length - 1].id;
                    }

                    $scope.busy = false;
                },
                function (error) {
                    noty.showError('Error loading user wall!', error);
                }
            );
        }
    };

    $scope.getUserFriends = function() {
        if(authentication.isLogged()) {
            var accessToken = authentication.getAccessToken();
            var wallUsername = $routeParams['username'];

            user(accessToken).getUserFriends(wallUsername).$promise.then(
                function (data) {
                    $scope.friendsList = data;
                },
                function (error) {
                    noty.showError('Error while getting user friends data.', error)
                }
            );
        }
    };

    $scope.getUserFriendsListPreview = function() {
        if(authentication.isLogged()) {
            var accessToken = authentication.getAccessToken();
            var wallUsername = $routeParams['username'];

            if (wallUsername != authentication.getUsername()) {
                user(accessToken).getUserFriendsPreview(wallUsername).$promise.then(
                    function (data) {
                        data.userFriendsUrl = '#/user/' + $routeParams['username'] + '/friends/';
                        $scope.friendsListPreview = data;
                    },
                    function (error) {
                        noty.showError('Unsuccessful user friends preview load!', error);
                    }
                );
            }
        }
    };
});