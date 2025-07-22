using Microsoft.AspNetCore.Mvc;
using RentalOnlineStore.Services.Interfaces;

namespace RentalOnlineStore.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IRentalService _rentalService;

        public MoviesController(IMovieService movieService, IRentalService rentalService)
        {
            _movieService = movieService;
            _rentalService = rentalService;
        }

        public IActionResult Details(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null) return NotFound();

            return View(movie);
        }

        [HttpPost]
        public IActionResult Rent(int movieId)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Home");

            var success = _movieService.RentMovie(movieId, userId.Value);
            if (!success)
            {
                TempData["Error"] = "Movie not available for rent";
            }

            return RedirectToAction("Details", new { id = movieId });
        }
    }

}
