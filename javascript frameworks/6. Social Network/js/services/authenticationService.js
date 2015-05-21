'use strict';

SocialNetworkApp.factory('authentication', function ($http, baseServiceUrl) {
    var authentication = {};

    authentication.isLogged = function () {
        var isLogged = localStorage['accessToken'] !== undefined;

        return isLogged;
    };

    authentication.setCredentials = function (data) {
        authentication.clearCredentials();

        if (data['access_token']) {
            localStorage.setItem('accessToken', data['access_token']);
        }

        if (data['username']) {
            localStorage.setItem('username', data['username']);
        }

        if (data['name']) {
            localStorage.setItem('name', data['name']);
        }

        if (data['email']) {
            localStorage.setItem('email', data['email']);
        }

        if (data['profileImageData']) {
            localStorage.setItem('profileImageData', data['profileImageData']);
        }

        if (data['coverImageData']) {
            localStorage.setItem('coverImageData', data['coverImageData']);
        }

        if (data['gender']) {
            localStorage.setItem('gender', data['gender']);
        }
    };

    authentication.clearCredentials = function () {
        localStorage.clear();
    };

    authentication.getAccessToken = function () {
        return localStorage.getItem('accessToken');
    };

    authentication.getUsername = function () {
        return localStorage.getItem('username');
    };

    authentication.getName = function () {
        return localStorage.getItem('name');
    };

    return authentication;
});