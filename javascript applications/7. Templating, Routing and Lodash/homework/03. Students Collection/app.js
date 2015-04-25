(function() {
    var students = [
        {"gender":"Male","firstName":"Joe","lastName":"Riley","age":22,"country":"Russia"},
        {"gender":"Female","firstName":"Lois","lastName":"Morgan","age":41,"country":"Bulgaria"},
        {"gender":"Male","firstName":"Roy","lastName":"Wood","age":33,"country":"Russia"},
        {"gender":"Female","firstName":"Diana","lastName":"Freeman","age":40,"country":"Argentina"},
        {"gender":"Female","firstName":"Bonnie","lastName":"Hunter","age":23,"country":"Bulgaria"},
        {"gender":"Male","firstName":"Joe","lastName":"Young","age":16,"country":"Bulgaria"},
        {"gender":"Female","firstName":"Kathryn","lastName":"Murray","age":22,"country":"Indonesia"},
        {"gender":"Male","firstName":"Dennis","lastName":"Woods","age":37,"country":"Bulgaria"},
        {"gender":"Male","firstName":"Billy","lastName":"Patterson","age":24,"country":"Bulgaria"},
        {"gender":"Male","firstName":"Willie","lastName":"Gray","age":42,"country":"China"},
        {"gender":"Male","firstName":"Justin","lastName":"Lawson","age":38,"country":"Bulgaria"},
        {"gender":"Male","firstName":"Ryan","lastName":"Foster","age":24,"country":"Indonesia"},
        {"gender":"Male","firstName":"Eugene","lastName":"Morris","age":37,"country":"Bulgaria"},
        {"gender":"Male","firstName":"Eugene","lastName":"Rivera","age":45,"country":"Philippines"},
        {"gender":"Female","firstName":"Kathleen","lastName":"Hunter","age":28,"country":"Bulgaria"}
    ];

    var visualiseStudents = function(studentsCollection, message) {
        var container = $('<p/>');
        container.append($('<h2/>').text(message));

        var studentsTable = $('<table><tr><td>First name</td><td>Last name</td><td>Age</td><td>Gender</td><td>Country</td></tr></table>').attr('border', 1);
        $(studentsCollection).each(function(index, student) {
            var row = $('<tr/>');

            $(row).append($('<td/>').text(student.firstName));
            $(row).append($('<td/>').text(student.lastName));
            $(row).append($('<td/>').text(student.age));
            $(row).append($('<td/>').text(student.gender));
            $(row).append($('<td/>').text(student.country));

            studentsTable.append(row);
        });
        container.append(studentsTable);

        $('#wrapper').append(container);
    };

    var ageBetween18And24 = _.filter(students, function(student) {
        return student.age >= 18 && student.age <= 24;
    });
    visualiseStudents(ageBetween18And24, 'Get all students with age between 18 and 24');

    var firstNameIsAlphabeticallyBeforeLastName = _.filter(students, function(student) {
        return student.firstName < student.lastName;
    });
    visualiseStudents(firstNameIsAlphabeticallyBeforeLastName, 'Get all students whose first name is alphabetically before their last name');

    var studentsFromBulgaria = _.filter(students, function(student) {
        return student.country === 'Bulgaria';
    });
    visualiseStudents(studentsFromBulgaria, 'Get only the names of all students from Bulgaria ');

    var last5Students = _.takeRight(students, 5);
    visualiseStudents(last5Students, 'Get the last five students');

    var first3MaleStudentsFromBulgaria = _.chain(students)
        .reject({ country: "Bulgaria" })
        .filter({ gender: "Male" })
        .take(3)
        .value();
    visualiseStudents(first3MaleStudentsFromBulgaria, 'Get the first three students who are not from Bulgaria and are male');
}());