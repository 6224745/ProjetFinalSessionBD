namespace ProjetFinal_6224745.Models
{
    public class MouvementFiltreResult
    {
        public string? NomMouvement { get; set; }
        public string? Difficulte { get; set; } = null!;
        public decimal Valeur { get; set; }
        public string Description { get; set; } = null!;
        public string NomAgre { get; set; } = null!;
    }
}
