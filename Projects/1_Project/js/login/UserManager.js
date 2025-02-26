import { User } from './User.js';

export class UserManager {
    constructor() {
        this.informationArr = JSON.parse(localStorage.getItem(`informationArr`)) || [];
        this.userIdCounter = JSON.parse(localStorage.getItem(`userIdCounter`)) || 1;
        this.loggedInUser = JSON.parse(localStorage.getItem(`loggedInUser`)) || null;
        this.initEventListeners();
        this.displayWelcomeMessage();
    }

    saveToLocalStorage() {
        localStorage.setItem(`informationArr`, JSON.stringify(this.informationArr));
        localStorage.setItem(`userIdCounter`, JSON.stringify(this.userIdCounter));
        localStorage.setItem(`loggedInUser`, JSON.stringify(this.loggedInUser));
    }

    validateEmail(email) {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailRegex.test(email);
    }

    validatePassword(password) {
        return password.length >= 6;
    }

    validateAge(age) {
        return age >= 13 && age <= 120;
    }

    validateForm({ firstName, lastName, email, password, age, country, city }) {
        if (!firstName || !lastName || !email || !password || !age || !country || !city) {
            alert(`All fields are required!`);
            return false;
        }
        if (!this.validateEmail(email)) {
            alert(`Invalid email format!`);
            return false;
        }
        if (!this.validatePassword(password)) {
            alert(`Password must be at least 6 characters long!`);
            return false;
        }
        if (!this.validateAge(age)) {
            alert(`Age must be between 13 and 120!`);
            return false;
        }
        return true;
    }

    createNewUser() {
        const userData = {
            firstName: document.getElementById(`firstName`).value.trim(),
            lastName: document.getElementById(`lastName`).value.trim(),
            email: document.getElementById(`emailL`).value.trim(),
            password: document.getElementById(`passwordD`).value,
            age: parseInt(document.getElementById(`age`).value.trim(), 10),
            country: document.getElementById(`country`).value.trim(),
            city: document.getElementById(`city`).value.trim()
        };

        if (!this.validateForm(userData)) return;

        if (this.informationArr.some(user => user.email === userData.email)) {
            alert(`An account with this email already exists.`);
            return;
        }

        let id = this.userIdCounter++;
        let newUser = new User(id, userData.firstName, userData.lastName, userData.email, userData.password, userData.age, userData.country, userData.city);
        this.informationArr.push(newUser);
        this.saveToLocalStorage();

        alert(`Account created successfully! You can now log in.`);
        document.getElementById(`formCreateAccount`).reset();
        document.getElementById(`close`).click();
    }

    loginUser() {
        const emailInput = document.getElementById(`loginEmail`).value.trim();
        const passwordInput = document.getElementById(`loginPassword`).value;

        if (!this.validateEmail(emailInput) || !passwordInput) {
            alert(`Invalid email or password!`);
            return;
        }

        let foundUser = this.informationArr.find(user => user.email === emailInput && user.password === passwordInput);

        if (foundUser) {
            this.loggedInUser = foundUser;
            this.saveToLocalStorage();
            setTimeout(() => {
                alert(`Hello, ${foundUser.firstName}, welcome back!`);
            }, 3000);
            document.getElementById(`closeLogin`).click();
        } else {
            alert(`Invalid email or password. Please try again.`);
        }
    }

    displayWelcomeMessage() {
        const welcomeMessageElement = document.getElementById(`welcomeMessage`);
        if (this.loggedInUser) {
            setTimeout(() => {
                alert(`Hello, ${this.loggedInUser.firstName}, welcome back!`);
            }, 3000);
        } else {
            welcomeMessageElement.innerText = ``;  // Clear the message if no user is logged in
        }
    }

    initEventListeners() {
        document.getElementById(`submit`).addEventListener(`click`, this.createNewUser.bind(this));
        document.getElementById(`submitLogin`).addEventListener(`click`, this.loginUser.bind(this));
    }
}