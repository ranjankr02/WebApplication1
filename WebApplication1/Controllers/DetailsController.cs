using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class DetailsController : Controller
    {
        public IActionResult Details()
        {
            return View();
        }
    }
}
