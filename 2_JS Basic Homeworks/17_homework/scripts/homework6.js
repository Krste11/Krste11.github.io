function fullNames(firstNames, lastNames) {
    for (let i = 0; i < firstNames.length; i++) {
        console.log(`${i + 1}.${firstNames[i]} ${lastNames[i]}`);
    }
}

let firstNames = [`Bob`, `Angel`, `Jill`];
let lastNames = [`Gregory`, `Krstevski`, `Wurtz`];

fullNames(firstNames, lastNames);