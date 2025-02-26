function passOrNos(borderGrade) {
    let averageGrade = averageOfGrades(studensGradesInput, numberOfGradesInput);
    console.log(`Your average grade is ${averageGrade}`);

    if (averageGrade >= borderGrade) {
        console.log(`You pass the semester`);
    } else if (averageGrade < borderGrade) {
        console.log(`You don't pass the semester`);
    } else {
        console.log(`Error`);
    }
}

function averageOfGrades(studentsGrades, numberOfGrades) {
    let sum = 0;
    for (let i = 0; i < numberOfGrades; i++) {
        let grade = parseInt(prompt(`Enter a grade ${i + 1}`));
        studentsGrades.push(grade);
        sum += grade;
    }
    return sum / numberOfGrades;
}

let borderGradeInput = parseInt(prompt(`Please enter what is the border to pass the semester`));
let numberOfGradesInput = parseInt(prompt(`Please enter how much grades do you want to enter`));
let studensGradesInput = [];

passOrNos(borderGradeInput);