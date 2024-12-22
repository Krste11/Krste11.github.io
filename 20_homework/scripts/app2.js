function phoneBook(numberOfContacts) {
    let fName;
    let lName;
    let number;

    for (let i = 0; i < numberOfContacts; i++) {
        fName = prompt(`Contact ${i + 1} first name is`);
        lName = prompt(`Contact ${i + 1} last name is`);
        number = prompt(`Contact ${i + 1} number is`);

        alert(`Contact ${i + 1} was added`)

        console.log(`Contact ${i + 1}: ${fName} ${lName} ${number}`);
    }
}

let numberOfContactsInput = parseInt(prompt(`How meny contact do you want to enter`));

phoneBook(numberOfContactsInput);