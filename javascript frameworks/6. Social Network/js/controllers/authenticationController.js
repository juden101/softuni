'use strict';

socialNetworkApp.controller('AuthenticationController', function ($scope, $location, $route) {
    $scope.login = function () {
        console.log($scope.loginData);
    };

    $scope.register = function () {
        console.log($scope.registerData);
    };
});

