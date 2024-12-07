console.log("=========== CONTROL STRUCTURES ===========");
// Conditional statements
// Switch statement
// Looping structures

// Purpose: Control the flow of a program

console.log("============= CONDITIONAL STATEMENTS =========");

console.log(" ");
console.log("============= IF =========");

// if (bolean statement) {
//      code....
// }

// Example to check wether a given number is positive, negative or zero
let num = -11;

if (num > 0) {
    console.log(`The number ${num} is positive`);
}

console.log(" ");
console.log("============= ELSE =========");

if (num > 0) {
    console.log(`The number ${num} is positive`);
} else {
    console.log(`The number ${num} is not positive`);
}

console.log(" ");
console.log("============= ELSE IF =========");

num = 101;

if (num > 100) {
    console.log(`The number is larger than 100`);
} else if (num > 0) {
    console.log(`The number ${num} is positive`);
} else if (num < 0) {
    console.log(`The number ${num} is not positive`);
} else {
    console.log(`The number ${num} is zero`);
}
if (num < -5) {
    console.log("The num is smaller than -5");
}

if (num > 0) {
    console.log(`The number ${num} is positive`);
}else if (num > 100) {
    console.log(`The number is larger than 100`);

}else if (num < 0) {
    console.log(`The number ${num} is not positive`);
} else {
    console.log(`The number ${num} is zero`);
}
if (num < -5) {
    console.log("The num is smaller than -5");
}

console.log(" ");
console.log("============= GETTING AN INPUT =========");

let input = prompt("Enter a number")
console.log(input);
console.log(typeof(input));

console.log("After parsing the integer");

let parsed_Number = parseInt(input);
console.log(parsed_Number);
console.log(typeof(parsed_Number));

if (Number.isNaN(parsed_Number)) {
    alert("You enter a invalid number");
} else {
    alert(`The past number value is ${parsed_Number}`)
}