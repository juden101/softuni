'use strict';

SocialNetworkApp.factory('authentication', function ($http, baseServiceUrl) {
    var authentication = {};

    authentication.isLogged = function () {
        var isLogged = localStorage['accessToken'] !== undefined;

        return isLogged;
    };

    authentication.setAccessToken = function(accessToken) {
        localStorage.setItem('accessToken', accessToken);
    };

    authentication.setUserData = function(userData) {
        localStorage.setItem('userData', JSON.stringify(userData));
    };

    authentication.getAccessToken = function () {
        return localStorage.getItem('accessToken');
    };

    authentication.getUserData = function () {
        return JSON.parse(localStorage.getItem('userData') || '{}');
    };

    authentication.clearCredentials = function () {
        localStorage.clear();
    };

    /*authentication.setCredentials = function (userData) {
        localStorage.setItem('accessToken', data['access_token']);

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
    };*/

    /*
    authentication.getUsername = function () {
        return localStorage.getItem('username');
    };

    authentication.getName = function () {
        return localStorage.getItem('name');
    };

    authentication.getEmail = function () {
        return localStorage.getItem('email');
    };

    authentication.getGender = function () {
        return localStorage.getItem('gender');
    };

    authentication.getProfileImage = function () {
        return localStorage.getItem('profileImageData');
    };

    authentication.getCoverImage = function () {
        return localStorage.getItem('coverImageData');
    };*/

    return authentication;
});