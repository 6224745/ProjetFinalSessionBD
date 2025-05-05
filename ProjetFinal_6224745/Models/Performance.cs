using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal_6224745.Models;

[Table("Performance", Schema = "Performances")]
public partial class Performance
{
    [Key]
    [Column("PerformanceID")]
    public int PerformanceId { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public decimal NoteObtenue { get; set; }

    [Column("GymnasteID")]
    public int GymnasteId { get; set; }

    [Column("CompetitionID")]
    public int CompetitionId { get; set; }

    [Column("AgresID")]
    public int AgresId { get; set; }

    [Column("MouvementID")]
    public int? MouvementId { get; set; }

    [ForeignKey("AgresId")]
    [InverseProperty("Performances")]
    public virtual Agre Agres { get; set; } = null!;

    [ForeignKey("CompetitionId")]
    [InverseProperty("Performances")]
    public virtual Competition Competition { get; set; } = null!;

    [ForeignKey("GymnasteId")]
    [InverseProperty("Performances")]
    public virtual Gymnaste Gymnaste { get; set; } = null!;

    [ForeignKey("MouvementId")]
    [InverseProperty("Performances")]
    public virtual Mouvement? Mouvement { get; set; }
}
