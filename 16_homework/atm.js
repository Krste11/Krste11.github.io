let yourMoney = 1000;

function atm() {
    let moneyToTake = parseFloat(prompt(`Enter how much money want to take `));

    if (isNaN(moneyToTake)) {
        console.log(`Please enter a number`);
    }
    else if (moneyToTake < 0 || moneyToTake === 0 ) {
        console.log(`Invalid number`);
    } 
    else if (moneyToTake > yourMoney) {
        console.log(`You don't have enough money`);
    } 
    else {
        yourMoney = yourMoney - moneyToTake;
        console.log(`You take $${moneyToTake}`);
        console.log(`You have remaining $${yourMoney}`);
    }
}

atm();