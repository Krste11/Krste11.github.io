using Microsoft.AspNetCore.Mvc;
using RentalOnlineStore.Services.Interfaces;

public class AccountController : Controller
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    // GET: /account/login
    public IActionResult Login()
    {
        return View();
    }

    // POST: /account/login
    [HttpPost]
    public IActionResult Login(string cardNumber)
    {
        var user = _userService.GetByCardNumber(cardNumber);
        if (user == null) return View("Login", "Invalid card number");

        // Store user ID in session (simplified auth)
        HttpContext.Session.SetInt32("UserId", user.Id);

        return RedirectToAction("Index", "Home");
    }
}