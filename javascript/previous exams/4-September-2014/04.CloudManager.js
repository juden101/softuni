function solve(input) {
    var manager = {};

    function sortObjectProperties(obj) {
        var keysSorted = Object.keys(obj).sort();
        var sortedObj = {};
        for (var i = 0; i < keysSorted.length; i++) {
            var key = keysSorted[i];
            sortedObj[key] = obj[key];
        }

        return sortedObj;
    }

    for(var row in input) {
        var fileProperties, fileName, fileExtension, fileSize;
        var fileProperties = input[row].split(' ');

        fileName = fileProperties[0];
        fileExtension = fileProperties[1];
        fileSize = fileProperties[2];
        fileSize = fileSize.substring(0, fileSize.length - 2);

        if(!manager[fileExtension]) {
            manager[fileExtension] = {
                'files': [],
                'memory': 0
            }
        }

        if(manager[fileExtension]['files'].indexOf(fileName) == -1) {
            manager[fileExtension]['files'].push(fileName);
        }

        var newMemory = Number(manager[fileExtension]['memory']) + Number(fileSize);
        manager[fileExtension]['memory'] = newMemory.toFixed(2);
    }

    manager = sortObjectProperties(manager);
    for(var extension in manager) {
        manager[extension]['files'].sort();
    }

    console.log(JSON.stringify(manager));
}