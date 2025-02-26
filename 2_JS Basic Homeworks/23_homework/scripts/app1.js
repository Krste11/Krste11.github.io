$(document).ready(function () {
    let name = $(`#enterName`);
    let button = $(`#buttonClick`);
    let gretingPrint = $(`#gretingPrint`);

    function buttonClick() {
        gretingPrint.html(`Hello ${name.val()}`);
    }
    
    button.on(`click`,buttonClick)
})