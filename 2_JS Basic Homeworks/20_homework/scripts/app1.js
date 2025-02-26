function toDos(numberOfTodos) {
    let todo;
    for (let i = 0; i < numberOfTodos; i++) {
        todo = prompt(`Enter thing ${i + 1} you need to do:`);
        toDosDispaly(todo, i)
    }
}

function toDosDispaly(todoMessage, iInput) {
    console.log(`Task ${iInput + 1}: ${todoMessage}`);
}

let numberOfTodosInput = parseInt(prompt(`Enter how much task you need to do`));

toDos(numberOfTodosInput);