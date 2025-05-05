using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal_6224745.Models;

[Table("Gymnaste", Schema = "Performances")]
public partial class Gymnaste
{
    [Key]
    [Column("GymnasteID")]
    public int GymnasteId { get; set; }

    [StringLength(50)]
    public string Nom { get; set; } = null!;

    [StringLength(50)]
    public string Prenom { get; set; } = null!;

    public DateOnly DateNaissance { get; set; }

    [StringLength(50)]
    public string Pays { get; set; } = null!;

    [Column("NBMedailles")]
    public int Nbmedailles { get; set; }

    [InverseProperty("Gymnaste")]
    public virtual ICollection<Performance> Performances { get; set; } = new List<Performance>();
}
