let numbers = [2, 3, 5];

let ulElementOne = document.getElementById(`ulElement`).children[0].innerHTML = numbers[0];
let ulElementTwo = document.getElementById(`ulElement`).children[1].innerHTML = numbers[1];
let ulElementThree = document.getElementById(`ulElement`).children[2].innerHTML = numbers[2];

let sum = ulElementOne + ulElementTwo + ulElementThree;

let sumOfNumbers = document.getElementById(`sumOfNumbers`).innerHTML = sum;

let fullMath = document.getElementById(`fullMath`).innerHTML = `The sum of number is ${ulElementOne} + ${ulElementTwo} + ${ulElementThree} = ${sum} `;