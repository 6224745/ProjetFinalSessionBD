using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal_6224745.Models;

[Table("Agre", Schema = "Appareil")]
[Index("Nom", Name = "UQ_Agre_Nom", IsUnique = true)]
public partial class Agre
{
    [Key]
    [Column("AgreID")]
    public int AgreId { get; set; }

    [StringLength(50)]
    public string Nom { get; set; } = null!;

    [InverseProperty("Agre")]
    public virtual ICollection<Mouvement> Mouvements { get; set; } = new List<Mouvement>();

    [InverseProperty("Agres")]
    public virtual ICollection<Performance> Performances { get; set; } = new List<Performance>();
}
