function ingredients(numbersOfIngredients,recipeName) {
    let ingredient;
    document.write(`<h1>${recipeName}</h1>`);
    for (let i = 0; i < numbersOfIngredients; i++) {
        ingredient = prompt(`Enter ingredient ${i + 1}`);
        document.write(`<table>`);
        document.write(`<tr><th>Ingredient ${i + 1}</th><th>${ingredient}</th></tr>`);
    }
}

let recipeNameInput = prompt(`Please enter recipe name`);
let numbersOfIngredientsInput = prompt(`Please enter how many ingredients are need to make ${recipeNameInput}`);
ingredients(numbersOfIngredientsInput,recipeNameInput);