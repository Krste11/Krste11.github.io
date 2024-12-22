let rowsInput = document.getElementById(`rows`);
let colsInput = document.getElementById(`cols`);
let createTableDimenionsBtn = document.getElementById(`createTableDimenions`);
let tableContainer = document.getElementById(`tableContainer`);

createTableDimenionsBtn.addEventListener(`click`, function () {
    let rows = parseInt(rowsInput.value);
    let cols = parseInt(colsInput.value);
    
    let table = ``;

    for (let i = 0; i < rows; i++) {
        let row = `<tr>`;

        for (let j = 0; j < cols; j++) {
            row += `<td>Row ${i + 1} Col ${j + 1}</td>`;
        }

        row += `</tr>`;
        table += row;
    }
    tableContainer.innerHTML = `<table>${table}</table>`;
})
