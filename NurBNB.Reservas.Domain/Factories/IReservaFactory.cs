using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.Domain.Model.Reservas;

namespace NurBNB.Reservas.Domain.Factories
{
    public interface IReservaFactory
    {
        Reserva Create(Guid huespedID, Guid propiedadID, DateTime fechaCheckIn, DateTime fechaCheckOut, string motivo);
    }
}
