// ~~~~~~~~~~~~~~~ SELECTORS ~~~~~~~~~~~~~~~
const btn = document.querySelector(`#btn`);
const tableValues = document.querySelector(`#tableValues`);
const API_URL = `https://swapi.py4e.com/api/planets/?page=1`;



// ~~~~~~~~~~~~~~~ FUNCTIONS ~~~~~~~~~~~~~~~
const fetchFunction = (url) => {
    fetch(url)
        .then((res) => res.json())
        .then((data) => createTable(data))
        .catch((err) => console.error(err));
};

const createTable = (dataBase) => {
    const planets = dataBase.results;
    tableValues.innerHTML = ``;

    for (let i = 0; i < planets.length; i++) {
        const row = document.createElement(`tr`);

        const nameCell = document.createElement(`td`);
        const populationCell = document.createElement(`td`);
        const climateCell = document.createElement(`td`);
        const gravityCell = document.createElement(`td`);

        nameCell.textContent = planets[i].name;
        populationCell.textContent = planets[i].population;
        climateCell.textContent = planets[i].climate;
        gravityCell.textContent = planets[i].gravity;

        row.appendChild(nameCell);
        row.appendChild(populationCell);
        row.appendChild(climateCell);
        row.appendChild(gravityCell);

        tableValues.appendChild(row);
    }
};

// ~~~~~~~~~~~~~~~ EVENTS ~~~~~~~~~~~~~~~
btn.addEventListener(`click`, () => {
    fetchFunction(API_URL);
});