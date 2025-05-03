namespace WebDevProject.Models
{
    public class Group
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required User Owner { get; set; }
        public required List<User> Members { get; set; }
        public string? Genre { get; set; }
        public string? Franchise { get; set; }
    }
}
