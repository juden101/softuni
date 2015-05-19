'use strict';

var socialNetworkApp = angular
    .module('socialNetworkApp', ['ngRoute', 'ngResource'])
    .constant('baseUrl', 'http://softuni-social-network.azurewebsites.net/api/')
    .config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'templates/home-guest.html',
                controller: 'MainController'
            })
            .when('/login', {
                templateUrl: 'templates/login.html',
                controller: 'AuthenticationController'
            })
            .when('/register', {
                templateUrl: 'templates/register.html',
                controller: 'AuthenticationController'
            })
            .otherwise({
                redirectTo: '/'
            })
    });