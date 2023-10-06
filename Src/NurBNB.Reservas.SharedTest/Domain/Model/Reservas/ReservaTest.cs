using NurBNB.Reservas.Domain.Model.Estados;
using NurBNB.Reservas.Domain.Model.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Test.Domain.Model.Reservas
{
    public class ReservaTest
    {
        [Fact]
        public void ReservasTest()
        {
            Guid HuespedID = Guid.NewGuid();
            Guid PropiedadID = Guid.NewGuid();
            DateTime FechaCheckIn = DateTime.Now;
            DateTime FechaCheckOut = DateTime.Now.AddDays(2);           
            string Motivo = "Viaje programado";
            
            Reserva reserva = new Reserva(HuespedID, PropiedadID, FechaCheckIn, FechaCheckOut, Motivo);

            Assert.Equal(HuespedID, reserva.HuespedID);
            Assert.Equal(PropiedadID, reserva.PropiedadID);
            Assert.Equal(FechaCheckIn, reserva.FechaCheckIn);
            Assert.Equal(FechaCheckOut, reserva.FechaCheckOut);


        }
    }
}
