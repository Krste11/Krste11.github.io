// ~~~~~~~~~~~~~~~ SELECTORS ~~~~~~~~~~~~~~~
const btn = document.querySelector(`#btn`);
const tableValues = document.querySelector(`#tableValues`);
const nextBtn = document.querySelector(`#nextBtn`);
const prevBtn = document.querySelector(`#prevBtn`);
const API_URL1 = `https://swapi.py4e.com/api/planets/?page=1`;
const API_URL2 = `https://swapi.py4e.com/api/planets/?page=2`;

// ~~~~~~~~~~~~~~~ FUNCTIONS ~~~~~~~~~~~~~~~
const fetchFunction = (url) => {
    fetch(url)
        .then((res) => res.json())
        .then((data) => createTable(data))
        .catch((error) => console.error(error));
};

const createTable = (data) => {
    const planets = data.results;
    tableValues.innerHTML = ``;

    for (let i = 0; i < planets.length; i++) {
        const planet = planets[i];
        const row = document.createElement(`tr`);

        const nameCell = document.createElement(`td`);
        const populationCell = document.createElement(`td`);
        const climateCell = document.createElement(`td`);
        const gravityCell = document.createElement(`td`);

        nameCell.textContent = planet.name;
        populationCell.textContent = planet.population;
        climateCell.textContent = planet.climate;
        gravityCell.textContent = planet.gravity;

        row.appendChild(nameCell);
        row.appendChild(populationCell);
        row.appendChild(climateCell);
        row.appendChild(gravityCell);

        tableValues.appendChild(row);
    }
};

// ~~~~~~~~~~~~~~~ EVENTS ~~~~~~~~~~~~~~~
btn.addEventListener(`click`, () => {
    fetchFunction(API_URL1);
    nextBtn.style.display = `inline-block`;
    btn.style.display = `none`;
});

nextBtn.addEventListener(`click`, () => {
    fetchFunction(API_URL2);
    nextBtn.style.display = `none`;
    prevBtn.style.display = `inline-block`;
});

prevBtn.addEventListener(`click`, () => {
    fetchFunction(API_URL1);
    prevBtn.style.display = `none`;
    nextBtn.style.display = `inline-block`;
});