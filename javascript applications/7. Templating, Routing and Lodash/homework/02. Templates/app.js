(function() {
    $.get('template.html', function (template) {
        var employees = {
            'employees' : [
                { 'name': 'Garry Finch', 'jobTitle': 'Front End Technical Lead', 'website': 'http://website.com' },
                { 'name': 'Bob McFray', 'jobTitle': 'Photographer', 'website': 'http://goo.gle' },
                { 'name': 'Jenny O\'Sullivan', 'jobTitle': 'Lego Geek', 'website': 'http://stackoverflow.com' }
            ]
        };

        var output = Mustache.render(template, employees);
        $('#wrapper').html(output);
    })
}());