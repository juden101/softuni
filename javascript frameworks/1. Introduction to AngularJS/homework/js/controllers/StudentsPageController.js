"use strict";

app.controller('StudentsController', function ($scope) {
    var model = {
		"name": "Pesho",
		"photo": "http://www.nakov.com/wp-content/uploads/2014/05/SoftUni-Logo.png",
		"grade": 5,
		"school": "High School of Mathematics",
		"teacher": "Gichka Pesheva",
	};
	
	angular.extend($scope, model);
});