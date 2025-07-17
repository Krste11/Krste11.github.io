using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RentalOnlineStore.Web.Models;

namespace RentalOnlineStore.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
