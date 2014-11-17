var button = document.getElementById('btnHideOddRows');

button.addEventListener('click', function(e) {
    var cells = document.getElementsByTagName('td');

    for(var i = 0; i < cells.length; i += 2) {
        if(cells[i].style.display == 'block' || cells[i].style.display == '') {
            cells[i].style.display = 'none';
        }
        else {
            cells[i].style.display = 'block';
        }
    }

    e.preventDefault();
})