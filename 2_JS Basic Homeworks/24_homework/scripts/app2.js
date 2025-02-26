let firstName = document.getElementById(`firstName`);
let lastName = document.getElementById(`lastName`);
let phoneNumber = document.getElementById(`phoneNumber`);
let submit = document.getElementById(`submit`);
let tbody = document.getElementById(`tbody`);
let phoneBookArr = [];

function PhoneBook(firstName, lastName, phoneNumber) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.phoneNumber = phoneNumber;
}

function addNewContact() {
    let firstNameValue = firstName.value;
    let lastNameValue = lastName.value;
    let phoneNumberValue = phoneNumber.value;

    if (!check(firstNameValue, lastNameValue, phoneNumberValue)) {
        return;
    }

    let phoneBook = new PhoneBook(firstNameValue, lastNameValue, phoneNumberValue);
    phoneBookArr.push(phoneBook);
    addRows(phoneBook);

    firstName.value = ``;
    lastName.value = ``;
    phoneNumber.value = ``;
}

function check(firstName, lastName, phoneNumber) {
    if (!firstName) {
        alert(`Please enter a first name`);
        return false;
    }

    if (!lastName) {
        alert(`Please enter a last name`);
        return false;
    }

    if (!phoneNumber) {
        alert(`Please enter a phone number`);
        return false;
    }

    if (isNaN(phoneNumber)) {
        alert(`Please enter a valid phone number`);
        return false;
    }

    return true;
}

function addRows(phoneBookValues) {
    let row = document.createElement(`tr`);

    row.innerHTML = `
        <td>${phoneBookValues.firstName}</td>
        <td>${phoneBookValues.lastName}</td>
        <td>${phoneBookValues.phoneNumber}</td>
        <td>
            <button class="edit-btn">Edit</button>
            <button class="delete-btn">Delete</button>
        </td>
    `;

    let editBtn = row.querySelector(`.edit-btn`);
    let deleteBtn = row.querySelector(`.delete-btn`);

    editBtn.addEventListener(`click`, function () {
        editContact(row, phoneBookValues);
    });

    deleteBtn.addEventListener(`click`, function () {
        deleteContact(row, phoneBookValues);
    });

    tbody.appendChild(row);
}

function editContact(row, phoneBookValues) {
    firstName.value = phoneBookValues.firstName;
    lastName.value = phoneBookValues.lastName;
    phoneNumber.value = phoneBookValues.phoneNumber;

    deleteContact(row, phoneBookValues);
}

function deleteContact(row, phoneBookValues) {
    let index = -1;
    for (let i = 0; i < phoneBookArr.length; i++) {
        if (phoneBookArr[i] === phoneBookValues) {
            index = i;
            break;
        }
    }

    if (index !== -1) {
        for (let i = index; i < phoneBookArr.length - 1; i++) {
            phoneBookArr[i] = phoneBookArr[i + 1];
        }
        phoneBookArr.length = phoneBookArr.length - 1;
    }

    row.remove();
}

submit.addEventListener(`click`, function () {
    addNewContact();
});
