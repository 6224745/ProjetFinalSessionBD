using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal_6224745.Models;

[Table("Mouvement", Schema = "Appareil")]
public partial class Mouvement
{
    [Key]
    [Column("MouvementID")]
    public int MouvementId { get; set; }

    [StringLength(50)]
    public string? Nom { get; set; }

    [StringLength(1)]
    public string? Difficulte { get; set; }

    [Column(TypeName = "decimal(3, 1)")]
    public decimal Valeur { get; set; }

    [StringLength(255)]
    public string Description { get; set; } = null!;

    [Column("AgreID")]
    public int AgreId { get; set; }

    [ForeignKey("AgreId")]
    [InverseProperty("Mouvements")]
    public virtual Agre Agre { get; set; } = null!;

    [InverseProperty("Mouvement")]
    public virtual ICollection<Performance> Performances { get; set; } = new List<Performance>();
}
