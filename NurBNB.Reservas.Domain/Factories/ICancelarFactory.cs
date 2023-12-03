using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.Domain.Model.Cancelacion;

namespace NurBNB.Reservas.Domain.Factories
{
	public interface ICancelarFactory
	{
		CancelarReserva Create(Guid reservaID, DateTime fechaCancelacion, bool aplicaDescuento, decimal porcentajeDevolucion, string motivo);
	}
}
