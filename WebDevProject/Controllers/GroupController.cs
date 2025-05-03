using Microsoft.AspNetCore.Mvc;

namespace WebDevProject.Controllers
{
    public class GroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
