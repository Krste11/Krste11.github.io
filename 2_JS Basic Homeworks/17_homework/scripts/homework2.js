function validateNumber(num) {
    if (isNaN(num)) {
        alert(`All elemnts in array must be numbers`);
        return true;
    }
    else if (typeof (num) === `string`) {
        alert(`All elemnts in array must be numbers`);
        return true;
    }
    else if (typeof (num) === `boolean`) {
        alert(`All elemnts in array must be numbers`);
        return true;
    }
}

function sumOfNumbers(numbers) {
    let sum = 0;
    for (let i = 0; i < 5; i++) {
        numbers[i] = parseFloat(prompt(`Enter number ${i + 1}`));
        if (validateNumber(numbers[i])) {
            return;
        }
        sum += numbers[i];
    }
    console.log(`The sum of numbers is ${sum}`);
}

let numbers = [];

sumOfNumbers(numbers);