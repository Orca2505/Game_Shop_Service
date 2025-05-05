namespace WebDevProject.Models
{
    public class User
    {
        public required string Id { get; set; }
        public string user_name { get; set; } = String.Empty;
        public ICollection<UserGame> games { get; set; } = new List<UserGame>();
    }
}
