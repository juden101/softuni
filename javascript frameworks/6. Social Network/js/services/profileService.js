'use strict';

SocialNetworkApp.factory('profile', function($http, $q, $resource, baseServiceUrl) {
    return function(accessToken) {
        $http.defaults.headers.common['Authorization'] = 'Bearer ' + accessToken;

        var profile = {};
        var resource = $resource(
            baseServiceUrl + '/me/:option1/:option2',
            {
                option1: '@option1',
                option2: '@option2'
            },
            {
                edit: {
                    method: 'PUT'
                }
            }
        );

        profile.userProfile = function(){
            return resource.get();
        };

        profile.update = function(data, option1){
            return resource.edit({option1: option1}, data);
        };
        /*
        profile.getNewsFeed = function(pageSize, startPostId){
            var option1 = 'feed?StartPostId' + (startPostId ? "=" + startPostId : "") + "&PageSize=" + pageSize;

            return resource.query({ option1: option1});
        };

        profile.getFriendsList = function(){
            return resource.query({ option1: 'friends'});
        };

        profile.getFriendsListPreview = function(){
            return resource.get({ option1: 'friends', option2: 'preview'});
        };

        profile.sendFriendRequest = function(username){
            return resource.save({ option1: 'requests', option2: username});
        };

        profile.getPendingRequests = function(){
            return resource.query({ option1: 'requests' });
        };

        profile.acceptRequest = function(requestId){
            var option2 = '' + requestId + '?status=approved';

            return resource.edit({ option1: 'requests', option2: option2});
        };

        profile.rejectRequest = function(requestId){
            var option2 = '' + requestId + '?status=rejected';

            return resource.edit({ option1: 'requests', option2: option2});
        };*/

        return profile;
    }
});