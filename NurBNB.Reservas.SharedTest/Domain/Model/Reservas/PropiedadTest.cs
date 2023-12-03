using NurBNB.Reservas.Domain.Model.Reservas;
using NurBNB.Reservas.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Test.Domain.Model.Reservas
{
	public class PropiedadTest
	{
		[Fact]
		public void CrearPropiedadTest()
		{
			string propietario_ID = "ID";
			string titulo = "Titulo";
			PrecioValue precio = 999;
			string detalle = "Detalle";
			string ubicacion = "ubicacoin";

			Propiedad propiedad = new Propiedad(propietario_ID, titulo, precio, detalle, ubicacion);

			Assert.Equal(propietario_ID, propiedad.PropietarioID);
			Assert.Equal(titulo, propiedad.Titulo);
			Assert.Equal(precio, propiedad.Precio);
			Assert.Equal(detalle, propiedad.Detalle);
			Assert.Equal(ubicacion, propiedad.ubicacion);
		}
	}
}
