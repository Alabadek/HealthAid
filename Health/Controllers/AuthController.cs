using Health.Models;
using Health.Services;

using Microsoft.AspNetCore.Mvc;

public class AuthController : Controller
{
    private readonly UserService _userService;

    public AuthController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public IActionResult Login(UserCredentials credentials)
    {
        bool isValidUser = false;

        // Validate user based on their user type
        if (credentials.UserType == "Patient")
        {
            isValidUser = _userService.ValidatePatient(credentials.Username, credentials.Id);
            if (isValidUser)
            {
                return RedirectToAction("Index", "SinglePatient",new {id=credentials.Id}); // Redirect to Patient Index
            }
        }
        else if (credentials.UserType == "Staff")
        {
            isValidUser = _userService.ValidateStaff(credentials.Username, credentials.Id);
            if (isValidUser)
            {
               
                return RedirectToAction("Index", "Patient"); // Redirect to Staff Index
            }
        }

        // Handle invalid login
        ModelState.AddModelError("", "Invalid login attempt.");
        return View(credentials);
    }
}
