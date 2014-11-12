function displayProperties() {
    var arr = Object.getOwnPropertyNames(document);
    arr.sort();

    for(var i = 0; i < arr.length; i++) {
        console.log(arr[i]);
    }
}

displayProperties();