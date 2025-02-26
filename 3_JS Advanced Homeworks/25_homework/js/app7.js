let firstName = document.getElementById(`firstName`);
let lastName = document.getElementById(`lastName`);
let age = document.getElementById(`age`);
let email = document.getElementById(`email`);
let submit = document.getElementById(`submit`);
let dataBase = [];

function Student(firstName, lastName, age, email) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
    this.email = email;
}

function generateStudent() {
    let firstNameValue = firstName.value.trim();
    let lastNameValue = lastName.value.trim();
    let ageValue = age.value.trim();
    let emailValue = email.value.trim();

    if (firstNameValue && lastNameValue && ageValue && emailValue) {
        let student = new Student(firstNameValue, lastNameValue, ageValue, emailValue);
        dataBase.push(student);
        console.log(dataBase);

        firstName.value = ``;
        lastName.value = ``;
        age.value = ``;
        email.value = ``;
    } else {
        alert(`Please fill in all fields.`);
    }
}

submit.addEventListener(`click`, generateStudent);