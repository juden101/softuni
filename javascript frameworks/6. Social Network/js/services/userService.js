'use strict';

SocialNetworkApp.factory('user', function ($http, $resource, baseServiceUrl) {
    return function(token) {
        $http.defaults.headers.common['Authorization'] = 'Bearer ' + token;

        var user = {};
        var serviceUrl = baseServiceUrl + '/users/:option1';
        var resource = $resource(
            serviceUrl,
            {
                option1: '@option1'
            },
            {
                edit: {
                    method: 'PUT'
                }
            }
        );

        user.login = function (loginData) {
            return resource.save({option1: 'login'}, loginData);
        };

        user.register = function(registerData) {
            return resource.save({option1: 'register'}, registerData);
        };

        user.logout = function() {
            return resource.save({option1: 'logout'});
        };

        return user;
    }
});