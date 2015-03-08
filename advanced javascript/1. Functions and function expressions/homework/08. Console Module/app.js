var specialConsole = (function () {
    function writeLine() {
        var stringToPrint = arguments[0];
        
        if (arguments.length > 1) {
            var args = Array.prototype.slice.call(arguments);
            var replacements = args.slice(1, args.length);
            
            replacements.forEach(function (message, index) {
                stringToPrint = stringToPrint.replace('{' + index + '}', message);
            });
            
            console.log(stringToPrint);
        } else {
            console.log(arguments[0].toString());
        }
    }
    
    return {
        writeLine: writeLine,
        writeError: writeLine,
        writeWarning: writeLine
    };
})();

specialConsole.writeLine("message");
specialConsole.writeLine("{0}", "message");
specialConsole.writeWarning("{0} {1} {2}", "This", "is", "warning!");
specialConsole.writeWarning("{0} {1} {2}", "This", "is", "error!");