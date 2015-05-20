'use strict';

SocialNetworkApp.controller('MainController', function ($scope) {
    $scope.isLogged = function(){
        return authentication.isLogged();
    };


});