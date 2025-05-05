using Microsoft.AspNetCore.Mvc;
using WebDevProject.Services;
using WebDevProject.Models;
using WebDevProject.Models.ViewModels;
using Microsoft.AspNetCore.Cors;
using System.Globalization;
using Microsoft.AspNetCore.Identity;

namespace WebDevProject.Controllers
{
    [Route("api/game")]
    [ApiController]
    [EnableCors]
    public class GameAPIController(IGameRepository gameRepository, UserManager<ApplicationUser> userManager) : ControllerBase
    {
        private readonly IGameRepository _gameRepo = gameRepository;
        private readonly UserManager<ApplicationUser> _user = userManager;

        [HttpGet("all")]
        public async Task<IActionResult> Index()
        {
            var games = await _gameRepo.ReadAllGames();
            List<GameIndexVM> gameViews = new List<GameIndexVM>();
            foreach (var game in games)
            {
                var gameGenres = await _gameRepo.GetGameGenres(game.Id);

                string dateString = game.ReleaseDate.ToString();
                var gameView = new GameIndexVM
                {
                    Id = game.Id,
                    Title = game.Title,
                    Developer = game.Developer,
                    Publisher = game.Publisher,
                    Genre = gameGenres,
                    ReleaseDate = dateString
                };
                gameViews.Add(gameView);

            }
            return Ok(gameViews);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] GameCreateVM gameVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DateOnly releaseDate = DateOnly.ParseExact(gameVM.ReleaseDate, "yyyy-MM-dd", CultureInfo.CurrentCulture);

            var game = new Game
            {
                Title = gameVM.Title,
                Developer = gameVM.Developer,
                Publisher = gameVM.Publisher,
                ReleaseDate = releaseDate
            };
            await _gameRepo.CreateGameAsync(game);
            await _gameRepo.CreateGameGenreAsync(game, gameVM.selectedGenreId);
            return StatusCode(201);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _gameRepo.DeleteGame(id);
            return NoContent();
        }

        [HttpPost("purchase/{gameId}")]
        public async Task<IActionResult> Purchase(int gameId)
        {
            string? userId = _user.GetUserId(User);

            if (userId == null)
            {
                return BadRequest();
            }

            await _gameRepo.CreateUserGame(gameId, userId);
            return StatusCode(201);

        }
    }
}
