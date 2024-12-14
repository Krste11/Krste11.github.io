function makeBigString(sentenceArray) {
    let result = ` `;
    for(let i = 0; i < sentenceArray.length; i++) {
        result += sentenceArray[i] + ` `;
    }
    console.log(result);
}

let sentenceArray = ["Hello", "there", "students", "of", "SEDC", "!"];
makeBigString(sentenceArray);