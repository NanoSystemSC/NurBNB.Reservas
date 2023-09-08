using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NurBNB.Reservas.Domain.Model.Cancelacion;
using NurBNB.Reservas.Domain.Model.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Test.Domain.Model.Cancelacion
{
    public class CancelarTest
    {
        [Fact]
        public void CrearCancelacionTest()
        {

            Guid ReservaID = Guid.NewGuid();
            DateTime FechaCancelacion = DateTime.Now;
            bool Aplica_Descuento = false;
            string Motivo = "Motivooo";
            decimal Porcentaje_Devolucion = 0;

            CancelarReserva cancelar = new CancelarReserva(ReservaID,FechaCancelacion,Aplica_Descuento,Porcentaje_Devolucion,Motivo);

            Assert.Equal(ReservaID, cancelar.ReservaID);
            Assert.Equal(FechaCancelacion, cancelar.FechaCancelacion);
            Assert.Equal(Aplica_Descuento, cancelar.Aplica_Descuento);
            Assert.Equal(Motivo, cancelar.Motivo);
            Assert.Equal(Porcentaje_Devolucion, cancelar.Porcentaje_Devolucion);
        
        }
    }
}
