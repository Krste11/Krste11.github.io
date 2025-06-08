export function createCategoryButtons(products, categoryButtonsContainer, displayProducts) {
    const categories = [...new Set(products.map(p => p.category))];

    categoryButtonsContainer.innerHTML = `<button class="btn w-100 active" data-category="all">Show All</button>` +
        categories.map(category =>
            `<button class="btn w-100" data-category="${category}">${category}</button>`
        ).join('');

    document.querySelectorAll('#category-buttons button').forEach(button => {
        button.addEventListener('click', (e) => {
            document.querySelectorAll('#category-buttons button').forEach(btn => btn.classList.remove('active'));
            e.target.classList.add('active');

            const category = e.target.dataset.category;
            let filteredProducts = category === 'all' ? products : products.filter(p => p.category === category);
            displayProducts(filteredProducts);
        });
    });
}