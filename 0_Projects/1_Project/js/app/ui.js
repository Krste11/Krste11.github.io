import { addToCart } from './cart.js';

export function displayProducts(cardDisplayer, filteredProducts, currentPage, productsPerPage) {
    cardDisplayer.innerHTML = '<div class="row g-4"></div>';
    let row = cardDisplayer.querySelector('.row');
    let start = (currentPage - 1) * productsPerPage;
    let end = start + productsPerPage;
    let paginatedProducts = filteredProducts.slice(start, end);

    paginatedProducts.forEach(product => {
        let productCard = document.createElement('div');
        productCard.className = 'col-md-4 col-sm-6 col-12';
        productCard.innerHTML = `
            <div class="card h-100 shadow-lg border-0 rounded-4">
                <img src="${product.images[0] || 'https://via.placeholder.com/200'}"
                    class="card-img-top rounded-top-4 p-3" style="height: 200px; object-fit: contain;" alt="${product.title}">
                <div class="card-body text-center">
                    <h6 class="card-title text-truncate fw-bold">${product.title}</h6>
                    <p class="card-text text-muted small">${product.category}</p>
                    <p class="card-text fw-bold text-success">$${product.price.toFixed(2)}</p>
                    <button class="btn btn-primary w-100 fw-bold rounded-3 add-to-cart-btn" data-id="${product.id}">Add to Cart</button>
                </div>
            </div>`;
        row.appendChild(productCard);
    });

    document.querySelectorAll('.add-to-cart-btn').forEach(button => {
        button.addEventListener('click', (e) => {
            let productId = parseInt(e.target.dataset.id);
            let product = filteredProducts.find(p => p.id === productId);
            if (product) addToCart(product);
        });
    });
}
