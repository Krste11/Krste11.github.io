let firstName = document.getElementById('firstName');
let lastName = document.getElementById('lastName');
let email = document.getElementById('emailL');
let password = document.getElementById('passwordD');
let age = document.getElementById('age');
let country = document.getElementById('country');
let city = document.getElementById('city');
let submit = document.getElementById('submit');
let informationArr = JSON.parse(localStorage.getItem('informationArr')) || [];
let userIdCounter = JSON.parse(localStorage.getItem('userIdCounter')) || 1;
let editMode = false;
let editId = null;

function InformationObject(id, firstName, lastName, email, password, age, country, city) {
    this.id = id;
    this.firstName = firstName;
    this.lastName = lastName;
    this.email = email;
    this.password = password;
    this.age = age;
    this.country = country;
    this.city = city;
}

function saveToLocalStorage() {
    localStorage.setItem('informationArr', JSON.stringify(informationArr));
    localStorage.setItem('userIdCounter', JSON.stringify(userIdCounter));
}

function createNewUser() {
    if (editMode) {
        updateUser(editId);
    } else {
        let id = userIdCounter++;
        let informationObject = new InformationObject(id, firstName.value, lastName.value, email.value, password.value, age.value, country.value, city.value);
        informationArr.push(informationObject);
        saveToLocalStorage();
        addRows(informationObject);
        resetForm();
    }
}

function updateUser(id) {
    let user = informationArr.find(user => user.id === id);
    user.firstName = firstName.value;
    user.lastName = lastName.value;
    user.email = email.value;
    user.password = password.value;
    user.age = age.value;
    user.country = country.value;
    user.city = city.value;

    saveToLocalStorage();

    let rows = document.querySelectorAll('tbody tr');
    rows.forEach(row => {
        if (parseInt(row.children[0].textContent) === id) {
            row.children[1].textContent = user.firstName;
            row.children[2].textContent = user.lastName;
            row.children[3].textContent = user.email;
            row.children[4].textContent = user.password;
            row.children[5].textContent = user.age;
            row.children[6].textContent = user.country;
            row.children[7].textContent = user.city;
        }
    });

    editMode = false;
    editId = null;
    resetForm();
}

function resetForm() {
    firstName.value = '';
    lastName.value = '';
    email.value = '';
    password.value = '';
    age.value = '';
    country.value = '';
    city.value = '';
}

function addRows(user) {
    let row = document.createElement('tr');

    row.innerHTML = `
        <td>${user.id}</td>
        <td>${user.firstName}</td>
        <td>${user.lastName}</td>
        <td>${user.email}</td>
        <td>${user.password}</td>
        <td>${user.age}</td>
        <td>${user.country}</td>
        <td>${user.city}</td>
        <td>
            <button class="edit-btn btn btn-warning btn-sm">Edit</button>
            <button class="delete-btn btn btn-danger btn-sm">Delete</button>
        </td>
    `;

    let tbody = document.getElementById('tbody');
    tbody.appendChild(row);

    row.querySelector('.delete-btn').addEventListener('click', function () {
        tbody.removeChild(row);
        informationArr = informationArr.filter(info => info.id !== user.id);
        saveToLocalStorage();
    });

    row.querySelector('.edit-btn').addEventListener('click', function () {
        editMode = true;
        editId = user.id;
        firstName.value = user.firstName;
        lastName.value = user.lastName;
        email.value = user.email;
        password.value = user.password;
        age.value = user.age;
        country.value = user.country;
        city.value = user.city;

        let modal = new bootstrap.Modal(document.getElementById('formModalCreateAcc'));
        modal.show();
    });
}

submit.addEventListener('click', function () {
    createNewUser();
});

// Populate table on page load
window.addEventListener('load', function () {
    informationArr.forEach(user => addRows(user));
});
