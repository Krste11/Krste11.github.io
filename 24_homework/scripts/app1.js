// ================== Variables ==================
let description = document.getElementById(`description`);
let amount = document.getElementById(`amount`);
let category = document.getElementById(`category`);
let submit = document.getElementById(`submit`);
let tbody = document.getElementById(`tbody`);
let totalAmount = document.getElementById(`totalAmount`);
let expenseTrackerArr = [];

// ================== Functions ==================
function ExpenseTracker(description, amount, category) {
    this.description = description;
    this.amount = amount;
    this.category = category;
}

function addNewExpense() {
    let descriptionValue = description.value;
    let amountValue = amount.value;
    let categoryValue = category.value;

    amountValue = parseFloat(amountValue);

    if (!check(descriptionValue, amountValue, categoryValue)) {
        return;
    }

    let expenseTracker = new ExpenseTracker(descriptionValue, amountValue, categoryValue);
    expenseTrackerArr.push(expenseTracker);
    addRows(expenseTracker);
    totalAmountFunction(amount.value);

    description.value = ``;
    amount.value = ``;
    category.value = ``;
}

function check(description, amount, category) {
    if (!description) {
        alert(`Please enter a description`);
        return false;
    }

    if (!amount) {
        alert(`Please enter an amount`);
        return false;
    }

    if (isNaN(amount)) {
        alert(`Please enter a number for the amount`);
        return false;
    }

    if (!category) {
        alert(`Please enter a category`);
        return false;
    }
    return true;
}

function addRows(expenseTrackerValues) {
    let row = document.createElement(`tr`);

    row.innerHTML = `
        <td>${expenseTrackerValues.description}</td>
        <td>$${expenseTrackerValues.amount}</td>
        <td>${expenseTrackerValues.category}</td>
        <td><button class="delete-btn">Delete</button></td>
    `;

    let deleteBtn = row.querySelector(`.delete-btn`);

    deleteBtn.addEventListener(`click`, function () {
        deleteExpense(row, expenseTrackerValues);
    });

    tbody.appendChild(row);
}

function deleteExpense(row, expenseTrackerValues) {
    let index = -1;
    for (let i = 0; i < expenseTrackerArr.length; i++) {
        if (expenseTrackerArr[i] === expenseTrackerValues) {
            index = i;
            break;
        }
    }

    if (index !== -1) {
        for (let i = index; i < expenseTrackerArr.length - 1; i++) {
            expenseTrackerArr[i] = expenseTrackerArr[i + 1];
        }
        expenseTrackerArr.length = expenseTrackerArr.length - 1;
    }

    row.remove();

    totalAmountFunction()
}

function totalAmountFunction() {
    let total = 0;
    for (let i = 0; i < expenseTrackerArr.length; i++) {
        total += expenseTrackerArr[i].amount;
    }
    totalAmount.innerHTML = `$${total}`;
}

// ================== Events ==================
submit.addEventListener(`click`, function () {
    addNewExpense()
});