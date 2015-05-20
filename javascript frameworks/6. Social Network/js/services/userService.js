'use strict';

SocialNetworkApp.factory('user', function ($http, baseServiceUrl) {
    var user = {};
    var serviceUrl = baseServiceUrl + '/users';

    user.login = function (loginData, success, error) {
        $http.post(serviceUrl + '/Login', loginData)
            .success(function (data, status, headers, config) {
                success(data);
            }).error(error);
    };

    user.register = function (registerData, success, error) {
        $http.post(serviceUrl + '/Register', registerData)
            .success(function (data, status, headers, config) {
                success(data);
            }).error(error);
    };

    return user;
});