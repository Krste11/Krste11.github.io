using Microsoft.AspNetCore.Mvc;
using RentalOnlineStore.Services.Interfaces;

public class UsersController : Controller
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    // GET: /users/profile/5
    public IActionResult Profile(int id)
    {
        var user = _userService.GetById(id);
        if (user == null) return NotFound();

        return View(user);
    }

    // GET: /users/subscription/5
    public IActionResult SubscriptionStatus(int id)
    {
        var isExpired = _userService.IsSubscriptionExpired(id);
        return View(isExpired); // View showing subscription status
    }
}