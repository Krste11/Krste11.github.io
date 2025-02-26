let btn = document.getElementById(`button`);
let url = `https://raw.githubusercontent.com/qa-codecademy/mkwd13-04-ajs/refs/heads/main/shared_data/students.json`;
let displayContainer = document.getElementById(`displayList`);
let displayContainerHeader = document.getElementById(`displayContainerHeader`);

btn.addEventListener(`click`, function () {
    fetchDisplay();
})

function fetchDisplay() {
    fetch(url)
        .then(function (res) {
            return res.json();
        })
        .then(function (data) {
            displayHeader(data);
            displayList(data.students);
        })
}

function displayList(studenstsArr) {
    for (let i = 0; i < studenstsArr.length; i++) {
        displayContainer.innerHTML += `<li>${studenstsArr[i]}</li>`
    }
}

function displayHeader(data) {
    displayContainerHeader.innerHTML = `
        <h1>${data.trainer}</h1>
        `;
}

