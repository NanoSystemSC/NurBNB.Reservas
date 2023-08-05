using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.Domain.Model.Estados;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Domain.Model.Reservas
{
    public class Reserva : Entity
    {
        //public Guid ReservaID { get; private set; }
        public Guid HuespedID { get; private set; }
        public Guid PropiedadID { get; private set; }
        public DateTime FechaCheckIn { get; private set; }
        public DateTime FechaCheckOut { get; private set; }
        public DateTime FechaRegistro { get; private set; }
        public TipoEstadoReserva Estado { get; private set; }

        public Reserva(Guid huespedID, Guid propiedadID, DateTime fechaCheckIn, DateTime fechaCheckOut)
        {
            Id = Guid.NewGuid();
            HuespedID = huespedID;
            PropiedadID = propiedadID;
            FechaCheckIn = fechaCheckIn;
            FechaCheckOut = fechaCheckOut;
            FechaRegistro = DateTime.Now;
            Estado = TipoEstadoReserva.Solicitado;
        }

        private Reserva() { }
    }
}
