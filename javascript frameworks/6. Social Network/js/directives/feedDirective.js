'use strict';

SocialNetworkApp.directive('feedDirective', function () {
    return {
        templateUrl: 'templates/feed.html',
        controller: 'ProfileController'
    }
});