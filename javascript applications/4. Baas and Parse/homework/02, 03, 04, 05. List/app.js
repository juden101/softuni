(function() {
    $(function() {
        loadCountries();

        $('#submit-country').on('click', addNewCountry);
        $('.country').on('click', showCountryTowns);
        $('#edit-country').on('click', editCountry);
        $('#edit-town').on('click', editTown);
    });

    var PARSE_APP_ID = "9MHZxQnJ7SqHiwNYJCY8qlswx9JydjNfcpKbYuma";
    var PARSE_REST_API_KEY = "CA3pxLzyS783MrSQB4xgkH7Y6A9cYe8n3FU9StzZ";

    var reloadCountries = function() {
        $('#countries').text('');
        loadCountries();
        $('#edit-country-form').fadeOut();
        $('#edit-town-form').fadeOut();
        $('#selectedCountryTowns').text('');
    };

    var loadCountries = function() {
        $.ajax({
            method: 'GET',
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY
            },
            url: 'https://api.parse.com/1/classes/Country'
        }).success(function(data) {
            for (var c in data.results) {
                var country = data.results[c];
                var countryItemHolder = $('<li>').attr('class', 'country').attr('data-id', country.objectId);
                var editButton = $('<input type="button" data="' + country.name + '" value="Edit" />').bind('click', showEditCountryForm);
                var deleteButton = $('<input type="button" value="Delete" />').bind('click', deleteCountry);

                countryItemHolder.append(editButton);
                countryItemHolder.append(deleteButton);
                countryItemHolder.append($('<a href="#">').text(country.name).bind('click', showCountryTowns));
                countryItemHolder.appendTo($('#countries'));
            }
        }).error(function() {
            alert('Cannot load countries.');
        });
    };

    var showEditCountryForm = function(e) {
        var countryId = $(this).parent().attr('data-id');
        var country = $(this).attr('data');

        $('#edit-country-form').fadeIn();
        $('#edit-country-value').val(country);
        $('#edit-country').attr('data', countryId);
    };

    var showEditTownForm = function(e) {
        var townId = $(this).parent().attr('data-id');
        var town = $(this).attr('data');

        $('#edit-town-form').fadeIn();
        $('#edit-town-value').val(town);
        $('#edit-town-value').attr('data', townId);
    };

    var editCountry = function(e) {
        var countryId = $('#edit-country').attr('data');
        var country = $('#edit-country-value').val();

        $.ajax({
            method: 'PUT',
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY,
                'Content-Type' : 'application/json'
            },
            url: 'https://api.parse.com/1/classes/Country/' + countryId,
            data: JSON.stringify({
                'name': country
            })
        }).success(function(data) {
            reloadCountries();
            $('#edit-country-form').fadeOut();
        }).error(function(err) {
            alert('Cannot update country.');
        });

        e.preventDefault();
    };

    var editTown = function(e) {
        var townId = $('#edit-town-value').attr('data');
        var town = $('#edit-town-value').val();

        $.ajax({
            method: 'PUT',
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY,
                'Content-Type' : 'application/json'
            },
            url: 'https://api.parse.com/1/classes/Town/' + townId,
            data: JSON.stringify({
                'name': town
            })
        }).success(function(data) {
            reloadCountries();
            $('#edit-country-form').fadeOut();
            $('#edit-town-form').fadeOut();
        }).error(function(err) {
            alert('Cannot update town.');
        });

        e.preventDefault();
    };

    var deleteCountry = function(e) {
        var countryId = $(this).parent().attr('data-id');

        $.ajax({
            method: 'DELETE',
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY
            },
            url: 'https://api.parse.com/1/classes/Country/' + countryId
        }).success(function(data) {
            reloadCountries();
            $('#edit-country-form').fadeOut();
            $('#edit-town-form').fadeOut();
        }).error(function() {
            alert('Cannot delete this country.');
        });
    };

    var deleteTown = function(e) {
        var townId = $(this).parent().attr('data-id');

        $.ajax({
            method: 'DELETE',
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY
            },
            url: 'https://api.parse.com/1/classes/Town/' + townId
        }).success(function(data) {
            reloadCountries();
            $('#selectedCountryTowns').text('');
            $('#edit-country-form').fadeOut();
            $('#edit-town-form').fadeOut();
        }).error(function() {
            alert('Cannot delete this town.');
        });
    };

    var addNewCountry = function(e) {
        var newCountryValue = $('#add-country').val();

        $.ajax({
            method: 'POST',
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY,
                'Content-Type' : 'application/json'
            },
            url: 'https://api.parse.com/1/classes/Country',
            data: JSON.stringify({
                'name': newCountryValue
            })
        }).success(function(data) {
            reloadCountries();
            $('#edit-country-form').fadeOut();
            $('#edit-town-form').fadeOut();
        }).error(function() {
            alert('Cannot create new country.');
        });

        $('#add-country').val('');
        e.preventDefault();
    };

    var addNewTown = function(e) {
        var newTownValue = $('#new-town-value').val();
        var countryId = $('#new-town-value').attr('data');

        $.ajax({
            method: 'POST',
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY,
                'Content-Type' : 'application/json'
            },
            url: 'https://api.parse.com/1/classes/Town',
            data: JSON.stringify({
                'country': {
                    "__type": "Pointer",
                    "className": "Country",
                    "objectId": countryId
                },
                'name': newTownValue
            })
        }).success(function(data) {
            reloadCountries();
            $('#edit-country-form').fadeOut();
            $('#edit-town-form').fadeOut();
            $('#selectedCountryTowns').text('');
        }).error(function(err) {
            alert('Cannot create new town.');
        });

        e.preventDefault();
    }

    var showCountryTowns = function(e) {
        var countryId = $(this).parent().attr('data-id');

        $.ajax({
            method: "GET",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY
            },
            url: 'https://api.parse.com/1/classes/Town?where={"country":{"__type":"Pointer","className":"Country","objectId":"' + countryId + '"}}'
        }).success(function(data) {
            $('#selectedCountryTowns').text('');
            $('#edit-town-form').fadeOut();

            var townCreate = $('<form method="POST">');
            townCreate.append('<input type="text" id="new-town-value" data="' + countryId + '" placeholder="New town name..." />');
            townCreate.append($('<input type="submit" id="new-town-submit" value="Submit" />').bind('click', addNewTown));
            $('#selectedCountryTowns').append(townCreate);

            for (var t in data.results) {
                var town = data.results[t];
                var townItemHolder = $('<li>').attr('class', 'town').attr('data-id', town.objectId);

                var editButton = $('<input type="button" data="' + town.name + '" value="Edit" />').bind('click', showEditTownForm);
                var deleteButton = $('<input type="button" value="Delete" />').bind('click', deleteTown);

                townItemHolder.append(editButton);
                townItemHolder.append(deleteButton);
                townItemHolder.append($('<a>').text(town.name));
                townItemHolder.appendTo($('#selectedCountryTowns'));
            }
        }).error(function() {
            alert('Cannot load towns.');
        });
    }
})();