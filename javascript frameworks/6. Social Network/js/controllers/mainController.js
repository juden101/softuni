'use strict';

SocialNetworkApp.controller('MainController', function ($scope, $location, $interval, $routeParams, authentication, user, profile, noty, DEFAULT_PROFILE_IMAGE) {
    $scope.isLogged = function() {
        return authentication.isLogged();
    };

    $scope.username = authentication.getUsername();
    $scope.userData = authentication.getUserData();
    $scope.defaultImage = DEFAULT_PROFILE_IMAGE;
    $scope.showPendingRequests = false;
    $scope.isOwnWall = authentication.getUsername() === $routeParams['username'];
    $scope.isOwnFeed = $location.path() === '/home';

    $scope.getFriendRequests = function () {
        if (authentication.isLogged()) {
            var accessToken = authentication.getAccessToken();

            profile(accessToken).getPendingRequests().$promise.then(
                function (data) {
                    $scope.pendingRequests = data;
                },
                function (error) {
                    noty.showError('Unable to get pengind friend requests, please try again!', error);
                }
            );
        }
    };

    $scope.toggleFriendRequests = function () {
        $scope.showPendingRequests = !$scope.showPendingRequests;
    };

    $scope.acceptFriendRequest = function(request){
        if (authentication.isLogged()) {
            var accessToken = authentication.getAccessToken();

            profile(accessToken).acceptRequest(request.id).$promise.then(
                function(){
                    var index =  $scope.pendingRequests.indexOf(request);
                    $scope.pendingRequests.splice(index, 1);

                    noty.showInfo('Friend request successfully accepted.');
                }, function(error){
                    noty.showError('Unsuccessful request accept!', error);
                }
            );
        }
    };

    $scope.rejectFriendRequest = function(request){
        if (authentication.isLogged()) {
            var accessToken = authentication.getAccessToken();

            profile(accessToken).rejectRequest(request.id).$promise.then(
                function(){
                    var index =  $scope.pendingRequests.indexOf(request);
                    $scope.pendingRequests.splice(index,1);

                    noty.showInfo('Friend request successfully rejected.');
                }, function(error){
                    noty.showError('Unsuccessful request reject!', error);
                }
            );
        }
    };

    $scope.searchUser = function () {
        var searchTerm = $scope.searchTerm.trim();

        if (authentication.isLogged() && searchTerm !== '') {
            var accessToken = authentication.getAccessToken();

            user(accessToken).searchUser(searchTerm).$promise.then(
                function(data) {
                    $scope.searchResults = data;
                },
                function(error) {
                    noty.showError('Error with search, please try again!', error);
                }
            );
        } else {
            $scope.searchResults = undefined;
        }
    };

    var interval = $interval($scope.getFriendRequests, 30000);
});