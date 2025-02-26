let div = document.getElementById(`div`);

function getRandomColor() {
    const letters = `0123456789ABCDEF`;
    let color = `#`;
    for (let i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}

// document.addEventListener(`DOMContentLoaded`,function(){
//     div.style.backgroundColor = getRandomColor();
//     div.style.color = getRandomColor();
// })

window.addEventListener(`load`, function () {
    div.style.backgroundColor = getRandomColor();
    div.style.color = getRandomColor();
})