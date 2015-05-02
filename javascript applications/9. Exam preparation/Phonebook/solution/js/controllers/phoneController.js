var app = app || {};

app.phoneController = (function() {
    function PhoneController(model, views, noty) {
        this.model = model;
        this.viewBag = views;
        this.noty = noty;
    }

    PhoneController.prototype.loadAllPhonesPage = function(selector) {
        var _this = this;

        return this.model.listAllPhones()
            .then(function(data) {
                _this.viewBag.allPhonesView.loadAllPhonesView(selector, data);
            }, function(error) {
                console.log(error.responseJSON);
            });
    };

    PhoneController.prototype.loadPhonePage = function(selector, urlParams, action) {
        var paramsData = urlParams.split('&');
        var data = {
            id: paramsData[0].split('id=')[1],
            name: paramsData[1].split('name=')[1],
            phoneNumber: paramsData[2].split('phoneNumber=')[1]
        };

        if (action === 'delete') {
            this.viewBag.deletePhoneView.loadDeletePhoneView(selector, data);
        }
        else {
            this.viewBag.editPhoneView.loadEditPhoneView(selector, data);
        }
    };

    PhoneController.prototype.loadAddPhonePage = function(selector) {
        this.viewBag.addPhoneView.loadAddPhoneView(selector);
    };

    PhoneController.prototype.addPhone = function(name, phoneNumber) {
        var _this = this;

        return this.model.addPhone(name, phoneNumber)
            .then(function() {
                window.location = '#/phones/';
                _this.noty.showSuccess('#success-message', 'Phone added successfully.');
            }, function(error) {
                _this.noty.showError('#error-message', error.responseJSON.error);
            });
    };

    PhoneController.prototype.editPhone = function(id, name, phoneNumber) {
        var _this = this;

        return this.model.editPhone(id, name, phoneNumber)
            .then(function() {
                window.location = '#/phones/';
                _this.noty.showSuccess('#success-message', 'Phone edited successfully.');
            }, function(error) {
                _this.noty.showError('#error-message', error.responseJSON.error);
            });
    };

    PhoneController.prototype.deletePhone = function(id) {
        var _this = this;

        return this.model.deletePhone(id)
            .then(function() {
                window.location = '#/phones/';
                _this.noty.showSuccess('#success-message', 'Phone edited successfully.');
            }, function(error) {
                _this.noty.showError('#error-message', error.responseJSON.error);
            });
    };

    return {
        load: function(model, views, noty) {
            return new PhoneController(model, views, noty)
        }
    }
}());