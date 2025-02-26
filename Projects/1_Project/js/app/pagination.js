export function setupPagination(prevBtn, nextBtn, currentPage, productsPerPage, filteredProducts, displayProducts) {
    prevBtn.addEventListener('click', () => {
        if (currentPage > 1) {
            currentPage--;
            displayProducts();
        }
    });

    nextBtn.addEventListener('click', () => {
        if (currentPage * productsPerPage < filteredProducts.length) {
            currentPage++;
            displayProducts();
        }
    });

    return () => currentPage; // Return a function to get updated current page
}
