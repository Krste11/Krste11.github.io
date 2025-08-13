using WebApplication1.Models;

namespace WebApplication1.Data
{
    public static class StaticDb
    {
        public static List<Book> Books { get; set; } = new List<Book>
        {
            new Book
            {
                Author = "George Orwell",
                Title = "1984"
            },
            new Book
            {
                Author = "J.K. Rowling",
                Title = "Harry Potter and the Philosopher's Stone"
            },
            new Book
            {
                Author = "J.R.R. Tolkien",
                Title = "The Lord of the Rings"
            },
            new Book
            {
                Author = "F. Scott Fitzgerald",
                Title = "The Great Gatsby"
            }
        };
    }
}
