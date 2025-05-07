using Microsoft.AspNetCore.Mvc;
using WebDevProject.Services;
using WebDevProject.Models;
using WebDevProject.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace WebDevProject.Controllers
{
    public class GroupController(IGroupRepository groupRepository, UserManager<ApplicationUser> userManager) : Controller
    {
        private readonly IGroupRepository _groupRepo = groupRepository;
        private readonly UserManager<ApplicationUser> _user = userManager;

        public async Task<IActionResult> Index()
        {
            var groups = await _groupRepo.ReadAllGroups();
            return View(groups);
        }

        public async Task<IActionResult> Create()
        {
            var genres = await _groupRepo.GetAllGenres();
            var ViewModel = new Group { AllGenres = genres };
            return View(ViewModel);
        }

        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string? userId = _user.GetUserId(User);
            
            if (userId == null)
            {
                return BadRequest();
            }

            group.OwnerId = userId;
            await _groupRepo.CreateGroup(group);
            return RedirectToAction("Index");
        }
    }
}
