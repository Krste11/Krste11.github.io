console.log("================= LOGICAL OPERATORS =============");

console.log(30 > 50); // false 
console.log(30 < 50); // true

console.log("================= LOGICAL and && =============");
console.log(true && true);
console.log(true && false);

let num1 = 50;
let num2 = 100;

console.log(num1 < num2 && num2 === 150); // true && false => flase

console.log(num1 < num2 && num2 + 50 === 150); // true

let expression = num1 < num2 && num2 <= 100 && num1 + 10 !== 60; // true && true && flase => false
console.log(expression);

console.log("================= LOGICAL or || =============");

console.log(true || false); // ture
console.log(false || true); // ture

console.log(false || false); // flase 

let number1 = 3;
let number2 = 13;

console.log(number1 > number2 || number2 >= 10); // true

console.log(5 > 0 && (5 + 6 < 10) || 10 > 5);
// breakdown 
// 5 > 0 true
// 11 < 10 flase
// 10 > 5 true
// true && flase || true
// false || true => true 

console.log("================= LOGICAL not ! =============");
console.log(!true); // false 
console.log(!false); // true

let is_Valid = false;
console.log(is_Valid);
console.log(!is_Valid);

let num_one = 100;
let num_two = 1000;

console.log(!(num_one > num_two) && "Bob" == "Bob"); // true
// !(100 > 1000) => !(false) => true
// Bob == Bob => true
// true && true => true

console.log("================= EQUALITIES =============");

console.log(3 == "3"); // true
console.log(3 === "3"); // false

console.log("================= TRUTHY / FALSY VALUES =============");

let nummber_one = -1000;
let nummber_two = 0;

console.log(Boolean(nummber_one)); // true
console.log(Boolean(nummber_two)); // flase 

console.log(Boolean("")); // flase
console.log(Boolean(" ")); // ture

console.log(Boolean(null)); // false
console.log(Boolean(!null)); // true
