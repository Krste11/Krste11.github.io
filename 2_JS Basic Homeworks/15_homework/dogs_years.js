function humanToDogsYears(humansYears) {
    let dogsYears = humansYears * 7;
    return dogsYears;
}

function dogsToHumanYears(dogsYears) {
    let humanYears = dogsYears / 7;
    return humanYears;
}

let enterHumanYears = parseInt(prompt(`Enter your years `));
let dogsYearsResult = humanToDogsYears(enterHumanYears);
console.log(dogsYearsResult);

let enterDogsYears = parseInt(prompt(`Enter your dogs years `));
let humanYearsResult = dogsToHumanYears(enterDogsYears);
console.log(humanYearsResult);
