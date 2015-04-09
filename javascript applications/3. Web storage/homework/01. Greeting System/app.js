(function(){
    function login(e) {
        var username = $('#username').val();
        localStorage.setItem('username', username);
    }

    if(!localStorage['visitsCount']) {
        localStorage.setItem('visitsCount', 0);
    }

    if(!sessionStorage['visitsCount']) {
        sessionStorage.setItem('visitsCount', 0);
    }

    localStorage['visitsCount']++;
    sessionStorage['visitsCount']++;

    $('<div>').text('Total visits: ' + localStorage['visitsCount']).appendTo('#wrapper');
    $('<div>').text('Session visits: ' + sessionStorage['visitsCount']).appendTo('#wrapper');

    if(localStorage['username']) {
        $('form').hide();
        $('#greeting').text('Hello, ' + localStorage['username'] + '!');
    } else {
        $('#loginButton').on('click', login);
    }
})();