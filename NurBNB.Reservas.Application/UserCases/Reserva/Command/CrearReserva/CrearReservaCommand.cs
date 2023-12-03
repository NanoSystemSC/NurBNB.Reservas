using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NurBNB.Reservas.Domain.Model.Estados;

namespace NurBNB.Reservas.Application.UserCases.Reserva.Command.CrearReserva
{
	public class CrearReservaCommand : IRequest<Guid>
	{
		public Guid HuespedID { get; set; }
		public Guid PropiedadID { get; set; }
		public DateTime FechaCheckIn { get; set; }
		public DateTime FechaCheckOut { get; set; }
		//public DateTime FechaRegistro { get;  set; }
		public string Motivo { get; set; }
		//public string Estado { get;  set; }
	}
}
