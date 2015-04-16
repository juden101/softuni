var app = app || {};

(function(scope) {
    $(function() {
        listAllBooks();
    });
	
	var PARSE_APP_ID = "MlhVXOw8d3CJf26nX5HzA1rcRnASU4JQYlmSdi5K";
	var PARSE_REST_API_KEY = "SJY0ReUvl0mrkmMiE3NFhPdmMGKoENpoLbjRx9Rs";

	var listAllBooks = function() {
		$.ajax({
			method: 'GET',
			headers: {
				'X-Parse-Application-Id': PARSE_APP_ID,
				'X-Parse-REST-API-Key': PARSE_REST_API_KEY
			},
			url: 'https://api.parse.com/1/classes/Book'
		}).success(function(data) {
			$("#books").text('');
		
			for (var b in data.results) {
				var book = data.results[b];
				var bookRow = $('<tr>');
				bookRow.append($('<td id="title">').text(book.title));
				bookRow.append($('<td id="author">').text(book.author));
				bookRow.append($('<td id="isbn">').text(book.isbn));
				bookRow.append($('<td>').html($('<a href="#" data-id="' + book.objectId + '">').text('Edit').on('click', showEditForm)));
				bookRow.append($('<td>').html($('<a href="#" data-id="' + book.objectId + '">').text('Delete').on('click', deleteBook)));
				bookRow.appendTo($("#books"));
			}
		}).error(function(err) {
			alert(err);
		});
	};
	
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

	var showEditForm = function() {
		var currentRow = $(this).parent().parent();
		var bookTitle = currentRow.find('#title').text();
		var bookAuthor = currentRow.find('#author').text();
		var bookIsbn = currentRow.find('#isbn').text();
		var bookId = $(this).attr('data-id');

		$('#book-title').val(bookTitle);
		$('#book-author').val(bookAuthor);
		$('#book-isbn').val(bookIsbn);
		$('#book-id').val(bookId);
		$('#book-form').fadeIn();
	}
	
	$('#book-edit').on('click', function(e) {
		var bookId = $('#book-id').val();
		var bookTitle = $('#book-title').val();
		var bookAuthor = $('#book-author').val();
		var bookIsbn = $('#book-isbn').val();

		var bookData = {
			'title' : bookTitle,
			'author' : bookAuthor,
			'isbn' : bookIsbn
		};

		$.ajax({
			method: 'PUT',
			headers: {
				'X-Parse-Application-Id': PARSE_APP_ID,
				'X-Parse-REST-API-Key': PARSE_REST_API_KEY,
				'Content-Type' : 'application/json'
			},
			url: 'https://api.parse.com/1/classes/Book/' + bookId,
			data: JSON.stringify(bookData)
		}).success(function(data) {
			alert("Book successfully edited!");
			$('#book-form').fadeOut();
			$("#books").text('');
			listAllBooks();
		}).error(function(err) {
			alert("Error while creating new book!");
		});

		e.preventDefault();
	});
	
	$('#book-create').on('click', function(e) {
		var bookTitle = $('#new-book-title').val();
		var bookAuthor = $('#new-book-author').val();
		var bookIsbn = $('#new-book-isbn').val();

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
			$('#new-book-title').val('');
			$('#new-book-author').val('');
			$('#new-book-isbn').val('');
			listAllBooks();
			alert("Book successfully created!");
		}).error(function(err) {
			alert("Error while creating new book!");
		});

		e.preventDefault();
	});
}(app));