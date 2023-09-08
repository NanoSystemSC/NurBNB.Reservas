using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Infrastructure.EF.ReadModel;

[ExcludeFromCodeCoverage]
[Table("huesped")]
internal class HuespedReadModel
{
    [Key]
    [Column("huespedID")]
    public Guid Id { get; set; }

    [Column("nombres")]
    [StringLength(100)]
    [Required]
    public string Nombre { get; set; }

    [Column("apellidos")]
    [StringLength(100)]
    [Required]
    public string Apellidos { get; set; }

    [Column("telefono")]
    [StringLength(20)]
    [Required]
    public string Telefono { get; set; }

    [Column("nrodoc")]
    [StringLength(10)]
    [Required]
    public string NroDoc { get; set; }

    [Column("email")]
    [StringLength(100)]
    [Required]
    public string Email { get; set; }

    [Column("calle")]
    [StringLength(100)]
    [Required]
    public string Calle { get; set; }

    [Column("ciudad")]
    [StringLength(100)]
    [Required]
    public string Ciudad { get; set; }

    [Column("pais")]
    [StringLength(50)]
    [Required]
    public string Pais { get; set; }

    [Column("codigo_postal")]
    [StringLength(10)]
    public string Codigo_postal { get; set; }
}
