let input = document.getElementById(`input`);
let search = document.getElementById(`search`);
let output = document.getElementById(`output`);

let movies = [
    `CASABLANCA`,
    `AVATAR`,
    `TITANIC`,
    `GLADIATOR`
];

function moviesSearch() {
    let inputValue = input.value.toUpperCase();
    let found = false;

    for (let i = 0; i < movies.length; i++) {
        if (inputValue === movies[i].toUpperCase()) {
            found = true;
            break;
        }
    }

    if (found) {
        output.innerHTML = `Movie ${inputValue} has been found`;
        output.style.color = `green`;
    } else {
        output.innerHTML = `Movie has not been found`;
        output.style.color = `red`;
    }

    input.value = ``;
}


search.addEventListener(`click`,function() {
    moviesSearch();
})