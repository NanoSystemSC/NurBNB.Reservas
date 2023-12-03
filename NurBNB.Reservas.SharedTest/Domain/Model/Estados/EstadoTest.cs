using NurBNB.Reservas.Domain.Model.Estados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Test.Domain.Model.Estados
{
	public class EstadoTest
	{

		[Fact]
		public void EstadosTest()
		{
			Guid ID_Estado = Guid.NewGuid();
			int TipoEstado = 3;
			string Descripcion = "Estado 1";

			Estado estado = new Estado(ID_Estado, TipoEstado, Descripcion);

			Assert.Equal(ID_Estado, estado.IDEstado);
			Assert.Equal(TipoEstado, estado.TipoEstado);
			Assert.Equal(Descripcion, estado.Descripcion);
		}
	}
}
