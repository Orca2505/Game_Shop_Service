using System.ComponentModel.DataAnnotations;

namespace WebDevProject.Models
{
    public class Game
    {
        public int Id { get; set; }
        public required string Title { get; set; } = string.Empty;
        public required string Developer { get; set; } = string.Empty;
        public required string Publisher { get; set; } = string.Empty;
        public ICollection<GameGenre> Genre { get; set; } = new List<GameGenre>();

        [DataType(DataType.Date)]
        public required DateOnly ReleaseDate { get; set; }
        public ICollection<UserGame> owners { get; set; } = new List<UserGame>();
    }
}
