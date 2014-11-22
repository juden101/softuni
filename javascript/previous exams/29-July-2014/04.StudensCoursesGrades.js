function solve(input) {
    var courses = {};

    Array.prototype.unique = function() {
        var sorted = this;
        sorted.sort();
        return sorted.filter(function(value, index, arr){
            if(index < 1)
                return true;
            else
                return value != arr[index-1];
        });
    };

    function sortObjectProperties(obj) {
        var keysSorted = Object.keys(obj).sort();
        var sortedObj = {};
        for (var i = 0; i < keysSorted.length; i++) {
            var key = keysSorted[i];
            sortedObj[key] = obj[key];
        }

        return sortedObj;
    };

    for(var i = 0; i < input.length; i++) {
        var result = input[i].split('|');
        var student, course, grade, visits;

        student = result[0].trim();
        course = result[1].trim();
        grade = result[2].trim();
        visits = result[3].trim();

        if(!courses[course]) {
            courses[course] = {
                'students': [],
                'grades': [],
                'visits': []
            };
        }

        courses[course]['students'].push(student);
        courses[course]['grades'].push(grade);
        courses[course]['visits'].push(visits);
    }

    for(var course in courses) {
        var avgGrade = 0, avgVisits = 0;

        for(var i = 0; i < courses[course]['grades'].length; i++) {
            avgGrade += Number(courses[course]['grades'][i]);
        }

        for(var i = 0; i < courses[course]['visits'].length; i++) {
            avgVisits += Number(courses[course]['visits'][i]);
        }

        avgGrade = Number((avgGrade / courses[course]['grades'].length).toFixed(2));
        avgVisits = (avgVisits / courses[course]['visits'].length);

        courses[course]['avgGrade'] = avgGrade;
        courses[course]['avgVisits'] = Number(avgVisits.toFixed(2));

        courses[course]['students'] = courses[course]['students'].unique();

        delete courses[course]['grades'];
        delete courses[course]['visits'];
    }

    courses = sortObjectProperties(courses);
    for (var course in courses) {
        courses[course] = sortObjectProperties(courses[course]);
    }

    console.log(JSON.stringify(courses));
}