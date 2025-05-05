namespace WebDevProject.Models
{
    public class UserGame
    {
        public int Id { get; set; }

        public required string userId { get; set; }
        public User? User { get; set; }

        public int gameId { get; set; }
        public Game? Game { get; set; }
    }
}
