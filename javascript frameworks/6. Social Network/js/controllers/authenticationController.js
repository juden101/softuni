'use strict';

SocialNetworkApp.controller('AuthenticationController', function ($scope, $location, $route, user, authentication, noty) {
    $scope.login = function () {
        user.login(
            $scope.loginData,
            function(serverData) {
                authentication.setCredentials(serverData);
                $location.path('/user/home');

                noty.showInfo('Successful login!');
            },
            function (serverError) {
                noty.showError('Unsuccessful login!', serverError);
            });
    };

    $scope.register = function () {
        user.register(
            $scope.registerData,
            function(serverData) {
                authentication.setCredentials(serverData);
                $location.path('/user/home');

                noty.showInfo('Successful register!');
            },
            function (serverError) {
                noty.showError('Unsuccessful register!', serverError);
            });
    };

    $scope.logout = function () {
        authentication.clearCredentials();
        $location.path('/user/home');

        noty.showInfo('Successful logout!');
    };
});

