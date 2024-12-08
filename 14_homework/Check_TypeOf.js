function typeOfCheck(parameter) {
    let type = typeof(parameter);
    console.log(`The type is ${type}`);
    return type;
}

typeOfCheck(`Hello`);
typeOfCheck(11);
typeOfCheck(true);
typeOfCheck(undefined);
typeOfCheck(Object);