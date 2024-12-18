function removeFalsyValues(arr) {
    let newArr = [];
    for (let i = 0; i < arr.length; i++) {
        if (arr[i]) {
            newArr.push(arr[i]);
        }
    }

    for(let i = 0; i < newArr.length; i++){
        console.log(newArr[i]);
    }
}

let arrInput = [null, undefined, NaN, ``, `string`, false, true, 23, 34.5, `random string`];
removeFalsyValues(arrInput);