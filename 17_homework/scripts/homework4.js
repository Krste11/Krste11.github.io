function checkText(text) {
    for (let i = 0; i < text.length; i++) {
        let numbers = parseInt((text[i]));
        if (!isNaN(numbers)) {
            if (numbers % 2 === 0) {
                console.log(numbers + `\n `);
            } else {
                console.log(numbers + ` `);
            }
        }
    }
}

let textInput = [`Hello`, `1`, `11232`, `Hello`, `1`, `1123`, `Hello`, `15`, `1126`, `Hello`, `17`, `11762`, `Hello`, `1`, `11672`, `Hello`, `651`, `11562`, `233672`, 232];
checkText(textInput)