function solve(input) {
    var sort, studentsSort, users = {
        'students': [],
        'trainers': []
    };

    sort = input[0].split('^');
    studentsSort = sort[0];

    for (var i = 1; i < input.length; i++) {
        var currentObject = JSON.parse(input[i]);
        var currentUser = {};

        if (currentObject.role == 'student') {
            var studentAverageGrade = 0;
            for (grade in currentObject.grades) {
                studentAverageGrade += Number(currentObject.grades[grade]);
            }
            studentAverageGrade /= currentObject.grades.length;

            currentUser.id = currentObject.id;
            currentUser.firstname = currentObject.firstname;
            currentUser.lastname = currentObject.lastname;
            currentUser.averageGrade = studentAverageGrade.toFixed(2);
            currentUser.certificate = currentObject.certificate;
            currentUser.level = currentObject.level;

            users['students'].push(currentUser);
        }
        else if (currentObject.role == 'trainer') {
            var trainerCourses = [];
            for (var course in currentObject.courses) {
                trainerCourses.push(currentObject.courses[course]);
            }

            currentUser.id = currentObject.id;
            currentUser.firstname = currentObject.firstname;
            currentUser.lastname = currentObject.lastname;
            currentUser.courses = trainerCourses;
            currentUser.lecturesPerDay = currentObject.lecturesPerDay;

            users['trainers'].push(currentUser);
        }
    }

    users['students'].sort(function (a, b) {
        if (studentsSort == 'name') {
            if (a.firstname < b.firstname) return -1;
            if (a.firstname > b.firstname) return 1;
            if (a.lastname < b.lastname) return -1;
            if (a.lastname > b.lastname) return 1;
            return 0;
        }
        else if (studentsSort == 'level') {
            if (a.level < b.level) return -1;
            if (a.level > b.level) return 1;
            if (a.id < b.id) return -1;
            if (a.id > b.id) return 1;

            return 0;
        }
    });

    users['trainers'].sort(function (a, b) {
        if (a.courses.length < b.courses.length) return -1;
        if (a.courses.length > b.courses.length) return 1;
        if (a.lecturesPerDay < b.lecturesPerDay) return -1;
        if (a.lecturesPerDay > b.lecturesPerDay) return 1;

        return 0;
    });

    for (var currentUser in users['students']) {
        delete users['students'][currentUser]['level'];
    }

    console.log(JSON.stringify(users));
}