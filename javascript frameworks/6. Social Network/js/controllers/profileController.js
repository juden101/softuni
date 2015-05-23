'use strict';

SocialNetworkApp.controller('ProfileController', function ($scope, $location, authentication, profile, noty, PAGE_SIZE) {
    $scope.userData = authentication.getUserData();
    $scope.posts = [];
    $scope.busy = false;
    var feedStartPostId;

    $scope.getUserProfile = function() {
        if(authentication.isLogged()) {
            var accessToken = authentication.getAccessToken();

            profile(accessToken).userProfile().$promise.then(
                function (data) {
                    $scope.userProfile = data;
                },
                function (error) {
                    noty.showError('Unable to get user profile data, plese try again!', error)
                }
            );
        }
    };

    $scope.editProfile = function () {
        var accessToken = authentication.getAccessToken();
        var userProfileData = $scope.userProfile;

        profile(accessToken).update(userProfileData).$promise.then(
            function () {
                authentication.setUserData(userProfileData);
                noty.showInfo('Profile successfully edited.');
            },
            function (error) {
                noty.showError('Error with profile editing!', error);
            }
        );
    };

    $scope.editPassword = function () {
        var accessToken = authentication.getAccessToken();
        var userEditPasswordData = $scope.editProfilePassword;

        profile(accessToken).update(userEditPasswordData, 'ChangePassword').$promise.then(
            function () {
                noty.showInfo('Password successfully changed.');
                $location.path('/home');
            },
            function (error) {
                noty.showError('Unsuccessful password change!', error);
            }
        );
    };

    $scope.uploadProfileImage = function (files) {
        var file = files[0];
        var reader;

        if(!file.type.match(/image\/.*/)) {
            $('#profile-image').attr('src', '');

            $scope.userProfile.profileImageData = undefined;
            noty.showError("Invalid file format.");
        } else if(file.size > 131072) {
            $('#profile-image').attr('src', '');

            $scope.userProfile.profileImageData = undefined;
            noty.showError("File size limit exceeded.");
        } else {
            reader = new FileReader();
            reader.onload = function() {
                $('#profile-image').attr('src', reader.result);
                $scope.userProfile.profileImageData = reader.result;
            };
            reader.readAsDataURL(file);
        }
    };

    $scope.loadNewsFeed = function(){
        if (authentication.isLogged()) {
            if ($scope.busy){
                return;
            }
            $scope.busy = true;

            var accessToken = authentication.getAccessToken();

            profile(accessToken).getNewsFeed(PAGE_SIZE, feedStartPostId).$promise.then(
                function (data) {
                    $scope.posts = $scope.posts.concat(data);

                    if($scope.posts.length > 0) {
                        feedStartPostId = $scope.posts[$scope.posts.length - 1].id;
                    }

                    $scope.busy = false;
                    $scope.isNewsFeed = true;
                },
                function (error) {
                    noty.showError('Error while fetching feed data.', error);
                }
            );
        }
    };

    $scope.getOwnFiendsList = function() {
        if(authentication.isLogged()) {
            var accessToken = authentication.getAccessToken();

            profile(accessToken).getFriendsList().$promise.then(
                function (data) {
                    $scope.friendsList = data;
                },
                function (error) {
                    noty.error('Error with friend list data!', error);
                }
            );
        }
    };

    $scope.getOwnFriendsListPreview = function(){
        if(authentication.isLogged()) {
            var accessToken = authentication.getAccessToken();

            profile(accessToken).getFriendsListPreview().$promise.then(
                function (data) {
                    data.userFriendsUrl = '#/friends/';
                    $scope.friendsListPreview = data;
                },
                function (error) {
                    noty.error('Error with friend list preview!', error);
                }
            );
        }
    };

    $scope.uploadCoverImage = function (files) {
        var file = files[0];
        var reader;

        if(!file.type.match(/image\/.*/)) {
            $('#cover-image').attr('src', '');

            $scope.userProfile.coverImageData = undefined;
            noty.showError("Invalid file format.");
        } else if(file.size > 1048576) {
            $('#cover-image').attr('src', '');

            $scope.userProfile.coverImageData = undefined;
            noty.showError("File size limit exceeded.");
        } else {
            reader = new FileReader();
            reader.onload = function() {
                $('#cover-image').attr('src', reader.result);
                $scope.userProfile.coverImageData = reader.result;
            };
            reader.readAsDataURL(file);
        }
    };

    $scope.sendFriendRequest = function(previewData){
        if(authentication.isLogged()) {
            var accessToken = authentication.getAccessToken();

            profile(accessToken).sendFriendRequest(previewData.username).$promise.then(
                function () {
                    previewData.status = 'pending';

                    noty.showInfo('Friend request successfully sent to ' + previewData.username + '.');
                },
                function (error) {
                    noty.showError('Unsuccessful invitation sent!', error);
                }
            );
        }
    };
});