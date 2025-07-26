using Microsoft.AspNetCore.Mvc;
using RentalOnlineStore.Domain.Vm;
using RentalOnlineStore.Services.Interfaces;

namespace RentalOnlineStore.Web.Controllers
{
    public class RentalsController : Controller
    {
        private readonly IRentalService _rentalService;
        private readonly IMovieService _movieService;

        public RentalsController(IRentalService rentalService, IMovieService movieService)
        {
            _rentalService = rentalService;
            _movieService = movieService;
        }

        public IActionResult MyRentals()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Home");

            var rentals = _rentalService.GetRentalsByUserId(userId.Value);
            var viewModel = rentals.Select(r => new RentalViewModel
            {
                Rental = r,
                Movie = _movieService.GetMovieById(r.MovieId)
            }).ToList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Return(int rentalId)
        {
            var success = _rentalService.ReturnMovie(rentalId);
            if (!success)
            {
                TempData["Error"] = "Error returning movie";
            }

            return RedirectToAction("MyRentals");
        }
    }
}
