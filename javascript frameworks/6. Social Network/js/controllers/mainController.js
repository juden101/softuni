'use strict';

SocialNetworkApp.controller('MainController', function ($scope, authentication, user, noty, DEFAULT_PROFILE_IMAGE) {
    $scope.isLogged = function() {
        return authentication.isLogged();
    };

    $scope.userData = authentication.getUserData();
    $scope.defaultImage = DEFAULT_PROFILE_IMAGE;

    $scope.searchUser = function() {
        console.log(DEFAULT_PROFILE_IMAGE);
        var searchTerm = $scope.searchTerm.trim();

        if(authentication.isLogged() && searchTerm !== ''){
            var accessToken = authentication.getAccessToken();

            user(accessToken).searchUser(searchTerm).$promise.then(
                function(data) {
                    $scope.searchResults = data;
                },
                function(error) {
                    noty.showError('Error with search, please try again!', error);
                }
            );
        } else {
            $scope.searchResults = undefined;
        }
    };
});