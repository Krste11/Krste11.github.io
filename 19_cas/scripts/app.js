console.log("============== STRINGS ==============");

let first_name;
first_name = "Bob";

let last_name = "Bobsky";

// ===> using double quotes
let double_qotes = "This is a string with doubele quotes";

// ===> using single quotes
let single_qotes = "This is a string with single quotes";

// ===> using backticks
let backtick_string = `This is a string with backticks(template literals)`;

console.log("============== Combining strings ==============");

// ===> using '+'
let full_name = "First name: " + first_name;
console.log(full_name);

console.log("Last name: " + last_name);

console.log(first_name + " is " + 30 + " years");
console.log(2 + 2);
console.log(2 + "2");

full_name = `First name ${first_name} and the last name is ${last_name}`;
console.log(full_name);

console.log("============== Quotes within strings ==============");
// let sentence = 'This isn't possible';
let sentence1 = "This isn't hard";
let sentence2 = 'He repalid: "Hey there"';
let sentence3 = 'This isn\'t possible';
let sentence4 = '\'TO BE\' or \'NOT TO BE\'';

let sentence5 = `"${sentence4}, the qustion is now"`;
console.log(sentence5);

console.log("============== NON VALUE VALUES ==============");

// undifind
let undifined;
console.log(undifined);

// null

let empty_variable = null;
console.log(empty_variable);


console.log("============== SPECIAL NUMBER ==============");

console.log("==== NaN ==="); // Not a number 

console.log(typeof NaN);
let result = 100 / "deset";
console.log(result);

console.log(isNaN(result)); // true
console.log(isNaN("tekst")); // true
console.log(Number.isNaN("tekst")); // false


console.log("============== Infinity ==============");

let infinity = Infinity;
console.log(typeof infinity);

console.log(1 / 0);
console.log(-1 / 0);