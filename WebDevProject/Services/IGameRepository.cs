using WebDevProject.Models;

namespace WebDevProject.Services
{
    public interface IGameRepository
    {
        Task<Game> CreateGameAsync(Game newGame);
        Task<ICollection<Game>> ReadAllGames();
        Task DeleteGame(int id);
        Task CreateGameGenreAsync(Game game, ICollection<int> genreIds);
        Task<ICollection<string>> GetGameGenres(int gameId);
        Task CreateUserGame(int gameId, string userId);
    }
}
