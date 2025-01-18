// ~~~~~~~~~ SELECTORS ~~~~~~~~~
let title = document.getElementById(`title`);
let priority = document.getElementById(`priority`);
let color = document.getElementById(`color`);
let description = document.getElementById(`description`);
let add = document.getElementById(`add`);
let show = document.getElementById(`show`);
let tableBody = document.getElementById(`reminder-table-body`);
let arr = [];

// ~~~~~~~~~ FUNCTIONS ~~~~~~~~~
function Reminder(title, priority, color, description) {
    this.title = title;
    this.priority = priority;
    this.color = color;
    this.description = description;
}

function createRemainder() {
    let titleValue = title.value;
    let priorityValue = priority.value;
    let colorValue = color.value;
    let descriptionValue = description.value;

    let reminder = new Reminder(titleValue, priorityValue, colorValue, descriptionValue);
    arr.push(reminder);

    title.value = ``;
    priority.value = ``;
    color.value = ``;
    description.value = ``;
}

function createTable(array) {
    tableBody.innerHTML = ``;

    for (let i = 0; i < array.length; i++) {
        let reminder = array[i];
        let row = document.createElement(`tr`);

        row.innerHTML = `
            <td style="color: ${reminder.color}">${reminder.title}</td>
            <td style="color: ${reminder.color}">${reminder.priority}</td>
            <td style="color: ${reminder.color}">${reminder.description}</td>
        `;

        tableBody.appendChild(row);
    }
}

// ~~~~~~~~~ EVENTS ~~~~~~~~~
add.addEventListener(`click`, function () {
    createRemainder();
})

show.addEventListener(`click`, function () {
    createTable(arr);
})