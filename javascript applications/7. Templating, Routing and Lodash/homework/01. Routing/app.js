var app = app || {};

(function() {
    var names = [
        'Pesho',
        'Gosho',
        'Svetlin',
        'Bogomil',
        'Angel'
    ];

    var loadNames = function(selector) {
        if ($(selector).html() == '') {
            $(names).each(function(index, element) {
                $(selector).append($('<p/>').html($('<a/>').attr('href', '#/' + element).text(element)));
            });
        }
    };

    app.router = Sammy(function () {
        var namesSelector = '#names';
        var greetingSelector = '#greeting';

        this.get('#/', function() {
            loadNames(namesSelector);
        });

        this.get('#/:name', function(context) {
            loadNames(namesSelector);

            var currentName = context.params.name;
            $(greetingSelector).html($('<h2/>').text('Hello, ' + currentName));
        });
    });

    app.router.run('#/');
}());