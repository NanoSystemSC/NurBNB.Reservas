using NurBNB.Reservas.Domain.Factories;
using NurBNB.Reservas.Domain.Model.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Test.Domain.Factories
{
    public class ReservaFactoryTest
    {
        [Fact]
        public void CrearReservaFactoryTest()
        {
            Guid HuespedID = Guid.NewGuid();
            Guid PropiedadID = Guid.NewGuid();
            DateTime FechaCheckIn = DateTime.Now;
            DateTime FechaCheckOut = DateTime.Now.AddDays(2);
            string Motivo = "Viaje programado";

            
            ReservaFactory reservaFactory = new ReservaFactory();

            var expectativa = reservaFactory.Create(HuespedID, PropiedadID, FechaCheckIn, FechaCheckOut, Motivo);

            Assert.Equal(HuespedID, expectativa.HuespedID);
            Assert.Equal(PropiedadID, expectativa.PropiedadID);
            Assert.Equal(FechaCheckIn, expectativa.FechaCheckIn);
            Assert.Equal(FechaCheckOut, expectativa.FechaCheckOut);
            Assert.Equal(Motivo, expectativa.Motivo);

        }
    }
}
