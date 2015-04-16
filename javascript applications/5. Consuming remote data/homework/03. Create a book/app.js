var app = app || {};

(function(scope) {
    $(function() {
        var PARSE_APP_ID = "MlhVXOw8d3CJf26nX5HzA1rcRnASU4JQYlmSdi5K";
        var PARSE_REST_API_KEY = "SJY0ReUvl0mrkmMiE3NFhPdmMGKoENpoLbjRx9Rs";

        $('#book-create').on('click', function(e) {
            var bookTitle = $('#book-title').val();
            var bookAuthor = $('#book-author').val();
            var bookIsbn = $('#book-isbn').val();

            var bookData = {
                'title' : bookTitle,
                'author' : bookAuthor,
                'isbn' : bookIsbn
            };

            $.ajax({
                method: 'POST',
                headers: {
                    'X-Parse-Application-Id': PARSE_APP_ID,
                    'X-Parse-REST-API-Key': PARSE_REST_API_KEY,
                    'Content-Type' : 'application/json'
                },
                url: 'https://api.parse.com/1/classes/Book',
                data: JSON.stringify(bookData)
            }).success(function(data) {
                $('#book-title').val('');
                $('#book-author').val('');
                $('#book-isbn').val('');
                alert("Book successfully created!");
            }).error(function(err) {
                alert("Error while creating new book!");
            });

            e.preventDefault();
        });
    });
}(app));