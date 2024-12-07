let number = parseInt(prompt("Please enter a number"));
// let parsedNumber = parseInt(number);

console.log(number);

if (!isNaN(number)) {
    switch (number) {
        case 1:
            console.log(`Monday`);
            break;
        case 2:
            console.log(`Thuseday`);
            break;
        case 3:
            console.log(`Wendsday`);
            break;
        case 4:
            console.log(`Thurseday`);
            break;
        case 5:
            console.log(`Friday`);
            break;
        case 6:
            console.log(`Saturday`);
            break;
        case 7:
            console.log(`Sunday`);
            break;
        default:
            console.log(`Not a day`);
            break;
    }
} else {
    console.log(`Please enter a valid number`);
}

switch (number) {
    case 1:
    case 2:
    case 3:
    case 4:
    case 5:
        console.log(`Work day`);
        break;
    case 6:
    case 7:
        console.log(`Weekend`);
        break;
    default:
        console.log(`Not a work day or weekend`);
        break;
}