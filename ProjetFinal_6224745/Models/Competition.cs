using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal_6224745.Models;

[Table("Competition", Schema = "Performances")]
[Index("Nom", Name = "UQ_Competition_Nom", IsUnique = true)]
public partial class Competition
{
    [Key]
    [Column("CompetitionID")]
    public int CompetitionId { get; set; }

    [StringLength(50)]
    public string Nom { get; set; } = null!;

    public DateOnly Date { get; set; }

    [StringLength(50)]
    public string Lieu { get; set; } = null!;

    [InverseProperty("Competition")]
    public virtual ICollection<Performance> Performances { get; set; } = new List<Performance>();
}
