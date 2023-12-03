using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NurBNB.Reservas.Domain.Factories;
using NurBNB.Reservas.Domain.Model.Reservas;
using NurBNB.Reservas.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Test.Domain.Factories
{
	public class PropiedaFactoryTest
	{
		[Fact]
		public void CrearPropiedadTest()
		{
			string propietario_ID = "ID";
			string titulo = "Titulo";
			PrecioValue precio = 999;
			string detalle = "Detalle";
			string ubicacion = "ubicacoin";

			PropiedadFactory huespedFactory = new PropiedadFactory();

			var expectativa = huespedFactory.Create(propietario_ID, titulo, precio, detalle, ubicacion);

			Assert.Equal(propietario_ID, expectativa.PropietarioID);
			Assert.Equal(titulo, expectativa.Titulo);
			Assert.Equal(precio, expectativa.Precio);
			Assert.Equal(detalle, expectativa.Detalle);
			Assert.Equal(ubicacion, expectativa.ubicacion);
		}
	}

}
