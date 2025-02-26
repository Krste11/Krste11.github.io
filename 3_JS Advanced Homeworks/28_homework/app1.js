console.log(`Task 2`)

const API_URL = `https://dummyjson.com/carts`;

fetch(API_URL)
    .then(res => res.json())
    .then(dataUrl => displayTasks(dataUrl))

function displayTasks(data) {
    const carts = data.carts;
    console.log(carts);

    const totalQuantity = carts.flatMap(cart => cart.products).reduce((sum, product) => sum + product.quantity, 0);
    console.log(totalQuantity)

    const valueOver = carts.filter(cart => cart.total > 100000);
    console.log(valueOver);

    const totalRevenue = carts.flatMap(cart => cart.discountedTotal).reduce((acc, cur) => acc + cur, 0);
    console.log(totalRevenue);

    const cartHighestValue = carts.reduce((max, cart) => {
        if (cart.total > max.total) {
            return cart;
        }
        return max;
    }).total;
    console.log(cartHighestValue);

    const discount = carts.flatMap(cart => cart.products).filter(product => product.discountPercentage > 15);
    console.log(discount);

    const idBiggest = carts.reduce((max, cart) => {
        if (cart.id > max.id) {
            return cart;
        }
        return max;
    }).id;
    console.log(idBiggest);

    const mostExpensiveProduct = carts.flatMap(cart => cart.products)
        .reduce((max, product) => product.price > max.price ? product : max);
    console.log(mostExpensiveProduct);

    const total = carts.reduce((acc, cart) => acc + cart.discountedTotal, 0);
    const average = total / carts.length;
    console.log(average);

    const mostExpensive = carts.flatMap(cart => cart.products)
        .sort((a, b) => b.discountedPrice - a.discountedPrice)
        .slice(0, 3);
    console.log(mostExpensive);

}