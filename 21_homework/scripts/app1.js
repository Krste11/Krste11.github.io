let firstDivHeader = document.getElementById(`first`).children[0].innerHTML = `Yea! Cool page CHANGED`;
let firstDivParagraph = document.getElementById(`first`).children[1].innerHTML = `This is an exercise. It's pretty easy CHANGED`;

let secondDivParagraph = document.getElementsByClassName(`anotherDiv`)[0].children[0].innerHTML = `No really, It's easy! CHANGED`;
let secondDivText = document.getElementsByClassName(`anotherDiv`)[0].children[1].innerHTML = `It's about selecting elements and CHANGED`;

let thirdDivfirstHeader = document.getElementsByTagName(`body`)[0].children[2].children[0].innerHTML = `This should be changed CHANGED`;
let thirdDivSecondHeader = document.getElementsByTagName(`body`)[0].children[2].children[1].innerHTML = `And also this! CHANGED`;