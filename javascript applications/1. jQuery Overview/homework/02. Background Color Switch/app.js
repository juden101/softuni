$(function() {
    $('#paintElement').on('click', function(e) {
        var elementClass = $('#elementClass').val();
        var elementColor = $('#elementColor').val();

        if (elementClass) {
            $('.' + elementClass).css('background', elementColor)
        }

        e.preventDefault();
    });
});