var numbersField = document.getElementById('numbers-field');
var submitButton = document.getElementById('form-submit');

numbersField.addEventListener('keyup', function(e) {
    console.log(this.value);

    if(this.value == '' || isInt(this.value)) {
        this.style.background = '#fff';
    }
    else {
        this.style.background = '#f00';
    }
})

submitButton.addEventListener('click', function(e) {
    e.preventDefault();
})

function isInt(value) {
    var x = parseFloat(value);
    return !isNaN(value) && (x | 0) === x;
}