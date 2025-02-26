function maxOfArr(arr) {
    let max = arr[0];
    for (let i = 0; i < arr.length; i++) {
        if(checkAreAllNumber(arr[i]) === true){
            arr[i].shift();
        }
        if (max < arr[i]) {
            max = arr[i];
        }
    }
    return max;
}

function minOfArr(arr) {
    let max = arr[0];
    for (let i = 0; i < arr.length; i++) {
        if(checkAreAllNumber(arr[i]) === true){
            arr[i].shift();
        }
        if (max > arr[i]) {
            max = arr[i];
        }
    }
    return max;
}

function sumOfMinAndMax() {
    let sum = 0;
    sum = maxOfArr(arr) + minOfArr(arr);
    console.log(sum);
}

function checkAreAllNumber(num) {
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

let arr = [`string`, 5, 6, 8, 11];

sumOfMinAndMax();