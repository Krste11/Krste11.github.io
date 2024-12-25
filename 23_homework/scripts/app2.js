$(document).ready(function () {
    let text = $(`#text`);
    let color = $(`#color`);
    let generateText = $(`#generateText`);
    let generatedText = $(`#generatedText`);
    let invalidColor = $(`#invalidColor`);

    function isValidColor(color) {
        let tempElement = document.createElement(`div`);
        tempElement.style.color = color;
        return tempElement.style.color !== ``;
    }

    function generateTextFunction() {
        if (!text.val() || !color.val()) {
            invalidColor.text(`Please entet text and color`);
        } else if (!isValidColor(color.val())) {
            invalidColor.text(`Please enter a color that exsists`);
            return;
        } else {
            generatedText.text(text.val()).css(`color`, `${color.val()}`);
        }
    }

    generateText.on(`click`, generateTextFunction);

})