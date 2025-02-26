let cardDiv = document.getElementById(`card`);

let url = `https://dummyjson.com/products?limit=10`;

window.addEventListener(`load`, function () {
    fetchDisplay();
});

function fetchDisplay() {
    fetch(url)
        .then(function (res) {
            return res.json();
        })
        .then(function (data) {
            createCrad(data.products);
        });
}

function createCrad(dataArr) {
    for (let i = 0; i < dataArr.length; i++) {
        cardDiv.innerHTML += `
        <div class="card mb-4" style="width: 18rem;">
            <img src="${dataArr[i].images[0]}" class="card-img-top">
            <div class="card-body">
                <h5 class="card-title">${dataArr[i].title}</h5>
                <p class="card-text">${dataArr[i].description}</p>
                <a href="#" class="btn btn-primary">Go somewhere</a>
            </div>
        </div>
        `;
    }
}