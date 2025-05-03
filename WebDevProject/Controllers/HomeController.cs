using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebDevProject.Models;
using WebDevProject.Services;

namespace WebDevProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepo;

        public HomeController(IUserRepository userRepo,ILogger<HomeController> logger)
        {
            _logger = logger;
            _userRepo = userRepo;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetUserId()
        {
            if (User.Identity!.IsAuthenticated)
            {
                string username = User.Identity.Name ?? "";
                var user = await _userRepo.ReadByUsernameAsync(username);
                if (user != null)
                {
                    return Content(user.Id);
                }
            }
            return Content("No user");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
