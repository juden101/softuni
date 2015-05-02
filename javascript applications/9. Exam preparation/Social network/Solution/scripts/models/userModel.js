var app = app || {};

app.userModel = (function() {
    function UserModel(baseUrl, requester, headers) {
        this.baseUrl = baseUrl;
        this.requester = requester;
        this.headers = headers;
    }

    UserModel.prototype.login = function(username, password) {
        var serviceUrl = this.baseUrl + 'login?username=' + username + '&password=' + password;
        return this.requester.get(serviceUrl, this.headers.getHeaders());
    };

    UserModel.prototype.register = function(username, password, name, about, gender, picture) {
        var serviceUrl = this.baseUrl + 'users';
        var data = {
            username: username,
            password: password,
            name: name,
            about: about,
            gender: gender,
            picture: picture
        };

        return this.requester.post(serviceUrl, this.headers.getHeaders(true), data);
    };

    UserModel.prototype.editProfile = function(userId, username, password, name, about, gender, picture) {
        var serviceUrl = this.baseUrl + 'users/' + userId;
        var data = {};

        if (username !== '') {
            data.username = username;
        }

        if (password !== '') {
            data.password = password;
        }

        if (name !== '') {
            data.name = name;
        }

        if (about !== '') {
            data.about = about;
        }

        if (gender !== undefined) {
            data.gender = gender;
        }

        if (picture !== undefined) {
            data.picture = picture;
        }

        return this.requester.put(serviceUrl, this.headers.getHeaders(true), data);
    };

    UserModel.prototype.logout = function() {
        var serviceUrl = this.baseUrl + 'logout';

        return this.requester.post(serviceUrl, this.headers.getHeaders(true));
    };

    return {
        load: function(baseUrl, requester, headers) {
            return new UserModel(baseUrl, requester, headers);
        }
    }
}());