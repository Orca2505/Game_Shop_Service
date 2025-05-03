using Microsoft.AspNetCore.Mvc;
using WebDevProject.Services;
using WebDevProject.Models.ViewModels;

namespace WebDevProject.Controllers
{
    public class GameController(ApplicationDbContext db) : Controller
    {
        private readonly ApplicationDbContext _db = db;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var genres = _db.Genre.ToList();
            var ViewModel = new GameCreateVM { AllGenres = genres };
            return View(ViewModel);
        }
    }
}
