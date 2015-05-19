'use strict';

var socialNetworkApp = angular
    .module('socialNetworkApp', ['ngRoute', 'ngResource'])
    .constant('baseUrl', 'http://softuni-social-network.azurewebsites.net/api/')
    .config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'templates/home-guest.html',
                controller: 'mainController'
            })
            .when('/login', {
                templateUrl: 'templates/login.html'
            })
            .when('/register', {
                templateUrl: 'templates/register.html'
            })
            .otherwise({
                redirectTo: '/'
            })
    });