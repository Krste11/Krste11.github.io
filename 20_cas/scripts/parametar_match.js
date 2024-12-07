function sayMyNameAndYears(firstName = 'Martin', LastName = 'Panovski', years = 31) {
    console.log(`${firstName} ${LastName} is ${years} old.`);
}

sayMyNameAndYears('Angel', 'Krstevski', 17);
sayMyNameAndYears('Angel', '17', 'Angel');
sayMyNameAndYears('Angel', 'Krstevski', 17, true, 'Hello');
sayMyNameAndYears('Angel', 'Krstevski');

// Built in functions
function myCustomAlert(message) {
    console.log(`Hello there`);
}

myCustomAlert();

let myNum = Number('11');
console.log(myNum);

let myString = String(22);
console.log(myString);
console.log(typeof(myString));


let car = 'Ford Mustang';

function drive(car) {
    console.log(`I am driving ${car}`);
}

drive('Opel Astra');
drive();