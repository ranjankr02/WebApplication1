using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.App.DAL;

namespace WebApplication1.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly AppDbContext _context;

        public AuthenticationController(AppDbContext context) 
        {
            _context = context;
        }

       
        public async Task<IActionResult> LogIn() 
        {
            string windowsUsername = User.Identity?.Name ?? "";

            if (string.IsNullOrEmpty(windowsUsername))
            {
                ViewBag.ErrorMessage = "Windows authentication failed.";
                return View();
            }

            // Check if user exists in the database
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == windowsUsername);
            var fullName = user?.Firstname;

            string? userGender = user?.Gender;
            if (user == null)
            {
                ViewBag.ErrorMessage = "Login Denied: User not found in system.";

                return View();
            }

            // Store session for authenticated user
            HttpContext.Session.SetString("WindowsUsername", fullName?? "");

            if(!string.IsNullOrEmpty(userGender))
            {
                HttpContext.Session.SetString("WindowsUserGender", userGender ?? "");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
