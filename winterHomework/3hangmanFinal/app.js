let wordList = [];

fetch(`baseMovies.json`)
  .then(response => response.json())
  .then(data => {
    wordList = data.movies;
    startGame();
  })
  .catch(err => console.error(`Error loading the words:`, err));

let word;
let wordDisplay = ``;
let guessedLetters = [];
let lives = 6;
let incorrectGuesses = 0;

const scaffoldSteps = [
    `+---+\n    |\n    |\n    |\n   ===`,
    `+---+\n O  |\n    |\n    |\n   ===`,
    `+---+\n O  |\n |  |\n    |\n   ===`,
    `+---+\n O  |\n/|  |\n    |\n   ===`,
    `+---+\n O  |\n/|\\ |\n    |\n   ===`,
    `+---+\n O  |\n/|\\ |\n/   |\n   ===`,
    `+---+\n O  |\n/|\\ |\n/ \\ |\n   ===`
];

function startGame() {
    word = wordList[Math.floor(Math.random() * wordList.length)];
    wordDisplay = ``;
    for (let i = 0; i < word.length; i++) {
        wordDisplay += `_ `;
    }
    guessedLetters = [];
    lives = 6;
    incorrectGuesses = 0;
    updateDisplay();
}

function updateDisplay() {
    document.getElementById(`wordDisplay`).textContent = wordDisplay.trim();
    document.getElementById(`lives`).textContent = `Lives: ` + lives;
    document.getElementById(`hangman`).textContent = scaffoldSteps[incorrectGuesses];

    if (lives === 0) {
        alert(`Game Over! You lost.`);
        startGame();
    } else if (!wordDisplay.includes(`_`)) {
        alert(`You Win! You've guessed the word.`);
        startGame();
    }
}

function guessLetter(letter) {
    if (guessedLetters.indexOf(letter) !== -1) {
        return;
    }

    guessedLetters.push(letter);
    let found = false;
    let newWordDisplay = ``;
    for (let i = 0; i < word.length; i++) {
        if (word[i] === letter) {
            newWordDisplay += letter + ` `;
            found = true;
        } else {
            newWordDisplay += wordDisplay[i * 2] + ` `;
        }
    }

    wordDisplay = newWordDisplay.trim();
    if (!found) {
        incorrectGuesses++;
        lives--;
    }

    updateDisplay();
}