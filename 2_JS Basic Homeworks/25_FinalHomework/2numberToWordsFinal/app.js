// ========= VARIABLES ==========
let text = document.getElementById(`text`);
let display = document.getElementById(`displayNumber`);
let convert = document.getElementById(`convert`);

// ========= FUNCTIONS ==========
function isNumberCorrect(number) {
    if (!/^\d+$/.test(number)) {
        alert(`Please enter a valid number`);
        return false;
    }

    let parsedNumber = parseInt(number, 10);
    if (isNaN(parsedNumber)) {
        alert(`Invalid number`);
        return false;
    }

    if (parsedNumber < 0 || parsedNumber > 1000000) {
        alert(`Please enter a number from 0 to 1,000,000`);
        return false;
    }
    return true;
}

function convertingNumber(number) {
    let words = numberToWords(parseInt(number, 10));
    display.innerText = words;
}

function numberToWords(number) {
    const ones = [``, `one`, `two`, `three`, `four`, `five`, `six`, `seven`, `eight`, `nine`];
    const teens = [``, `eleven`, `twelve`, `thirteen`, `fourteen`, `fifteen`, `sixteen`, `seventeen`, `eighteen`, `nineteen`];
    const tens = [``, `ten`, `twenty`, `thirty`, `forty`, `fifty`, `sixty`, `seventy`, `eighty`, `ninety`];
    const thousands = [``, `thousand`];

    if (number === 0) return `zero`;

    let word = ``;

    for (let i = 0; number > 0; i++) {
        let chunk = number % 1000;
        if (chunk > 0) {
            let chunkWord = chunkToWords(chunk, ones, teens, tens);
            word = chunkWord + (thousands[i] ? ` ${thousands[i]} ` : ``) + word;
        }
        number = Math.floor(number / 1000);
    }

    return word.trim();
}

function chunkToWords(number, ones, teens, tens) {
    let word = ``;

    if (number >= 100) {
        word += ones[Math.floor(number / 100)] + ` hundred `;
        number %= 100;
    }

    if (number >= 11 && number <= 19) {
        word += teens[number - 10] + ` `;
    } else {
        if (number >= 20 || number === 10) {
            word += tens[Math.floor(number / 10)] + ` `;
            number %= 10;
        }
        if (number > 0) {
            word += ones[number] + ` `;
        }
    }

    return word.trim();
}

// ========= EVENTS ==========
convert.addEventListener(`click`, function () {
    let textValue = text.value;
    if (isNumberCorrect(textValue)) {
        convertingNumber(textValue);
        text.value = ``;  
    }
});
