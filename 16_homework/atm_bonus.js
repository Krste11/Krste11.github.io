let moneyBalance = 1000;

function atm() {
    let takePut = prompt(`Do you want to take or put money`).toLowerCase();

    if (takePut === `take`) {
        atmTake();
    } else if (takePut === `put`) {
        atmPut();
    } else {
        console.log(`Please enter take or put`);
    }
}

function atmTake() {
    let moneyToTake = parseFloat(prompt(`How much money do you want to take`));

    if (isNaN(moneyToTake)) {
        console.log(`Please enter a number`);
    } else if (moneyToTake <= 0) {
        console.log(`Please enter a positive number`);
    } else if (moneyToTake > moneyBalance) {
        console.log(`You do not have that amount of money`);
        console.log(`You only have ${moneyBalance}`);
    } else {
        moneyBalance = moneyBalance - moneyToTake;
        console.log(`You take $${moneyToTake}`);
        console.log(`Now you have $${moneyBalance}`);
    }
}

function atmPut() {
    let moneyToPut = parseFloat(prompt(`How much money do you want to put`));

    if (isNaN(moneyToPut)) {
        console.log(`Please enter a number`);
    } else if (moneyToPut <= 0) {
        console.log(`Please enter a positive number`);
    } else {
        moneyBalance = moneyBalance + moneyToPut;
        console.log(`You put $${moneyToPut}`);
        console.log(`Now you have $${moneyBalance}`);
    }
}

atm();