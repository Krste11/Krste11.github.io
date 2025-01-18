function arrayWithThree() {
    let arrThree = [];
    for (let i = 0; i <= 1000; i++) {
        if (i % 3 === 0) {
            arrThree.push(i);
        }
    }
    console.log(arrThree);
}

function arrayWithFour() {
    let arrFour = [];
    for (let i = 0; i <= 1000; i++) {
        if (i % 4 === 0) {
            arrFour.push(i);
        }
    }
    console.log(arrFour);
}

function arrayWithOne() {
    let arrOne = [];
    for (let i = 0; i <= 1000; i++) {
        if (i % 10 === 1) {
            arrOne.push(i);
        }
    }
    console.log(arrOne);
}

arrayWithThree();
arrayWithFour();
arrayWithOne();
