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

        user.searchUser = function(searchTerm){
            var option1 = 'search?searchTerm=' + searchTerm;

            return resource.query({ option1: option1 });
        };

        user.getUserPreviewData = function(username){
            return resource.get({ option1: username, option2: 'preview' });
        };

        return user;
    }
});