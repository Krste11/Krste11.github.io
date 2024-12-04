let total_sum;
let phones = 30;
let phone = 119.95;
let phone_tax;
let tax;

tax = phone / 100 * 5;

phone_tax = phone + tax;

console.log("This a sum with tax for one phone " + phone_tax + "$");

total_sum = phone_tax * phones;

console.log("The sum for all phones is " + total_sum + "$");