function findYoungestPerson(persons) {
    var youngestPersonName;
    var youngestPersonAge;

    for(person in persons) {
        if(youngestPersonAge == undefined) {
            youngestPersonName = persons[person].firstname + ' ' + persons[person].lastname;
            youngestPersonAge = persons[person].age;
        }
        else {
            if(youngestPersonAge > persons[person].age) {
                youngestPersonName = persons[person].firstname + ' ' + persons[person].lastname;
                youngestPersonAge = persons[person].age;
            }
        }
    }

    return 'The youngest person is ' + youngestPersonName;
}

var persons = [
    { firstname : 'George', lastname: 'Kolev', age: 32},
    { firstname : 'Bay', lastname: 'Ivan', age: 81},
    { firstname : 'Baba', lastname: 'Ginka', age: 40}]

console.log(findYoungestPerson(persons));