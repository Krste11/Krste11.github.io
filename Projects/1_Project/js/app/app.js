import { fetchProducts } from './api.js';
import { displayProducts } from './ui.js';
import { createCategoryButtons } from './categories.js';
import { setupPagination } from './pagination.js';

let cardDisplayer = document.querySelector('#cardDisplayer');
let prevBtn = document.querySelector('#prev-btn');
let nextBtn = document.querySelector('#next-btn');
let categoryButtonsContainer = document.querySelector('#category-buttons');

let products = [];
let filteredProducts = [];
let currentPage = 1;
const productsPerPage = 8;

async function init() {
    products = await fetchProducts();
    filteredProducts = products;

    displayProducts(cardDisplayer, filteredProducts, currentPage, productsPerPage);
    createCategoryButtons(products, categoryButtonsContainer, (filtered) => {
        filteredProducts = filtered;
        currentPage = 1;
        displayProducts(cardDisplayer, filteredProducts, currentPage, productsPerPage);
    });

    currentPage = setupPagination(prevBtn, nextBtn, currentPage, productsPerPage, filteredProducts, () => {
        displayProducts(cardDisplayer, filteredProducts, currentPage, productsPerPage);
    });
}

init();
