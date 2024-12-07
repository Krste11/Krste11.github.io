function sum(num1, num2) {
    return num1 + num2;
}

function diff(num1, num2) {
    return num1 - num2;
}

function multiply(num1, num2) {
    return num1 * num2;
}

function divide(num1, num2) {
    return num1 / num2;
}

let num1 = parseInt(prompt(`Enter first number`));
let num2 = parseInt(prompt(`Enter second number`));

console.log(sum(10,2));
console.log(diff(10,2));
console.log(multiply(10,2));
console.log(divide(10,2));

// write a function that will be caled calculator it should take 2 parameter and parameter
// numbers: num1, num2
// operators + - * /
// depending of the oprator, return the appropriate result 
// calculator(num1, num2, +)