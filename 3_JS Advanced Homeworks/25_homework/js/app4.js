let color = document.getElementById(`color`);
let fontSize = document.getElementById(`fontSize`);
let text = document.getElementById(`text`);
let button = document.getElementById(`button`);
let element = document.getElementById(`element`);

function makeElement() {
    let colorValue = color.value;
    let fontSizeValue = fontSize.value;
    let textValue = text.value;

    element.innerHTML = `<h1 style="color:${colorValue}; font-size: ${fontSizeValue};">${textValue}</h1>`

    color.value = ``;
    fontSize.value = ``;
    text.value = ``;
}

button.addEventListener(`click`, function () {
    makeElement();
})