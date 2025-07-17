using Microsoft.AspNetCore.Mvc;
using RentalOnlineStore.Services.Interfaces;

namespace RentalOnlineStore.Web.Controllers
{
    public class RentalsController : Controller
    {
        private readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        // GET /rentals/active
        [Route("rentals/active")]
        public IActionResult ActiveRentals()
        {
            var rentals = _rentalService.GetActiveRentals();
            return View(rentals); // Assumes you have an ActiveRentals.cshtml view
        }

        // GET /users/{userId}/rentals
        [Route("users/{userId}/rentals")]
        public IActionResult UserRentals(int userId)
        {
            var rentals = _rentalService.GetUserRentals(userId);
            return View(rentals); // Assumes you have a UserRentals.cshtml view
        }

        // POST /rentals/rent
        [HttpPost]
        [Route("rentals/rent")]
        public IActionResult RentMovie(int movieId, int userId)
        {
            var rental = _rentalService.RentMovie(movieId, userId);
            return RedirectToAction("RentalDetails", new { id = rental.Id });
        }

        // POST /rentals/{id}/return
        [HttpPost]
        [Route("rentals/{id}/return")]
        public IActionResult ReturnMovie(int id)
        {
            _rentalService.ReturnMovie(id);
            return RedirectToAction("RentalDetails", new { id });
        }

        // GET /rentals/{id}
        [Route("rentals/{id}")]
        public IActionResult RentalDetails(int id)
        {
            var rental = _rentalService.GetRentalById(id);
            return View(rental); // Assumes you have a RentalDetails.cshtml view
        }
    }
}