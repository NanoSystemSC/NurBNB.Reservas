using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Domain.Model.Cancelacion
{
	public class CancelarReserva : AggregateRoot
	{
		public Guid ReservaID { get; private set; }
		public DateTime FechaCancelacion { get; private set; }
		//public bool Aplica_Descuento { get; private set; }
		public bool AplicaDescuento { get; set; }
		public string Motivo { get; private set; }
		public decimal PorcentajeDevolucion { get; set; }


		public CancelarReserva(Guid reservaID, DateTime fechaCancelacion, bool aplicaDescuento, decimal porcentajeDevolucion, string motivo)
		{
			Id = Guid.NewGuid();
			ReservaID = reservaID;
			FechaCancelacion = fechaCancelacion;
			AplicaDescuento = aplicaDescuento;
			PorcentajeDevolucion = porcentajeDevolucion;
			Motivo = motivo;
		}

		[ExcludeFromCodeCoverage]
		private CancelarReserva() { }
	}
}
