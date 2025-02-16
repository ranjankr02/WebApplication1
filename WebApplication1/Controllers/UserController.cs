using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication1.App.BAL.Services;
using WebApplication1.App.DAL;
using WebApplication1.App.DataTransferLayer.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext context;
        private readonly IUserService _userService;

        public UserController(AppDbContext context, IUserService userService)
        {
            this.context = context;
            this._userService = userService;
        }

        public async Task<IActionResult> Users()
        {
            List<UserDto> users = (await _userService.GetAllUserAsync()).ToList();
            return View(users);
        }

        // 🚀 GET: Load User Detail Page
        public async Task <IActionResult> UserDetail(int? id)
        {
            if (id == null) // Create New User
            {
                return View(new UserDto());
            }

            UserDto user = await _userService.GetUserByIdAsync(id.Value);
            if (user == null)
                return NotFound();

            return View(user); // Load existing user data for editing
        }

        [HttpPost]
        public async Task<IActionResult> UserDetail(UserDto userDto)
        {
            if (!ModelState.IsValid)
                return View(userDto);

            if (userDto.Id == 0)
            {
                await _userService.CreateUserAsync(userDto); // Add User
            }
            else
            {
                await _userService.UpdateUserAsync(userDto); // Update User
            }

            return RedirectToAction("Users");
        }
    }
}
