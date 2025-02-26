function Academy(academyName, numberOfGroups, numberOfClassrooms) {
    this.academyName = academyName;
    this.numberOfGroups = numberOfGroups;
    this.numberOfClassrooms = numberOfClassrooms;

    this.getAcademyName = function() {
        console.log(`Academy ${this.academyName}`);
    }
}

function Student(firstName, lastName, age, eMail, academy, group) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
    this.eMail = eMail;
    this.academy = academy;
    this.group = group;

    this.getAcademyNameStudent = function() {
        console.log(`Student is enroled on academy for ${this.academy}`);
    }
}

function Group(name, numberOfStudents, students) {
    this.name = name;
    this.numberOfStudents = numberOfStudents;
    this.students = students;

    this.getNumberOfStudents = function() {
        console.log(`In group ${this.name} there are ${this.numberOfStudents}`);
    }
}


let academy = new Academy(`Qinshift`, 6, 3);
let student = new Student(`Angel`, `Krstevski`, 17, `angelkrstevski66@gmail.com`, `programming`, `G2`);
let group = new Group(`G2`, 24, [`Angel`, ` `, ` `, ` `]);

academy.getAcademyName();
student.getAcademyNameStudent();
group.getNumberOfStudents();