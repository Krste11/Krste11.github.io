let btn = document.getElementById(`button`);
let displayContainerHeader = document.getElementById(`displayContainerHeader`);
let displayTable = document.getElementById(`displayTable`);
let url = `https://swapi.dev/api/people/1`;

btn.addEventListener(`click`, function () {
    fetch(url)
        .then(function (res) {
            return res.json();
        })
        .then(function (data) {
            displayHeader(data);
            displayTableData(data);
        });
});

function displayTableData(dataBase) {
    displayTable.innerHTML = 
    `
        <tr>
            <td>Height</td>
            <td>Weight</td>
            <td>Eye color</td>
            <td>Hair color</td>
        </tr>
        <tr>
            <td>${dataBase.height}cm</td>
            <td>${dataBase.mass}kg</td>
            <td>${dataBase.eye_color}</td>
            <td>${dataBase.hair_color}</td>
        </tr>
    `;
}

function displayHeader(dataBase) {
    displayContainerHeader.innerHTML = `
                <h1>${dataBase.name}</h1>
            `;
}