// ========== VARIABLES ==========
const todoInput = document.getElementById(`todo-input`);
const addTodoBtn = document.getElementById(`add-btn`);
const todoList = document.getElementById(`todo-list`);
const todoItems = [];

// ========== FUNCTIONS ==========

// Constructor function for creating ToDo objects
function ToDo(name, isCompleted) {
    this.name = name;
    this.isCompleted = isCompleted;
}

// Funnction to add new ToDo
function addNewTodo() {
    const todoInputValue = todoInput.value;

    if (!todoInputValue) {
        alert(`Please enter a value`);
        return;
    }

    const newTodo = new ToDo(todoInputValue, false);
    todoItems.push(newTodo);
    todoInput.value = ``;
}

function renderTodos() {
    todoList.innerHTML = ``;
    let htmlBuilder = ``;

    for (let i = 0; i < todoItems.length; i++) {
        let todo = todoItems[i];

        htmlBuilder += `<li>`;
        if (todo.isCompleted) {
            htmlBuilder += `
                <input type="checkbox" data-todoindex="${i}" checked>
                <span><del>${todo.name}</del></span>
            `
        } else {
            htmlBuilder += `
            <input data-todoindex="${i}" type="checkbox">
                <span>${todo.name}</span>
            `
        }
        htmlBuilder += `</li>`
    }
    todoList.innerHTML = htmlBuilder;
}

function renderTodosUsingCreateElement() {
    todoList.innerHTML = ``;
    
    for(let i = 0; i < todoItems.length; i++) {
        const todo = todoItems[i];

        // Create the list item
        const listItem = document.createElement(`li`);

        // Create the checkbox
        const checkbox = document.createElement(`input`)
        checkbox.type = `checkbox`;
        checkbox.dataset.todoindex = i; // Attach the index as a dataset item
        checkbox.checked = todo.isCompleted; // Mark it as checked if comleted

        const textSpan = document.createElement(`span`);
        textSpan.textContent = todo.name;

        if (todo.isCompleted) {
            textSpan.style.textDecoration = `line-through`;
        }

        // Append the checkbox and text span to the list item
        listItem.appendChild(checkbox);
        listItem.appendChild(textSpan);

        // Append the list item to the todoList
        todoList.appendChild(listItem);
    }
}

// Function to toggle the completion status of a todo
function toggleTodoStatus(index) {
    const todo = todoItems[index];
    todo.isCompleted = !todo.isCompleted;
}

// =========== EVENTS ===========

addTodoBtn.addEventListener(`click`,function(event) {
    console.log(event);
    
    addNewTodo();

    // logic for diplaying Todos
    if(todoItems.length > 0) {
        renderTodos();
    }
})

todoList.addEventListener(`change`, function(e) {
    console.log(e.target);
    console.log(e.target.dataset);
    
    const todoIndex = e.target.dataset.todoindex;
    toggleTodoStatus(todoIndex);
    renderTodos();
})