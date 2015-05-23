'use strict';

SocialNetworkApp.directive('feedDirective', function () {
    return {
        templateUrl: 'templates/posts.html',
        controller: 'ProfileController'
    }
});