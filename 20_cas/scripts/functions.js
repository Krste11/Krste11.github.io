// ======================================================
// ======== function declaration ========
function sayHello() {
    console.log(`Hello there!`);
}

// ======= Calling a function ========
sayHello();

// ======================================================
function sayGoodBye() {
    console.log(`Goodbay, se you next week!`);
}

sayGoodBye()

// ======================================================
function addTwoNumber() {
    let firstNum = 22;
    let secondNum = 324;
    let result = firstNum + secondNum;
    console.log(`The sum of ${firstNum} and ${secondNum} is ${result}`);
}

addTwoNumber();

// ======================================================
// function sumTwoNumbers() {
//     let firstNum = parseInt(prompt(`Please enter first number `));
//     let secondNum = parseInt(prompt(`Please enter second number `));
//     let result = firstNum + secondNum;
//     console.log(`The sum of two numbers is ${result}`);
// }

// sumTwoNumbers();

// ======================================================
// ======= Functions with input parameters (arguments)

function sayMyFullName(firsName,lastName) {
    document.write(`${firsName} ${lastName}`);
}

sayMyFullName('Angel','Krstevski');
sayMyFullName('Martin','Panovski');

// ======================================================
// function greetPerson() {
//     let name = prompt("Please enter a name");
//     console.log(`Hello ${name}`);
// }

// greetPerson();

// ======================================================
function gretPerson(personName) {
    console.log(`Hello there ${personName}`);
}

gretPerson('Martin');

// ======================================================
// functions that return value 

function retunValue(value) {
    return value;
}

console.log(retunValue("This will be returned"));

function gretPerson1(personName) {
    let greeting = `Hello there ${personName}`;
    return greeting;
}

console.log(gretPerson1('Slave'));

let greetMessage = gretPerson1('Angel');
console.log(greetMessage);