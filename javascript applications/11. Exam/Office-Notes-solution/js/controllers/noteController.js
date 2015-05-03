var app = app || {};

app.noteController = (function() {
    function NoteController(model, views, noty) {
        this.model = model;
        this.viewBag = views;
        this.noty = noty;
    }

    NoteController.prototype.loadAddNotePage = function(selector) {
        this.viewBag.addNoteView.loadAddNoteView(selector);
    };

    NoteController.prototype.loadMyNotesPage = function(selector, page) {
        var _this = this;
        var fullName = sessionStorage['fullName'];
        var limit = 10;

        this.model.getMyNotes(fullName, limit, page)
            .then(function (notesData) {
                notesData.limit = limit;
                notesData.page = page;

                _this.viewBag.myNotesView.loadMyNotesView(selector, notesData);
            }, function (error) {
                _this.noty.showError(error.responseJSON.error);
            });
    };

    NoteController.prototype.loadOfficeNotesPage = function(selector, page) {
        var _this = this;
        var today = this.model.getCurrentDate();
        var limit = 10;

        this.model.getOfficeNotes(today, limit, page)
            .then(function (notesData) {
                notesData.limit = limit;
                notesData.page = page;

                _this.viewBag.officeNotesView.loadOfficeNotesView(selector, notesData);
            }, function (error) {
                _this.noty.showError(error.responseJSON.error);
            });
    };

    NoteController.prototype.loadNotePage = function(selector, urlParams, action) {
        var data = urlParams.split('&');
        var outData = {
            objectId : data[0].split('id=')[1],
            title: data[1].split('title=')[1],
            text: data[2].split('text=')[1],
            deadline: data[3].split('deadline=')[1]
        };

        if (action == 'edit') {
            this.viewBag.editNoteView.loadEditNoteView(selector, outData);
        }
        else if (action == 'delete') {
            this.viewBag.deleteNoteView.loadDeleteNoteView(selector, outData);
        }
    };

    NoteController.prototype.addNote = function(title, text, deadline) {
        var _this = this;

        return this.model.addNote(title, text, deadline)
            .then(function(noteData) {
                window.location = '#/myNotes/';
                _this.noty.showSuccess('Note added successfully.');
            }, function(error) {
                _this.noty.showError(error.responseJSON.error);
            });
    };

    NoteController.prototype.editNote = function(objectId, title, text, deadline) {
        var _this = this;

        return this.model.editNote(objectId, title, text, deadline)
            .then(function(noteData) {
                window.location = '#/myNotes/';
                _this.noty.showSuccess('Note edited successfully.');
            }, function(error) {
                _this.noty.showError(error.responseJSON.error);
            });
    };

    NoteController.prototype.deleteNote = function(objectId) {
        var _this = this;

        return this.model.deleteNote(objectId)
            .then(function(noteData) {
                window.location = '#/myNotes/';
                _this.noty.showSuccess('Note deleted successfully.');
            }, function(error) {
                _this.noty.showError(error.responseJSON.error);
            });
    };

    return {
        load: function(model, views, noty) {
            return new NoteController(model, views, noty);
        }
    }
}());