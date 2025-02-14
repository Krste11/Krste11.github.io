class Academy {
    constructor(name, students = [], subjects = [], start, end) {
        this.name = name;
        this.students = students;
        this.subjects = subjects;
        this.start = start;
        this.end = end;
    }

    numberOfClasses() {
        console.log(this.subjects.length * 10);
    }

    printStudents() {
        this.students.forEach(student => console.log(student.firstName, student.lastName));
    }

    printSubjects() {
        this.subjects.forEach(subject => console.log(subject.title));
    }

    addSubject(subject) {
        subject.academy = this;
        this.subjects.push(subject);
    }
}

class Subject {
    constructor(title, isElective) {
        this.title = title;
        this.numberOfClasses = 10;
        this.isElective = isElective;
        this.academy = null;
        this.students = [];
    }

    overrideClasses(num) {
        if (num >= 3) {
            this.numberOfClasses = num;
        } else {
            console.log(`Classes can not be lower than 3`);
        }
    }
}

class Student {
    constructor(firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.completedSubjects = [];
        this.academy = null;
        this.currentSubject = null;
    }

    startAcademy(academy) {
        if (academy && academy.name && academy.students && academy.subjects) {
            this.academy = academy;
            if (!academy.students.includes(this)) {
                academy.students.push(this);
            }
        } else {
            console.log(`Invalid academy.`);
        }
    }

    startSubject(subject) {
        if (!this.academy) {
            console.log(`The student is not in an academy.`);
            return;
        }

        if (!this.academy.subjects.includes(subject)) {
            console.log(`The subject is not in an academy.`);
            return;
        }

        if (this.currentSubject) {
            this.completedSubjects.push(this.currentSubject);
        }

        this.currentSubject = subject;
        if (!subject.students.includes(this)) {
            subject.students.push(this);
        }
    }
}

const codeAcademy = new Academy(`Code`, [], [], `17/10/2024`, `17/10/2025`);
const cSharp = new Subject(`C#`, false);
const angel = new Student(`Angel`, `Krstevski`, 17);

codeAcademy.addSubject(cSharp);
angel.startAcademy(codeAcademy);
angel.startSubject(cSharp);

console.log(codeAcademy);
console.log(cSharp);
console.log(angel);
