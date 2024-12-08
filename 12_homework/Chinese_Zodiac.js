let birthDay = prompt(`Enter your birthday: `);
let birthDayPirsed = parseInt(birthDay);

formulaDay = (birthDayPirsed - 4) % 12;

if (formulaDay == 0) {
    console.log(`Your sign is Rat`);
} else if (formulaDay == 1) {
    console.log(`Your sign is Ox`);
} else if (formulaDay == 2) {
    console.log(`Your sign is Tiger`);
} else if (formulaDay == 3) {
    console.log(`Your sign is Rabbit`);
} else if (formulaDay == 4) {
    console.log(`Your sign is Dragon`);
} else if (formulaDay == 5) {
    console.log(`Your sign is Snake`);
} else if (formulaDay == 6) {
    console.log(`Your sign is Horse`);
} else if (formulaDay == 7) {
    console.log(`Your sign is Goat`);
} else if (formulaDay == 8) {
    console.log(`Your sign is Monkey`);
} else if (formulaDay == 9) {
    console.log(`Your sign is Rooster`);
} else if (formulaDay == 10) {
    console.log(`Your sign is Dog`);
} else if (formulaDay == 11) {
    console.log(`Your sign is Pig`);
} else {
    console.log(`Is not a year`);
}