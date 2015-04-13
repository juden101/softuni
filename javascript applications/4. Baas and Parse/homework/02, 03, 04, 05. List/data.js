var app = app || {};

(function(scope) {
    scope.data = {};

    var CRUD = function(crudMethod, crudUrl, crudData, crudSuccessCallback, crudErrorCallback) {
        var PARSE_APP_ID = "9MHZxQnJ7SqHiwNYJCY8qlswx9JydjNfcpKbYuma";
        var PARSE_REST_API_KEY = "CA3pxLzyS783MrSQB4xgkH7Y6A9cYe8n3FU9StzZ";

        $.ajax({
            method: crudMethod,
            headers: {
                'X-Parse-Application-Id': PARSE_APP_ID,
                'X-Parse-REST-API-Key': PARSE_REST_API_KEY,
                'Content-Type' : 'application/json'
            },
            url: crudUrl,
            data: JSON.stringify(crudData)
        }).success(crudSuccessCallback).error(crudErrorCallback);
    }

    scope.loadCountries = function() {
        CRUD('GET', 'https://api.parse.com/1/classes/Country', null, scope.successfulCountriesLoad, scope.showAJAXError);
    };

    scope.loadCountryTowns = function(e) {
        var countryId = $(this).parent().attr('data-id');
        var getCountryTownsURL = 'https://api.parse.com/1/classes/Town?where={"country":{"__type":"Pointer","className":"Country","objectId":"' + countryId + '"}}';

        scope.data.countryId = countryId;
        CRUD('GET', getCountryTownsURL, null, scope.successfulTownsLoad, scope.showAJAXError);

        e.preventDefault();
    };

    scope.editCountry = function(e) {
        var countryId = $('#edit-country').attr('data');
        var country = $('#edit-country-value').val();
        var editData = { 'name': country };

        CRUD('PUT', 'https://api.parse.com/1/classes/Country/' + countryId, editData, scope.reloadCountries, scope.showAJAXError);

        e.preventDefault();
    };

    scope.editTown = function(e) {
        var townId = $('#edit-town-value').attr('data');
        var town = $('#edit-town-value').val();
        var editData = { 'name': town };

        CRUD('PUT', 'https://api.parse.com/1/classes/Town/' + townId, editData, scope.reloadCountries, scope.showAJAXError);

        e.preventDefault();
    };

    scope.deleteCountry = function(e) {
        var countryId = $(this).parent().attr('data-id');

        CRUD('DELETE', 'https://api.parse.com/1/classes/Country/' + countryId, null, scope.reloadCountries, scope.showAJAXError);

        e.preventDefault();
    };

    scope.deleteTown = function(e) {
        var townId = $(this).parent().attr('data-id');

        CRUD('DELETE', 'https://api.parse.com/1/classes/Town/' + townId, null, scope.reloadCountries, scope.showAJAXError);

        e.preventDefault();
    };

    scope.addNewCountry = function(e) {
        var newCountryValue = $('#add-country').val();
        var newCountryData = { 'name': newCountryValue };

        scope.CRUD('POST', 'https://api.parse.com/1/classes/Country', newCountryData, scope.reloadCountries, scope.showAJAXError);

        $('#add-country').val('');
        e.preventDefault();
    };

    scope.addNewTown = function(e) {
        var newTownValue = $('#new-town-value').val();
        var countryId = $('#new-town-value').attr('data');
        var newTownData = {
            'country': {
                "__type": "Pointer",
                "className": "Country",
                "objectId": countryId
            },
            'name': newTownValue
        };

        CRUD('POST', 'https://api.parse.com/1/classes/Town', newTownData, scope.reloadCountries, scope.showAJAXError);

        e.preventDefault();
    };
}(app));