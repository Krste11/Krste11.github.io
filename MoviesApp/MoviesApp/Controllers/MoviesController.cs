using Microsoft.AspNetCore.Mvc;
using MoviesApp.Data;
using MoviesApp.DTOs;
using MoviesApp.Models;

namespace MoviesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public MoviesController(MovieDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<MovieDto>> GetAllMovies()
        {
            try
            {
                var moviesDto = _context.Movies
                    .Select(x => new MovieDto
                    {
                        Title = x.Title,
                        Description = x.Description,
                        Year = x.Year,
                        Genre = x.Genre
                    })
                    .ToList();

                return Ok(moviesDto);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Contact the admin, error: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<MovieDto> GetMovieById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id cannot be negative or zero");

                var movieDb = _context.Movies.FirstOrDefault(x => x.Id == id);
                if (movieDb == null)
                    return NotFound($"The movie with id {id} does not exist");

                var movieDto = new MovieDto
                {
                    Title = movieDb.Title,
                    Description = movieDb.Description,
                    Year = movieDb.Year,
                    Genre = movieDb.Genre
                };

                return Ok(movieDto);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Contact the admin, error: {e.Message}");
            }
        }

        [HttpGet("multipleQueryStrings")]
        public ActionResult<List<MovieDto>> GetMovies([FromQuery] string? genre, [FromQuery] DateTime? year)
        {
            try
            {
                if (string.IsNullOrEmpty(genre) && year == null)
                    return BadRequest("You have to send at least one filter parameter");

                var query = _context.Movies.AsQueryable();

                if (!string.IsNullOrEmpty(genre))
                    query = query.Where(x => x.Genre.ToLower() == genre.ToLower());

                if (year != null)
                    query = query.Where(x => x.Year == year);

                var movieDto = query.Select(x => new MovieDto
                {
                    Title = x.Title,
                    Description = x.Description,
                    Year = x.Year,
                    Genre = x.Genre
                }).ToList();

                return Ok(movieDto);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Contact the admin, error: {e.Message}");
            }
        }

        [HttpPost]
        public IActionResult PostMovie([FromBody] MovieDto createNewMovie)
        {
            try
            {
                if (string.IsNullOrEmpty(createNewMovie.Title))
                    return BadRequest("Please enter title");

                if (string.IsNullOrEmpty(createNewMovie.Genre))
                    return BadRequest("Please enter genre");

                if (createNewMovie.Year.Year < 1900)
                    return BadRequest("Please enter valid year");

                Movie movie = new Movie()
                {
                    Title = createNewMovie.Title,
                    Genre = createNewMovie.Genre,
                    Year = createNewMovie.Year,
                    Description = createNewMovie.Description
                };

                _context.Movies.Add(movie);
                _context.SaveChanges(); 

                return StatusCode(201, "New movie created");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Contact the admin, error: {e.Message}");
            }
        }

        [HttpPut]
        public IActionResult UpdateMovie(CreateNewMovie createNewMovie)
        {
            try
            {
                var movieDb = _context.Movies.FirstOrDefault(x => x.Id == createNewMovie.Id);
                if (movieDb == null)
                    return NotFound($"The movie with id {createNewMovie.Id} does not exist");

                if (string.IsNullOrEmpty(createNewMovie.Title))
                    return BadRequest("Please enter title");

                if (string.IsNullOrEmpty(createNewMovie.Genre))
                    return BadRequest("Please enter genre");

                if (createNewMovie.Year.Year < 1900)
                    return BadRequest("Please enter valid year");

                movieDb.Title = createNewMovie.Title;
                movieDb.Genre = createNewMovie.Genre;
                movieDb.Year = createNewMovie.Year;
                movieDb.Description = createNewMovie.Description;

                _context.SaveChanges(); 

                return Ok("Movie updated");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Contact the admin, error: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovieById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id has invalid value");

                var movieDb = _context.Movies.FirstOrDefault(x => x.Id == id);
                if (movieDb == null)
                    return NotFound($"Movie with id: {id} was not found!");

                _context.Movies.Remove(movieDb);
                _context.SaveChanges(); 

                return Ok("Movie was deleted!");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred, contact admin!");
            }
        }

        [HttpDelete("queryParms")]
        public IActionResult DeleteMovieByIdParms(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id has invalid value");

                var movieDb = _context.Movies.FirstOrDefault(x => x.Id == id);
                if (movieDb == null)
                    return NotFound($"Movie with id: {id} was not found!");

                _context.Movies.Remove(movieDb);
                _context.SaveChanges();

                return Ok("Movie was deleted!");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred, contact admin!");
            }
        }
    }
}
