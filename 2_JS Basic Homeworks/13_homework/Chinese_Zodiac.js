let birthDay = prompt(`Enter your birthday: `);
let birthDayPirsed = parseInt(birthDay);

formulaDay = (birthDayPirsed - 4) % 12;

switch (formulaDay) {
    case 1:
        console.log(`Rat`);
        break;
    case 2:
        console.log(`Ox`);
        break;
    case 3:
        console.log(`Rabbit`);
        break;
    case 4:
        console.log(`Dragon`);
        break;
    case 5:
        console.log(`Snake`);
        break;
    case 6:
        console.log(`Horse`);
        break;
    case 7:
        console.log(`Goat`);
        break;
    case 8:
        console.log(`Moneky`);
        break;
    case 9:
        console.log(`Rooster`);
        break;
    case 10:
        console.log(`Dog`);
        break;
    case 11:
        console.log(`Pig`);
        break;
    default:
        console.log(`Not a year`);
        break;
}