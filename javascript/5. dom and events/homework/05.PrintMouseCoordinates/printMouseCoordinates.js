document.addEventListener('mousemove', function(e) {
    var text = 'X:' + e.pageX + '; Y:' + e.pageY + ' Time: ' + Date() + '\n';

    var textArea = document.getElementById('mouse-coords');
    textArea.value = text + textArea.value;
});