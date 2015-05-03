var app = app || {};

app.noty = (function() {
    function Noty() {
    }

    Noty.prototype.showError = function (message) {
        $('#error-message').noty({
            text: message,
            type: 'error',
            closeButton: true,
            timeout: 4000
        });
    };

    Noty.prototype.showSuccess = function (message) {
        $('#success-message').noty({
            text: message,
            type: 'success',
            timeout: 2000
        });
    };

    return {
        load : function () {
            return new Noty();
        }
    }
}());