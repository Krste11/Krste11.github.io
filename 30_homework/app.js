// ~~~~~~~~~~~~ Api variable ~~~~~~~~~~~~
const API_URL = `https://fakestoreapi.com/products`;

// ~~~~~~~~~~~~ Selectors ~~~~~~~~~~~~
let cardDisplayer = document.querySelector(`#cardDisplayer`);
let prevBtn = document.querySelector(`#prev-btn`);
let nextBtn = document.querySelector(`#next-btn`);
let categoryButtonsContainer = document.querySelector(`#category-buttons`);
let cartCount = document.querySelector(`#cart-count`);
let cartItemsContainer = document.querySelector(`#cart-items`);
let cartTotal = document.querySelector(`#cart-total`);

// ~~~~~~~~~~~~ Global variables ~~~~~~~~~~~~
let products = [];
let filteredProducts = [];
let cart = [];
let currentPage = 1;
const productsPerPage = 8;

// ~~~~~~~~~~~~ Fetch function ~~~~~~~~~~~~
async function fetchProducts() {
    try {
        const res = await fetch(API_URL);
        if (!res.ok) {
            throw new Error(`Fetch products are not available`);
        }
        const json = await res.json();
        products = json;
        filteredProducts = json;
        displayProducts();
        createCategoryButtons();
    } catch (error) {
        console.error(`Error fetching API:`, error);
        cardDisplayer.innerHTML = `<p class="text-danger">Fetch products are not available</p>`;
    }
}

fetchProducts();

// ~~~~~~~~~~~~ Functions ~~~~~~~~~~~~
function displayProducts() {
    cardDisplayer.innerHTML = `<div class="row g-4"></div>`;
    let row = cardDisplayer.querySelector(`.row`);
    let start = (currentPage - 1) * productsPerPage;
    let end = start + productsPerPage;
    let paginatedProducts = filteredProducts.slice(start, end);

    paginatedProducts.forEach(product => {
        let productCard = document.createElement(`div`);
        productCard.className = `col-md-4 col-sm-6 col-12`;
        productCard.innerHTML = `
                <div class="card h-100 shadow-lg border-0 rounded-4">
                    <img src="${product.image}" class="card-img-top rounded-top-4 p-3" 
                        style="height: 200px; object-fit: contain;">
                    <div class="card-body text-center">
                        <h6 class="card-title text-truncate fw-bold">${product.title}</h6>
                        <p class="card-text text-muted small">${product.category}</p>
                        <p class="card-text fw-bold text-success">$${product.price.toFixed(2)}</p>
                        <button class="btn btn-primary w-100 fw-bold rounded-3 add-to-cart-btn" data-id="${product.id}">Add to Cart</button>
                    </div>
                </div>`;
        row.appendChild(productCard);
    });

    document.querySelectorAll(`.add-to-cart-btn`).forEach(button => {
        button.addEventListener(`click`, (e) => {
            let productId = parseInt(e.target.dataset.id);
            addToCart(productId);
        });
    });

    prevBtn.disabled = currentPage === 1;
    nextBtn.disabled = end >= filteredProducts.length;
}

function createCategoryButtons() {
    const categories = products.reduce((acc, product) => {
        if (!acc.includes(product.category)) {
            acc.push(product.category);
        }
        return acc;
    }, []);

    const allButton = `<button class="btn btn-outline-dark mb-2 w-100" data-category="all">Show All</button>`;
    let categoryButtons = categories.map(category =>
        `<button class="btn btn-outline-primary mb-2 w-100">${category}</button>`
    ).join(``);
    
    categoryButtonsContainer.innerHTML = allButton + categoryButtons;

    document.querySelectorAll(`#category-buttons button`).forEach(button => {
        button.addEventListener(`click`, (e) => {
            const category = e.target.textContent;
            filteredProducts = category === `Show All` ? products : products.filter(p => p.category === category);
            currentPage = 1;
            displayProducts();
        });
    });
}

function addToCart(productId) {
    const product = products.find(p => p.id === productId);
    if (product) {
        const existingProduct = cart.find(item => item.id === productId);
        if (existingProduct) {
            existingProduct.quantity++;
        } else {
            cart.push({ ...product, quantity: 1 });
        }
        updateCartDisplay();
    }
}

function updateCartDisplay() {
    cartCount.textContent = cart.length;
    cartItemsContainer.innerHTML = ``;

    let total = 0;
    cart.forEach(item => {
        let cartItem = document.createElement(`li`);
        cartItem.className = `list-group-item d-flex justify-content-between align-items-center`;
        cartItem.innerHTML = `${item.title} (x${item.quantity}) <span class="fw-bold">$${(item.price * item.quantity).toFixed(2)}</span>`;
        cartItemsContainer.appendChild(cartItem);
        total += item.price * item.quantity;
    });

    cartTotal.textContent = total.toFixed(2);
}

// ~~~~~~~~~~~~ Events ~~~~~~~~~~~~
prevBtn.addEventListener(`click`, () => {
    if (currentPage > 1) {
        currentPage--;
        displayProducts();
    }
});

nextBtn.addEventListener(`click`, () => {
    if (currentPage * productsPerPage < filteredProducts.length) {
        currentPage++;
        displayProducts();
    }
});
