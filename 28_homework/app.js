console.log(`Task 1`);

const API_URL = `https://dummyjson.com/recipes`;

fetch(API_URL)
    .then(res => res.json())
    .then(dataUrl => displayTasks(dataUrl))

function displayTasks(data) {
    console.log(data);
    data.recipes.forEach(item => console.log(item.name));

    const cinnamon = data.recipes.filter(item => item.ingredients.includes(`Cinnamon`));
    console.log(cinnamon);

    const lunch = data.recipes.filter(item => item.mealType.includes(`Dinner`) && item.mealType.includes(`Lunch`));
    console.log(lunch);

    const mangoSalsaChicken = data.recipes.filter(item => item.name === `Mango Salsa Chicken`).map(m => m.ingredients);
    console.log(mangoSalsaChicken);

    const american = data.recipes.filter(item => item.cuisine === `American`).map(c => c.caloriesPerServing);
    const averageCalories = american.reduce((acc, time) => acc + time, 0) / american.length;
    console.log(averageCalories);

    const timePasta = data.recipes.filter(item => item.name.includes(`Pasta`)).map(t => t.cookTimeMinutes);
    const averageCookTime = timePasta.reduce((acc, time) => acc + time, 0) / timePasta.length;
    console.log(averageCookTime);

    const lowestRating = Math.min(...data.recipes.map(item => item.rating));
    data.recipes.forEach(item => item.rating = lowestRating);
    console.log(lowestRating);
}