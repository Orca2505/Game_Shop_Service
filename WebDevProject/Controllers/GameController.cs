using Microsoft.AspNetCore.Mvc;
using WebDevProject.Services;
using WebDevProject.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace WebDevProject.Controllers
{
    public class GameController(ApplicationDbContext db, UserManager<ApplicationUser> userManager) : Controller
    {
        private readonly ApplicationDbContext _db = db;
        private readonly UserManager<ApplicationUser> _user = userManager;
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
        //public IActionResult UserGames()
        //{
            //string userId = 
            //var userGames = _db.userGames.Where();
            //return View();
       // }
    }
}
