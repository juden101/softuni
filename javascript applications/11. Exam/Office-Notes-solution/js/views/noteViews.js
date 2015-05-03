var app = app || {};

app.noteViews = (function() {
    function NoteViews() {
        this.addNoteView = {
            loadAddNoteView: loadAddNoteView
        };

        this.editNoteView = {
            loadEditNoteView: loadEditNoteView
        };

        this.deleteNoteView = {
            loadDeleteNoteView: loadDeleteNoteView
        };

        this.myNotesView = {
            loadMyNotesView: loadMyNotesView
        };

        this.officeNotesView = {
            loadOfficeNotesView: loadOfficeNotesView
        };
    }

    function loadAddNoteView(selector) {
        $.get('templates/addNote.html', function(template) {
            var outputHtml = Mustache.render(template);
            $(selector).html(outputHtml);
        }).then(function() {
            $('#addNoteButton').click(function() {
                var data = {
                    title: $('#title').val(),
                    text: $('#text').val(),
                    deadline: $('#deadline').val()
                };

                $.sammy(function() {
                    this.trigger('addNote', data)
                });

                return false;
            });
        }).done();
    }

    function loadEditNoteView(selector, data) {
        $.get('templates/editNote.html', function(template) {
            var outputHtml = Mustache.render(template, data);
            $(selector).html(outputHtml);
        }).then(function() {
            $('#editNoteButton').click(function() {
                var note = $(this).parent().parent();

                var data = {
                    objectId: note.attr('data-id'),
                    title: note.find('#title').val(),
                    text: note.find('#text').val(),
                    deadline: note.find('#deadline').val()
                };

                $.sammy(function() {
                    this.trigger('editNote', data);
                });

                return false;
            });
        }).done();
    }

    function loadDeleteNoteView(selector, data) {
        $.get('templates/deleteNote.html', function(template) {
            var outputHtml = Mustache.render(template, data);
            $(selector).html(outputHtml);
        }).then(function() {
            $('#deleteNoteButton').click(function() {
                var note = $(this).parent().parent();

                var data = {
                    objectId: note.attr('data-id'),
                    title: note.find('#title').val(),
                    text: note.find('#text').val(),
                    deadline: note.find('#deadline').val()
                };

                $.sammy(function() {
                    this.trigger('deleteNote', data);
                });

                return false;
            });
        }).done();
    }

    function loadMyNotesView(selector, data) {
        $.get('templates/myNoteTemplate.html', function(template) {
            var outputHtml = Mustache.render(template, data);
            $(selector).html(outputHtml);

            $('#pagination').pagination({
                items: data.count,
                itemsOnPage: data.limit,
                cssStyle: 'light-theme',
                hrefTextPrefix: '#/myNotes/'
            }).pagination('selectPage', data.page);
    });
    }

    function loadOfficeNotesView(selector, data) {
        $.get('templates/officeNoteTemplate.html', function(template) {
            var outputHtml = Mustache.render(template, data);
            $(selector).html(outputHtml);

            $('#pagination').pagination({
                items: data.count,
                itemsOnPage: data.limit,
                cssStyle: 'light-theme',
                hrefTextPrefix: '#/office/'
            }).pagination('selectPage', data.page);
        });
    }

    return {
        load: function() {
            return new NoteViews();
        }
    }
}());