let color = document.getElementById(`color`);
let fontSize = document.getElementById(`fontSize`);
let items = document.getElementById(`items`);
let button = document.getElementById(`button`);
let listContainer = document.getElementById(`listContainer`);

function createList() {
    let colorValue = color.value;
    let fontSizeValue = fontSize.value;
    let textValue = items.value;

    let arr = textValue.split(`,`);

    listContainer.innerHTML = ``;

    let ul = document.createElement(`ul`);
    for (let i = 0; i < arr.length; i++) {
        let li = document.createElement(`li`);
        li.textContent = arr[i];
        li.style.color = colorValue;
        li.style.fontSize = fontSizeValue + `px`;
        ul.appendChild(li);
    }

    listContainer.appendChild(ul);

    color.value = ``;
    fontSize.value = ``;
    items.value = ``;
}

button.addEventListener(`click`, function() {
    createList();
});
