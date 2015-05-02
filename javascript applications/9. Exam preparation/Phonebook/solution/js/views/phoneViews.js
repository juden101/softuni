var app = app || {};

app.phoneViews = (function() {
    function PhoneViews() {
        this.allPhonesView = {
            loadAllPhonesView: loadAllPhonesView
        };

        this.editPhoneView = {
            loadEditPhoneView: loadEditPhoneView
        };

        this.deletePhoneView = {
            loadDeletePhoneView: loadDeletePhoneView
        };

        this.addPhoneView = {
            loadAddPhoneView: loadAddPhoneView
        };
    }

    function loadAllPhonesView(selector, data) {
        $.get('templates/phonebook.html', function(template) {
            var outputHtml = Mustache.render(template, data);
            $(selector).html(outputHtml);
        });
    }

    function loadEditPhoneView(selector, data) {
        $.get('templates/edit-phone.html', function(template) {
            var outputHtml = Mustache.render(template, data);
            $(selector).html(outputHtml);
        }).then(function() {
            $('#editPhoneButton').click(function() {
                var editPhoneData = {
                    id: data.id,
                    name: $('#name').val(),
                    phoneNumber: $('#phoneNumber').val()
                };

                $.sammy(function() {
                    this.trigger('editPhone', editPhoneData)
                });

                return false;
            });
        }).done();
    }

    function loadDeletePhoneView(selector, data) {
        $.get('templates/delete-phone.html', function(template) {
            var outputHtml = Mustache.render(template, data);
            $(selector).html(outputHtml);
        }).then(function() {
            $('#deletePhoneButton').click(function() {
                var deletePhoneData = {
                    id: data.id
                };

                $.sammy(function() {
                    this.trigger('deletePhone', deletePhoneData)
                });

                return false;
            });
        }).done();
    }

    function loadAddPhoneView(selector) {
        $.get('templates/add-phone.html', function(template) {
            var outputHtml = Mustache.render(template);
            $(selector).html(outputHtml);
        }).then(function() {
            $('#addPhoneButton').click(function() {
                var data = {
                    name: $('#name').val(),
                    phoneNumber: $('#phoneNumber').val()
                };

                $.sammy(function() {
                    this.trigger('addPhone', data)
                });

                return false;
            });
        }).done();
    }

    return {
        load: function() {
            return new PhoneViews();
        }
    }
}());