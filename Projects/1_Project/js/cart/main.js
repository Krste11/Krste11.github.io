import { cart, updateCartDisplay, checkout } from './cart.js';

document.addEventListener('DOMContentLoaded', () => {
    const cartItemsContainer = document.querySelector('#cart-items');
    const cartTotal = document.querySelector('#cart-total');
    const checkoutButton = document.querySelector('#checkout-btn');

    updateCartDisplay(cartItemsContainer, cartTotal, checkoutButton);

    checkoutButton.addEventListener('click', () => {
        checkout(cartItemsContainer, cartTotal, checkoutButton);
    });
});
