using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.Domain.Model.Cancelacion;

namespace NurBNB.Reservas.Domain.Factories
{
	public class CancelarFactory : ICancelarFactory
	{
		public CancelarReserva Create(Guid reservaID, DateTime fechaCancelacion, bool aplica_Descuento, decimal porcentaje_Devolucion, string motivo)
		{
			return new CancelarReserva(reservaID, fechaCancelacion, aplica_Descuento, porcentaje_Devolucion, motivo);
		}
	}
}
