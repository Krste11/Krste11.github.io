function Book(title, author, readingStatus) {
    this.title = title;
    this.author = author;
    this.readingStatus = readingStatus;

    this.getMessage = function () {
        if (this.readingStatus) {
            console.log(`You read ${this.title} by ${this.author}.`);
        } else {
            console.log(`You need to read ${this.title} by ${this.author}.`);
        }
    }
}

let titleInput = prompt(`Please enter book name:`);
let author = prompt(`Please enter the author of the book:`);
let readingStatus = prompt(`Have you read this book? (true or false)`).toLowerCase() === `true`;

let book = new Book(titleInput, author, readingStatus);
book.getMessage();