using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.Domain.Model.Reservas;

namespace NurBNB.Reservas.Domain.Factories
{
    public class ReservaFactory : IReservaFactory
    {
        public Reserva Create(Guid huespedID, Guid propiedadID, DateTime fechaCheckIn, DateTime fechaCheckOut, string motivo)
        {
            return new Reserva(huespedID, propiedadID, fechaCheckIn, fechaCheckOut, motivo);
        }
    }
}
