using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.Domain.Model.Estados;
using NurBNB.Reservas.Domain.Model.Reservas.Events;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Domain.Model.Reservas
{
	public class Reserva : AggregateRoot
	{
		//public Guid ReservaID { get; private set; }
		public Guid HuespedID { get; private set; }
		public Guid PropiedadID { get; private set; }
		public DateTime FechaCheckIn { get; private set; }
		public DateTime FechaCheckOut { get; private set; }
		public DateTime FechaRegistro { get; private set; }
		public string Motivo { get; private set; }
		public TipoEstadoReserva Estado { get; set; }

		public Reserva(Guid huespedID, Guid propiedadID, DateTime fechaCheckIn, DateTime fechaCheckOut, string motivo)
		{
			Id = Guid.NewGuid();
			HuespedID = huespedID;
			PropiedadID = propiedadID;
			FechaCheckIn = fechaCheckIn;
			FechaCheckOut = fechaCheckOut;
			FechaRegistro = DateTime.Now;
			Estado = TipoEstadoReserva.Solicitado;
			Motivo = motivo;

			//var obj = new Reserva(huespedID, propiedadID, fechaCheckIn, fechaCheckOut, motivo);
			//AddDomainEvent(new ReservaCreada(
			//       Id,
			//       PropiedadID,
			//       "nombreee"
			//   ));


		}

		public static Reserva Create(Guid huespedID, Guid propiedadID, DateTime fechaCheckIn, DateTime fechaCheckOut, string motivo)
		{
			var obj = new Reserva(huespedID, propiedadID, fechaCheckIn, fechaCheckOut, motivo);
			obj.AddDomainEvent(new ReservaCreada(
					obj.Id,
					obj.PropiedadID,
					"nombreee"
				));
			return obj;
		}


		[ExcludeFromCodeCoverage]
		private Reserva() { }


	}
}
