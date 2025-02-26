export function createCategoryButtons(products, categoryButtonsContainer, displayProducts) {
    const categories = [...new Set(products.map(p => p.category))];

    categoryButtonsContainer.innerHTML = `<button class="btn btn-outline-dark w-100" data-category="all">Show All</button>` +
        categories.map(category =>
            `<button class="btn btn-outline-primary w-100">${category}</button>`
        ).join('');

    document.querySelectorAll('#category-buttons button').forEach(button => {
        button.addEventListener('click', (e) => {
            const category = e.target.textContent;
            let filteredProducts = category === 'Show All' ? products : products.filter(p => p.category === category);
            displayProducts(filteredProducts);
        });
    });
}
