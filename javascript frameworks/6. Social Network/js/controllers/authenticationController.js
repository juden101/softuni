'use strict';

SocialNetworkApp.controller('AuthenticationController', function ($scope, $location, $route, user, authentication, noty) {
    $scope.login = function () {
        user().login($scope.loginData).$promise.then(
            function(data) {
                console.log(data)
                authentication.setCredentials(data);
                $location.path('/user/home');

                noty.showInfo('Successful login!');
            },
            function(error) {
                noty.showError('Unsuccessful login!', error);
            }
        );
    };

    $scope.register = function () {
        user().register($scope.registerData).$promise.then(
            function(data) {
                authentication.setCredentials(data);
                $location.path('/user/home');

                noty.showInfo('Successful register!');
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

