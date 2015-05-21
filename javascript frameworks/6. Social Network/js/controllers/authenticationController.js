'use strict';

SocialNetworkApp.controller('AuthenticationController', function ($scope, $location, $route, user, authentication, profile, noty) {
    $scope.login = function () {
        user().login($scope.loginData).$promise.then(
            function(data) {
                var accessToken = data['access_token'];

                profile(accessToken).userProfile().$promise.then(
                    function (userData) {
                        authentication.setAccessToken(accessToken);
                        authentication.setUserData(userData);

                        $location.path('/user/home');
                        noty.showInfo('Successful login!');
                    },
                    function (error) {
                        noty.showError('Unable to get user profile data, plese try again!', error);
                    }
                );
            },
            function(error) {
                noty.showError('Unsuccessful login!', error);
            }
        );
    };

    $scope.register = function () {
        user().register($scope.registerData).$promise.then(
            function(data) {
                var accessToken = data['access_token'];

                profile(accessToken).userProfile().$promise.then(
                    function (userData) {
                        authentication.setAccessToken(accessToken);
                        authentication.setUserData(userData);

                        $location.path('/user/home');
                        noty.showInfo('Successful register!');
                    },
                    function (error) {
                        noty.showError('Unable to get user profile data, plese try again!', error);
                    }
                );
            },
            function(error) {
                noty.showError('Unsuccessful register!', error);
            }
        );
    };

    $scope.logout = function () {
        var accessToken = authentication.getAccessToken();

        user(accessToken).logout().$promise.then(
            function() {
                authentication.clearCredentials();
                $location.path('/');

                noty.showInfo('Successful logout!');
            },
            function(error){
                noty.showError('Unsuccessful logout!', error);
            }
        );
    };
});

