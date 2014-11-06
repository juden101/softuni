var date = new Date();
var currentDate = ('0' + date.getHours()).slice(-2) + ':' + ('0' + date.getMinutes()).slice(-2);

console.log(currentDate);