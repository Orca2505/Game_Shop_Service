namespace WebDevProject.Models.ViewModels
{
    public class GameIndexVM
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Developer { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public ICollection<string> Genre { get; set; } = new List<string>();
        public string ReleaseDate { get; set; } = string.Empty;
    }
}
