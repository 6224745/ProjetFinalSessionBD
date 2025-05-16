using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal_6224745.Models;

[Keyless]
public partial class VwDetailAgre
{
    [Column("AgreID")]
    public int AgreId { get; set; }

    [StringLength(50)]
    public string Nom { get; set; } = null!;

    [StringLength(1)]
    public string? Difficulte { get; set; }

    [Column("Nombre de mouvement par difficult�")]
    public int? NombreDeMouvementParDifficult { get; set; }
}
