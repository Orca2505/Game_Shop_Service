using System.ComponentModel.DataAnnotations;

namespace WebDevProject.Models.ViewModels
{
    public class GameCreateVM
    {
        public string Title { get; set; } = string.Empty;
        public string Developer { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public string ReleaseDate { get; set; } = string.Empty;
        public List<int> selectedGenreId { get; set; } = new List<int>();
        public List<Genre>? AllGenres { get; set; }
    }
}
