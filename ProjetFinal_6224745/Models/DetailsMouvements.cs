namespace ProjetFinal_6224745.Models
{
    public class DetailsMouvements
    {
        public int MouvementID { get; set; }
        public string NomMouvement { get; set; } = null;
        public string Difficulte { get; set; } = null!;
        public decimal Valeur { get; set; }
        public string Description { get; set; } = null!;
        public string NomAgre { get; set; } = null!;
        public int AgreID { get; set; }

    }
}
