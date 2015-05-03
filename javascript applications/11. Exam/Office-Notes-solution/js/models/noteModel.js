var app = app || {};

app.noteModel = (function() {
    function NoteModel(baseUrl, requester, headers) {
        this.serviceUrl = baseUrl + 'classes/Note/';
        this.requester = requester;
        this.headers = headers;
    }

    NoteModel.prototype.getMyNotes = function(fullName, limit, page) {
        var skip = (page - 1) * 10;

        return this.requester.get(this.serviceUrl + '?where={"author":"' + fullName + '"}&count=1&limit=' + limit + '&skip=' + skip, this.headers.getHeaders(true));
    };

    NoteModel.prototype.getOfficeNotes = function(deadline, limit, page) {
        var skip = (page - 1) * 10;

        return this.requester.get(this.serviceUrl + '?where={"deadline":"' + deadline + '"}&count=1&limit=' + limit + '&skip=' + skip, this.headers.getHeaders(true));
    };

    NoteModel.prototype.addNote = function(title, text, deadline) {
        var userId = sessionStorage['userId'];
        var fullName = sessionStorage['fullName'];
        var data = {
            title: title,
            text: text,
            deadline: deadline,
            author: fullName,
            ACL: {}
        };
        data.ACL['*'] = { 'read': true };
        data.ACL[userId] = { 'write': true, 'read': true };

        return this.requester.post(this.serviceUrl, this.headers.getHeaders(true), data);
    };

    NoteModel.prototype.editNote = function(objectId, title, text, deadline) {
        var data = {
            title: title,
            text: text,
            deadline: deadline
        };

        return this.requester.put(this.serviceUrl + objectId, this.headers.getHeaders(true), data);
    };

    NoteModel.prototype.deleteNote = function(objectId) {
        return this.requester.remove(this.serviceUrl + objectId, this.headers.getHeaders(true));
    };

    NoteModel.prototype.getCurrentDate = function() {
        var date = new Date();
        var day = date.getDate();
        var month = date.getMonth() + 1;
        var year = date.getFullYear();

        if(day < 10) {
            day = '0' + day;
        }

        if(month < 10) {
            month = '0' + month;
        }

        return year + '-' + month + '-' + day;
    }

    return {
        load: function(baseUrl, requester, headers) {
            return new NoteModel(baseUrl, requester, headers);
        }
    }
}());