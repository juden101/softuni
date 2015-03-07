var domModule = (function domModule() {
    function appendChild(domElement, selector) {
        var target = document.querySelector(selector);

        target.appendChild(domElement);
    }
    
    function removeChild(parentSelector, childSelector) {
        var target = document.querySelector(parentSelector);
        var child = target.querySelector(childSelector);

        target.removeChild(child);
    }
    
    function addHandler(selector, eventHandler, event) {
        var target = document.querySelectorAll(selector);

        for (var i = 0; i < target.length; i++) {
            target[i].addEventListener(eventHandler, event);
        }
    }
    
    function retrieveElements(selector) {
        var elements = document.querySelectorAll(selector);

        return elements;
    }
    
    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        retrieveElements: retrieveElements
    };
})();

// IMPORTANT: Test this in browser!
var liElement = document.createElement("li");

// Appends a list item to ul.birds-list
domModule.appendChild(liElement, ".birds-list");

// Removes the first li child from the bird list
domModule.removeChild("ul.birds-list", "li:first-child");

// Adds a click event to all bird list items
domModule.addHandler("li.bird", "click", function() {
    alert("Hello there!");
});

// Retrives all elements of class "bird"
var elements = domModule.retrieveElements(".bird");
console.log(elements);