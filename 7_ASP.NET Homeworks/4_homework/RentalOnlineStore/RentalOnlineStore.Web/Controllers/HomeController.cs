using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RentalOnlineStore.Services.Interfaces;
using RentalOnlineStore.Web.Models;

namespace RentalOnlineStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;

        public HomeController(IMovieService movieService, IUserService userService)
        {
            _movieService = movieService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var movies = _movieService.GetAllMovies();
            return View(movies);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string cardNumber)
        {
            var user = _userService.GetUserByCardNumber(cardNumber);
            if (user == null)
            {
                ViewBag.Error = "Invalid card number";
                return View();
            }

            HttpContext.Session.SetInt32("UserId", user.Id);
            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Index");
        }
    }
}
