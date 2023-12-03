using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NurBNB.Reservas.Application.UserCases.CancelarReserva.Command.CrearReserva
{
	public class CrearCancelacionCommand : IRequest<Guid>
	{
		public Guid ReservaID { get; set; }
		//public DateTime FechaCancelacion { get;  set; }
		//public bool Aplica_Descuento { get;  set; }
		//public decimal Porcentaje_Devolucion { get;  set; }

		public string Motivo { get; set; }
	}
}
