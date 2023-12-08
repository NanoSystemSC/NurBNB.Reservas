using NurBNB.Reservas.Domain.Model.Estados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Test.Domain.Model.Estados
{
    public class TipoEstadoTest
    {
	   [Fact]
	   public void TipoEstadosTest()
	   {

		  TipoEstadoReserva tipoEstado = TipoEstadoReserva.Reservado;

		  Assert.Equal(TipoEstadoReserva.Reservado, tipoEstado);
	   }
    }
}
