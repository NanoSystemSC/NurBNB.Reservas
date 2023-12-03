using NurBNB.Reservas.Domain.Model.Cancelacion;
using NurBNB.Reservas.Domain.Model.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Test.Domain.Model.Cancelacion
{
	public class TipoCancelacionTest
	{
		[Fact]
		public void TipoCancelarTest()
		{
			string Descripcion = "Descripcion Tipo Cancelacion";
			int Dia_Ini = 1;
			int Dia_Fin = 2;
			decimal PorcentajeDevolucion = 5;

			TipoCancelacion tipo = new TipoCancelacion(Descripcion, Dia_Ini, Dia_Fin, PorcentajeDevolucion);

			Assert.Equal(Descripcion, tipo.Descripcion);
			Assert.Equal(Dia_Ini, tipo.DiaIni);
			Assert.Equal(Dia_Fin, tipo.DiaFin);
			Assert.Equal(PorcentajeDevolucion, tipo.PorcentajeDevolucion);
		}
	}
}
