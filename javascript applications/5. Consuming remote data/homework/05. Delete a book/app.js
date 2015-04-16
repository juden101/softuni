var app = app || {};

(function(scope) {
    $(function() {
        var PARSE_APP_ID = "MlhVXOw8d3CJf26nX5HzA1rcRnASU4JQYlmSdi5K";
        var PARSE_REST_API_KEY = "SJY0ReUvl0mrkmMiE3NFhPdmMGKoENpoLbjRx9Rs";

        var deleteBook = function(e) {
            var bookId = $(this).attr('data-id');

            $.ajax({
                method: 'DELETE',
                headers: {
                    'X-Parse-Application-Id': PARSE_APP_ID,
                    'X-Parse-REST-API-Key': PARSE_REST_API_KEY
                },
                url: 'https://api.parse.com/1/classes/Book/' + bookId
            }).success(function(data) {
                alert("Book successfully deleted!");
                $("#books").text('');
                listAllBooks();
            }).error(function(err) {
                alert("Error while deleting new book!");
            });

            e.preventDefault();
        }

        var listAllBooks = function() {
            $.ajax({
                method: 'GET',
                headers: {
                    'X-Parse-Application-Id': PARSE_APP_ID,
                    'X-Parse-REST-API-Key': PARSE_REST_API_KEY
                },
                url: 'https://api.parse.com/1/classes/Book'
            }).success(function(data) {
                for (var b in data.results) {
                    var book = data.results[b];
                    var bookRow = $('<tr>');
                    bookRow.append($('<td id="title">').text(book.title));
                    bookRow.append($('<td id="author">').text(book.author));
                    bookRow.append($('<td id="isbn">').text(book.isbn));
                    bookRow.append($('<td>').html($('<a href="#" data-id="' + book.objectId + '">').text('Delete').on('click', deleteBook)));
                    bookRow.appendTo($("#books"));
                }
            }).error(function(err) {
                alert(err);
            });
        };

        listAllBooks();
    });
}(app));