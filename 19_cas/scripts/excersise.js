let money = prompt("How much money do you spend?")

let moneyNumber = parseInt(money);

console.log(`You spand ${moneyNumber}`);

if (money > 1000) {
    console.log(`You spant a lot of money`);
} else if (money > 500) {
    console.log(`You spent like a average`);
} else {
    console.log(`You do not spent so much money`);
}