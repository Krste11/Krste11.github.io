using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Dtos.MovieDtos;
using MovieApp.Services.Interfaces;
using MovieApp.Shared.CustomExceptions;

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
            catch(MovieNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(MovieDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
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
            catch (MovieNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (MovieDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
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
            catch (MovieNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (MovieDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
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
            catch (MovieNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (MovieDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
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
            catch (MovieNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (MovieDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPut]
        public IActionResult UpdateMovie([FromBody]AddMovieDto updateMovieDto)
        {
            try
            {
                _movieService.UpdateMovie(updateMovieDto);
                return Ok("Movie updated successfully");
            }
            catch (MovieNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (MovieDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        } 


        [HttpDelete]
        public IActionResult DeleteMovieFromBody([FromBody] int id)
        {
            try
            {
                _movieService.DeleteMovieFromBody(id);
                return Ok("Movie deleted successfully");
            }
            catch (MovieNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (MovieDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
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
            catch (MovieNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (MovieDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
