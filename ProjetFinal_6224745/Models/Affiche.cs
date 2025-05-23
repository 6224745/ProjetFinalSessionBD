using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal_6224745.Models;

[Table("Affiche", Schema = "Appareil")]
[Index("Identifiant", Name = "UC_Appareil_Identifiant", IsUnique = true)]
public partial class Affiche
{
    [Key]
    [Column("AfficheID")]
    public int AfficheId { get; set; }

    public Guid Identifiant { get; set; }

    [Column("AgreID")]
    public int AgreId { get; set; }

    public byte[]? AfficheContent { get; set; }
}
