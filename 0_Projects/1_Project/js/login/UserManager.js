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
            this.showCustomAlert(`All fields are required!`);
            return false;
        }
        if (!this.validateEmail(email)) {
            this.showCustomAlert(`Invalid email format!`);
            return false;
        }
        if (!this.validatePassword(password)) {
            this.showCustomAlert(`Password must be at least 6 characters long!`);
            return false;
        }
        if (!this.validateAge(age)) {
            this.showCustomAlert(`Age must be between 13 and 120!`);
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
            this.showCustomAlert(`An account with this email already exists.`);
            return;
        }

        let id = this.userIdCounter++;
        let newUser = new User(id, userData.firstName, userData.lastName, userData.email, userData.password, userData.age, userData.country, userData.city);
        this.informationArr.push(newUser);
        this.saveToLocalStorage();

        this.showCustomAlert(`Account created successfully! You can now log in.`);
        document.getElementById(`formCreateAccount`).reset();
        document.getElementById(`close`).click();
    }

    loginUser() {
        const emailInput = document.getElementById(`loginEmail`).value.trim();
        const passwordInput = document.getElementById(`loginPassword`).value;

        if (!this.validateEmail(emailInput) || !passwordInput) {
            this.showCustomAlert(`Invalid email or password!`);
            return;
        }

        let foundUser = this.informationArr.find(user => user.email === emailInput && user.password === passwordInput);

        if (foundUser) {
            this.loggedInUser = foundUser;
            this.saveToLocalStorage();
            setTimeout(() => {
                this.showCustomAlert(`Hello, ${foundUser.firstName}, welcome back!`);
            }, 3000);
            document.getElementById(`closeLogin`).click();
        } else {
            this.showCustomAlert(`Invalid email or password. Please try again.`);
        }
    }

    displayWelcomeMessage() {
        const welcomeMessageElement = document.getElementById(`welcomeMessage`);
        if (this.loggedInUser) {
            setTimeout(() => {
                this.showCustomAlert(`Hello, ${this.loggedInUser.firstName}, welcome back!`);
            }, 10);
        } else {
            welcomeMessageElement.innerText = ``;
        }
    }

    initEventListeners() {
        document.getElementById(`submit`).addEventListener(`click`, this.createNewUser.bind(this));
        document.getElementById(`submitLogin`).addEventListener(`click`, this.loginUser.bind(this));
    }

    showCustomAlert(message) {
        // Create overlay
        const overlay = document.createElement('div');
        overlay.classList.add('custom-alert-overlay');

        // Create alert box
        const alertBox = document.createElement('div');
        alertBox.classList.add('custom-alert-box');

        // Add message
        const msgElem = document.createElement('h2');
        msgElem.textContent = message;
        alertBox.appendChild(msgElem);

        // Add OK button
        const okButton = document.createElement('button');
        okButton.textContent = 'OK';
        alertBox.appendChild(okButton);

        // Append alert box to overlay
        overlay.appendChild(alertBox);
        document.body.appendChild(overlay);

        // Remove on click
        okButton.addEventListener('click', () => {
            document.body.removeChild(overlay);
        });
    }
}
