using Microsoft.EntityFrameworkCore;
using WebDevProject.Models;

namespace WebDevProject.Services
{
    public class DbGameRepository(ApplicationDbContext db) : IGameRepository
    {
        private readonly ApplicationDbContext _db = db;
        public async Task<Game> CreateGameAsync(Game newGame)
        {
            await _db.games.AddAsync(newGame);
            await _db.SaveChangesAsync();
            return newGame;
        }

        public async Task<ICollection<Game>> ReadAllGames()
        {
            return await _db.games.Include(g => g.Genre).ThenInclude(gg => gg.Genre).ToListAsync();
        }
        public async Task DeleteGame(int id)
        {
            Game? gameToDelete = await _db.games.FirstOrDefaultAsync(x => x.Id == id);
            if (gameToDelete != null)
            {
                _db.games.Remove(gameToDelete);
                await _db.SaveChangesAsync();
            }

        }
        public async Task CreateGameGenreAsync(Game game, ICollection<int> genreIds)
        {
            foreach (int genreId in genreIds)
            {
                Genre? genre = await _db.Genre.FirstOrDefaultAsync(x => x.Id == genreId);
                if (genre != null)
                {
                    GameGenre newGameGenre = new GameGenre
                    {
                        Game = game,
                        Genre = genre
                    };
                    game.Genre.Add(newGameGenre);
                    genre.gameGenres.Add(newGameGenre);
                }
            }
            await _db.SaveChangesAsync();

        }

        public async Task<ICollection<string>> GetGameGenres(int gameId)
        {
            var gameGenres = await _db.gameGenre.ToListAsync();
            List<string> genreString = new List<string>();
            List<Genre> genres = gameGenres.Where(x => x.Game.Id == gameId).Select(x => x.Genre).ToList();
            foreach (Genre genre in genres)
            {
                genreString.Add(genre.Name);
            }

            return genreString;
        }
    }
}
