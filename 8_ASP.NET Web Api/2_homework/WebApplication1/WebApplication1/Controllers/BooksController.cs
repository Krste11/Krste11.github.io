using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks()
        {
            try
            {
                return Ok(StaticDb.Books);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Contact the admin you have error {e.Message}");
            }

        }


        [HttpGet("queryString")]
        public ActionResult<Book> GetBookById(int? id)
        {
            try
            {
                if(id == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Id is a required");
                }
                if (id < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Id cannot be negative");
                }

                if(id >= StaticDb.Books.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Book not found");
                }

                return Ok(StaticDb.Books[id.Value]);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Contact the admin you have error {e.Message}");
            }
        }


        [HttpGet("multipleQueryString")]
        public ActionResult<List<Book>> FilterBooksByQueryStrings(string? Author, string? Title)
        {
            try
            {
                if(string.IsNullOrEmpty(Author) && string.IsNullOrEmpty(Title))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "At least one query string is required");
                }
                if (string.IsNullOrEmpty(Author))
                {
                    List<Book> filteredBooks = StaticDb.Books.Where(x => x.Title.ToLower().Contains(Title.ToLower())).ToList();
                    if (filteredBooks.Count == 0)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, "No books found with the given title");
                    }
                    return Ok(filteredBooks);
                }
                if(string.IsNullOrEmpty(Title))
                {
                    List<Book> filteredBooks = StaticDb.Books.Where(x => x.Author.ToLower().Contains(Author.ToLower())).ToList();
                    if (filteredBooks.Count == 0)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, "No books found with the given author");
                    }
                    return Ok(filteredBooks);
                }

                List<Book> filteredBooksDb = StaticDb.Books
                    .Where(x => x.Author.ToLower().Contains(Author.ToLower()) && x.Title.ToLower().Contains(Title.ToLower()))
                    .ToList();

                return Ok(filteredBooksDb);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Contact the admin you have error {e.Message}");
            }
        }


        [HttpPost]
        public IActionResult PostBook([FromBody] Book book)
        {
            try
            {
                if(string.IsNullOrEmpty(book.Author))
                {
                    return BadRequest("Book must contain author");
                }

                if (string.IsNullOrEmpty(book.Title))
                {
                    return BadRequest("Book must contain title");
                }

                StaticDb.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created, "Book created successfully");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Contact the admin you have error {e.Message}");
            }
        }


        [HttpPost("list")]
        public ActionResult<List<string>> PostListOfBooks([FromBody] List<Book> books)
        {
            try
            {
                if (books == null)
                {
                    return BadRequest("Books list cannot be null");
                }

                if (books.Count == 0)
                {
                    return BadRequest("Books list cannot be empty");
                }

                foreach (Book book in books)
                {
                    if (string.IsNullOrEmpty(book.Author) || string.IsNullOrEmpty(book.Title))
                    {
                        return BadRequest("Each book must contain an author and a title");
                    }
                }

                StaticDb.Books.AddRange(books);

                List<string> titles = books.Select(x => x.Title).ToList();

                return Ok(titles);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Contact the admin you have error {e.Message}");
            }
        }
    }
}
