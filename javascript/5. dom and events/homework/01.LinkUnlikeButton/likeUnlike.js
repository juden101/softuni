var button = document.getElementById('like');

button.addEventListener('click', function(e) {
    if(this.value == 'Like') {
        this.value = 'Unlike';
    }
    else {
        this.value = 'Like';
    }

    e.preventDefault();
})