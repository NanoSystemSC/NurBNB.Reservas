using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Infrastructure.EF.ReadModel
{
    [Table("CancelarReserva")]
    internal class CancelarReadModel
    {
        [Key]
        [Column("ID_CancelarReserva")]
        public Guid ID_CancelarReserva { get; set; }

        [Column("ReservaID")]
        [Required]
        public Guid ReservaID { get;  set; }

        [Column("FechaCancelacion")]
        [Required]
        public DateTime FechaCancelacion { get;  set; }

        [Column("Aplica_Descuento")]
        [Required]
        public bool Aplica_Descuento { get;  set; }

        [Column("Motivo")]
        [Required]
        [StringLength(100)]
        public string Motivo { get; private set; }

        [Column("Porcentaje_Devolucion", TypeName = "decimal(18,2)")]
        [Required]
        public decimal Porcentaje_Devolucion { get;  set; }


    }
}
