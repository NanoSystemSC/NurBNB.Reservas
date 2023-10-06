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
        CancelarReserva Create(Guid reservaID, DateTime fechaCancelacion, bool aplica_Descuento, decimal porcentaje_Devolucion, string motivo);
    }
}
