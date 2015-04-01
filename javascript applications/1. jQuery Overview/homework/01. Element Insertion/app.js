$(function() {
    $('#addElement').on('click', function(e) {
        var elementValue = $('#elementValue').val();
        var elementPosition = $('#elementPosition').find(':selected').val();

        var $elements = $('#elements');
        var $pElement = $('<p>').text(elementValue);

        if (elementPosition == 'before') {
            $pElement.prependTo($elements);
        }
        else if (elementPosition == 'after') {
            $pElement.appendTo($elements);
        }

        e.preventDefault();
    });
});