function Student(firstName, lastName, birthYear, academy, grades) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.birthYear = birthYear;
    this.academy = academy;
    this.grades = grades;

    this.getAge = function () {
        const currentYear = new Date().getFullYear()
        return currentYear - this.birthYear;
    }

    this.getInfo = function () {
        return `This is ${this.firstName} ${this.lastName} from the ${this.academy} academy`;
    }

    this.getGradeAverage = function () {
        let sum = 0;
        let average;
        for (let i = 0; i < this.grades.length; i++) {
            sum = sum + this.grades[i];
        }
        average = sum / this.grades.length;
        return `${this.firstName} ${this.lastName}'s average grade is ${average}`;
    }
}

const angel = new Student(`Angel`, `Krstevski`, 2007, `Qinshift`, [5, 2, 3, 4, 1]);
const student1 = new Student(`Bob`, `Bobski`, 2000, `Qinshift`, [5, 3, 4, 2]);
const student2 = new Student(`Mob`, `Mobski`, 2005, `Qinshift`, [2, 3, 1, 2]);

console.log(angel);
console.log(angel.getAge());
console.log(angel.getInfo());
console.log(angel.getGradeAverage());