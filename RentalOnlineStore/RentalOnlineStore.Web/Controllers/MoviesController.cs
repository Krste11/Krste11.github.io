using Microsoft.AspNetCore.Mvc;
using RentalOnlineStore.Domain.Enums;
using RentalOnlineStore.Services.Interfaces;

public class MoviesController : Controller
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    // GET: /movies
    public IActionResult Index(string genre = null)
    {
        var movies = genre == null
            ? _movieService.GetAll()
            : _movieService.GetByGenre(Enum.Parse<Genre>(genre));

        return View(movies);
    }

    // GET: /movies/details/5
    public IActionResult Details(int id)
    {
        var movie = _movieService.GetById(id);
        if (movie == null) return NotFound();

        return View(movie);
    }
}