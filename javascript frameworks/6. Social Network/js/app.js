'use strict';

var SocialNetworkApp = angular
    .module('SocialNetworkApp', ['ngRoute', 'ngResource'])
    .constant('baseServiceUrl', 'http://softuni-social-network.azurewebsites.net/api')
    .config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'templates/home-guest.html',
                controller: 'MainController',
                resolve: {
                    isLogged: function($location) {
                        if(localStorage.getItem('accessToken')){
                            $location.path('/home');
                        }
                    }
                }
            })
            .when('/home', {
                templateUrl: 'templates/home.html',
                controller: 'MainController',
                resolve: {
                    isNotLogged: function($location) {
                        if(!localStorage.getItem('accessToken')){
                            $location.path('/');
                        }
                    }
                }
            })
            .when('/login', {
                templateUrl: 'templates/login.html',
                controller: 'AuthenticationController',
                resolve: {
                    isLogged: function($location) {
                        if(localStorage.getItem('accessToken')){
                            $location.path('/home');
                        }
                    }
                }
            })
            .when('/register', {
                templateUrl: 'templates/register.html',
                controller: 'AuthenticationController',
                resolve: {
                    isLogged: function($location) {
                        if(localStorage.getItem('accessToken')){
                            $location.path('/home');
                        }
                    }
                }
            })
            .when('/logout', {
                templateUrl: 'templates/logout.html',
                controller: 'AuthenticationController',
                resolve: {
                    isLogged: function($location) {
                        if(!localStorage.getItem('accessToken')){
                            $location.path('/');
                        }
                    }
                }
            })
            .otherwise({
                redirectTo: '/'
            });
    });