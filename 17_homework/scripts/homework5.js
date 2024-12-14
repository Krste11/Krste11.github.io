function checkAreAllNumber(num) {
    if (typeof (num) === `string`) {
        alert(`Please enter numbers`);
        return true;
    }
    else if (typeof (num) === `boolean`) {
        alert(`Please enter numbers`);
        return true;
    }
}

function maxOfArr(arr) {
    let max = arr[0];
    for (let i = 1; i < arr.length; i++) {
        if (checkAreAllNumber(arr[i])) {
            return;
        }
        if (max < arr[i]) {
            max = arr[i];
        }
    }
    console.log(max);
}

function minOfArr(arr) {
    let min = arr[0];
    for (let i = 1; i < arr.length; i++) {
        if (checkAreAllNumber(arr[i])) {
            return;
        }
        if (min > arr[i]) {
            min = arr[i];
        }
    }
    console.log(min);
}

function sumOfArr(arr) {
    let sum = 0;
    for (let i = 0; i < arr.length; i++) {
        if (checkAreAllNumber(arr[i])) {
            return;
        }
        sum += arr[i];
    }
    console.log(sum);
}


let arr = [`String`, true, 5, 6, 8, 11];

maxOfArr(arr);
minOfArr(arr);
sumOfArr(arr);