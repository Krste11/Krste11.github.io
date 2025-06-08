const API_URL = 'https://dummyjson.com/products';

export async function fetchProducts() {
    try {
        const res = await fetch(API_URL);
        if (!res.ok) throw new Error('Failed to load products.');

        const json = await res.json();
        return json.products;
    } catch (error) {
        console.error('Error fetching API:', error);
        return [];
    }
}