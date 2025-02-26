let test = [true, false, 12, 13, 44, 2345, "Bob", "Jill", false, undefined, 1000, null, "Jack", "", "", 99, "Greg", undefined, NaN, 1, 22];

function onlyStrings(arr) {
    for (let i = 0; i < arr.length; i++) {
        if (typeof (arr[i]) === `string`) {
            console.log(arr[i]);
        }
    }
}

function onlyNumber(arr) {
    for (let i = 0; i < arr.length; i++) {
        if (typeof (arr[i]) === `number`) {
            console.log(arr[i]);
        }
    }
}

function cleanArrFalsy(arr) {
    let emptyArr = [];
    for (let i = 0; i < arr.length; i++) {
        if (arr[i]) {
            emptyArr.push(arr[i]);
        }
    }
    console.log(emptyArr);
}

console.log(`~~~~~~~~~~ Strings ~~~~~~~~~`);
onlyStrings(test);
console.log(`~~~~~~~~~~ Numbers ~~~~~~~~~`);
onlyNumber(test);
console.log(`~~~~~~~~~~ Falsy ~~~~~~~~~`);
cleanArrFalsy(test)