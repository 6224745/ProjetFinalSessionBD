using ProjetFinal_6224745.Models;

namespace ProjetFinal_6224745.ViewModels
{
    public class AgresAfficheViewModel
    {
        public List<VwDetailAgre> DetailAgre { get; set; } = null!;
        public Agre Agres { get; set; } = null!;
        public string? AfficheContent { get; set; }
    }
}
