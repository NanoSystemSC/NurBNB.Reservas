using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.Domain.Model.Estados;

namespace NurBNB.Reservas.Infrastructure.EF.ReadModel;

[Table("Reserva")]
internal class ReservaReadModel
{
    [Key]
    [Column("ID_Reserva")]
    public Guid Id { get; set; }

    [Column("Huesped_ID")]
    [Required] 
    public Guid HuespedID { get;  set; }

    [Column("Propiedad_ID")]
    [Required]
    public Guid PropiedadID { get;  set; }

    [Column("FechaCheckin")]
    [Required]
    public DateTime FechaCheckIn { get;  set; }

    [Column("FechaCheckOut")]
    [Required]
    public DateTime FechaCheckOut { get; set; }

    [Column("FechaRegistro")]
    [Required]
    public DateTime FechaRegistro { get;  set; }

    [Column("Motivo")]
    [Required]
    [StringLength(150)]
    public string Motivo { get; set; }

    [Column("Estado")]
    [Required]
    [StringLength(50)]
    public string Estado { get;  set; }
}
