using Microsoft.AspNetCore.Mvc;
using MovieApp.Domain.Models;
using MovieApp.Dtos.MovieDtos;
using MovieApp.Services.Interfaces;

namespace MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public ActionResult<List<MovieDto>> GetAllMovies()
        {
            try
            {
                var moviesDb = _movieService.GetAllMovies();
                return Ok(moviesDb);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"You have error {ex.Message}, please contact admin");

            }
        }

        [HttpGet("queryParms")]
        public ActionResult<MovieDto> GetMovieByIdFromQuery(int id)
        {
            try
            {
                var movieDb = _movieService.GetMovieByIdFromQuery(id);
                return Ok(movieDb);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"You have error {ex.Message}, please contact admin");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<MovieDto> GetMovieByIdFromRoute(int id)
        {
            try
            {
                var movieDb = _movieService.GetMovieByIdFromRoute(id);
                return Ok(movieDb);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"You have error {ex.Message}, please contact admin");
            }
        }

        [HttpGet("multipleQueryStrings")]
        public ActionResult<MovieDto> FilterMovies(string? genre, int? year)
        {
            try
            {
                var moviesDb = _movieService.FilterMovies(genre, year);
                return Ok(moviesDb);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"You have error {ex.Message}, please contact admin");
            }
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] AddMovieDto addMovieDto)
        {
            try
            {
                _movieService.AddMovie(addMovieDto);
                return Ok("Movie added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"You have error {ex.Message}, please contact admin");
            }
        }

        [HttpPut]
        public IActionResult UpdateMovie([FromBody] AddMovieDto updateMovieDto)
        {
            try
            {
                _movieService.UpdateMovie(updateMovieDto);
                return Ok("Movie updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"You have error {ex.Message}, please contact admin");
            }
        }

        [HttpDelete("deleteFromBody")]
        public IActionResult DeleteMovieFromBody([FromBody] int id)
        {
            try
            {
                _movieService.DeleteMovieFromBody(id);
                return Ok("Movie deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"You have error {ex.Message}, please contact admin");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovieFromRoute(int id)
        {
            try
            {
                _movieService.DeleteMovieFromRoute(id);
                return Ok("Movie deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"You have error {ex.Message}, please contact admin");
            }
        }
    }
}
