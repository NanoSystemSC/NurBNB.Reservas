using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Infrastructure.EF.ReadModel
{
	[ExcludeFromCodeCoverage]
	[Table("TipoCancelacion")]
	internal class TipoCancelacionReadModel
	{

		[Key]
		[Column("ID_TipoCancelacion")]
		public Guid ID_TipoCancelacion { get; set; }

		[Column("Descripcion")]
		[StringLength(100)]
		[Required]
		public string Descripcion { get; set; }

		[Column("Dia_Ini")]
		[Required]
		public int Dia_Ini { get; set; }

		[Column("Dia_Fin")]
		[Required]
		public int Dia_Fin { get; set; }

		[Column("Porcentaje_Devolucion")]
		[Required]
		public decimal PorcentajeDevolucion { get; set; }
	}
}
