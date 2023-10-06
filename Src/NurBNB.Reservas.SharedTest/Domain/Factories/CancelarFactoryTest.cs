using NurBNB.Reservas.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Test.Domain.Factories
{
    public class CancelarFactoryTest
    {

        [Fact]
        public void CrearCancelarFactoryTest()
        {
            Guid reservaID = Guid.NewGuid();
            DateTime fechaCancelacion = DateTime.Now;
            bool aplica_Descuento = false;
            decimal porcentaje_Devolucion = 0;
            string motivo = "Motivo";


            CancelarFactory cancelar = new CancelarFactory();
            var expectativa = cancelar.Create(reservaID, fechaCancelacion, aplica_Descuento, porcentaje_Devolucion, motivo);

            Assert.Equal(reservaID, expectativa.ReservaID);
            Assert.Equal(fechaCancelacion, expectativa.FechaCancelacion);
            Assert.Equal(aplica_Descuento, expectativa.Aplica_Descuento);
            Assert.Equal(porcentaje_Devolucion, expectativa.Porcentaje_Devolucion);
            Assert.Equal(motivo, expectativa.Motivo);

        }
    }
}
