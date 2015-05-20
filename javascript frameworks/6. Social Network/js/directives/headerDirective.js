'use strict';

SocialNetworkApp.directive('headerDirective', function () {
    return {
        templateUrl: 'templates/navbar.html',
        controller: 'UserController'
    }
});
