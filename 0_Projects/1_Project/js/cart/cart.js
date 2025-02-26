export let cart = JSON.parse(localStorage.getItem('cart')) || [];

export function updateCartDisplay(cartItemsContainer, cartTotal, checkoutButton) {
    cartItemsContainer.innerHTML = '';
    let total = 0;

    if (cart.length === 0) {
        cartItemsContainer.innerHTML = '<p class="text-muted">Your cart is empty.</p>';
        checkoutButton.disabled = true;
    } else {
        checkoutButton.disabled = false;
    }

    cart.forEach(item => {
        let cartItem = document.createElement('li');
        cartItem.className = 'list-group-item d-flex justify-content-between align-items-center';
        cartItem.innerHTML = `
            <div class="d-flex align-items-center">
                <img src="${item.images[0] || 'https://via.placeholder.com/50'}" width="50" height="50" class="me-3">
                <span>${item.title}</span>
            </div>
            <div class="d-flex align-items-center">
                <button class="btn btn-sm btn-outline-secondary me-2 decrease-btn" data-id="${item.id}">−</button>
                <span class="fw-bold me-2">${item.quantity}</span>
                <button class="btn btn-sm btn-outline-secondary me-3 increase-btn" data-id="${item.id}">+</button>
                <span class="fw-bold">$${(item.price * item.quantity).toFixed(2)}</span>
                <button class="btn btn-sm btn-danger remove-btn ms-3" data-id="${item.id}">X</button>
            </div>
        `;

        cartItemsContainer.appendChild(cartItem);
        total += item.price * item.quantity;
    });

    cartTotal.textContent = total.toFixed(2);

    document.querySelectorAll('.remove-btn').forEach(button => {
        button.addEventListener('click', (e) => {
            removeFromCart(parseInt(e.target.dataset.id), cartItemsContainer, cartTotal, checkoutButton);
        });
    });

    document.querySelectorAll('.increase-btn').forEach(button => {
        button.addEventListener('click', (e) => {
            increaseQuantity(parseInt(e.target.dataset.id), cartItemsContainer, cartTotal, checkoutButton);
        });
    });

    document.querySelectorAll('.decrease-btn').forEach(button => {
        button.addEventListener('click', (e) => {
            decreaseQuantity(parseInt(e.target.dataset.id), cartItemsContainer, cartTotal, checkoutButton);
        });
    });
}

export function removeFromCart(productId, cartItemsContainer, cartTotal, checkoutButton) {
    cart = cart.filter(item => item.id !== productId);
    localStorage.setItem('cart', JSON.stringify(cart));
    updateCartDisplay(cartItemsContainer, cartTotal, checkoutButton);
}

export function increaseQuantity(productId, cartItemsContainer, cartTotal, checkoutButton) {
    const product = cart.find(item => item.id === productId);
    if (product) {
        product.quantity++;
        localStorage.setItem('cart', JSON.stringify(cart));
        updateCartDisplay(cartItemsContainer, cartTotal, checkoutButton);
    }
}

export function decreaseQuantity(productId, cartItemsContainer, cartTotal, checkoutButton) {
    const product = cart.find(item => item.id === productId);
    if (product && product.quantity > 1) {
        product.quantity--;
    } else {
        cart = cart.filter(item => item.id !== productId);
    }
    localStorage.setItem('cart', JSON.stringify(cart));
    updateCartDisplay(cartItemsContainer, cartTotal, checkoutButton);
}

export function checkout(cartItemsContainer, cartTotal, checkoutButton) {
    if (cart.length > 0) {
        alert('🛒 Thank you for your purchase! Your order has been placed. 🎉');
        cart = [];
        localStorage.setItem('cart', JSON.stringify(cart));
        updateCartDisplay(cartItemsContainer, cartTotal, checkoutButton);
    }
}
