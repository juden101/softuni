function Person(firstName, lastName, age) {
    this.firstName = firstName || "";
    this.lastName = lastName || "";
    this.age = age || 0;
}

function group(persons) {
    var groupBy = arguments[1];
    if (!groupBy) {
        return persons;
    }

    var group = {};
    for (var i = 0, len = persons.length; i < len; i++) {
        var person = persons[i];
        var groupName = "Group ";

        switch (groupBy) {
            case "firstname":
                groupName += person.firstName;
                break;
            case "lastname":
                groupName += person.lastName;
                break;
            case "age":
                groupName += person.age
                break;
        }

        if (!group[groupName]) {
            group[groupName] = [];
        }

        group[groupName].push(
            person.firstName + ' ' + person.lastName + '(age ' + person.age + ')'
        );
    }

    return group;
}

var people = [];
people.push(new Person("Scott", "Guthrie", 38));
people.push(new Person("Scott", "Johns", 36));
people.push(new Person("Scott", "Hanselman", 39));
people.push(new Person("Jesse", "Liberty", 57));
people.push(new Person("Jon", "Skeet", 38));

console.log(group(people, 'firstname'));
console.log();
console.log(group(people, 'age'));
console.log();
console.log(group(people, 'lastname'));