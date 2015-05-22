'use strict';

SocialNetworkApp.controller('UserController', function ($scope, user, authentication) {
    $scope.showUserPreview = function(username){
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

                    if(authentication.getUsername() !== data.username) {
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
});