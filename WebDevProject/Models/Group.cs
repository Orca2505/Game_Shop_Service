namespace WebDevProject.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int OwnerId { get; set; }
        public string Franchise { get; set; } = string.Empty;
        public ICollection<Genre> AllGenres { get; set; } = new List<Genre>();
        public string Genre = string.Empty;
    }
}
