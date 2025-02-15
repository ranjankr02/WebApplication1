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
    }
}
