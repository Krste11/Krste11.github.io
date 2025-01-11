let firstNum = null;
let secondNum = null;
let step = 0;
let operation = null;
let result = 0;

let numArray = [];
let secondNumArr = [];

let display = document.getElementById(`display`);

let numberButtons = document.getElementsByClassName(`number`);
for (let i = 0; i < numberButtons.length; i++) {
    numberButtons[i].addEventListener(`click`, function () {
        const num = parseInt(this.getAttribute(`data-value`));
        getNumber(num);
    });
}

let operatorButtons = document.getElementsByClassName(`operator`);
for (let i = 0; i < operatorButtons.length; i++) {
    operatorButtons[i].addEventListener(`click`, function () {
        const operator = this.getAttribute(`data-value`);
        getOperator(operator);
    });
}

document.getElementById(`clear`).addEventListener(`click`, clearDisplay);

document.getElementById(`equals`).addEventListener(`click`, calculateResult);

function getNumber(num) {
    if (step === 0 || step === 1) {
        numArray.push(num);
        step = 1;
        firstNum = Number(numArray.join(``));
        display.value = firstNum;
    } else if (step === 2) {
        if (secondNumArr.length === 0) {
            display.value = ``;
        }
        secondNumArr.push(num);
        secondNum = Number(secondNumArr.join(``));
        display.value = secondNum;
    }
}

function getOperator(operator) {
    if (step === 1) {
        step = 2;
        operation = operator;
        secondNumArr = [];
    } else if (step === 2 && secondNum !== null) {
        calculateResult();
        operation = operator;
        firstNum = result;
        numArray = [result];
        secondNumArr = [];
    }
}

function calculateResult() {
    if (operation && firstNum !== null && secondNum !== null) {
        switch (operation) {
            case `+`:
                result = firstNum + secondNum;
                break;
            case `-`:
                result = firstNum - secondNum;
                break;
            case `*`:
                result = firstNum * secondNum;
                break;
            case `/`:
                if (secondNum === 0) {
                    display.value = `Error`;
                    resetCalculator();
                    return;
                }
                result = firstNum / secondNum;
                break;
        }
        display.value = result;
        resetAfterCalculation();
    }
}

function clearDisplay() {
    display.value = ``;
    resetCalculator();
}

function resetCalculator() {
    firstNum = null;
    secondNum = null;
    step = 0;
    operation = null;
    result = 0;
    numArray = [];
    secondNumArr = [];
}

function resetAfterCalculation() {
    firstNum = result;
    secondNum = null;
    step = 1;
    numArray = [result];
    secondNumArr = [];
}
