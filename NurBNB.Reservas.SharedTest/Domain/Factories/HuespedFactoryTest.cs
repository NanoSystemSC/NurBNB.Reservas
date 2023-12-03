using NurBNB.Reservas.Domain.Factories;
using NurBNB.Reservas.Domain.Model.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Test.Domain.Factories
{
	public class HuespedFactoryTest
	{
		[Fact]
		public void CrearHuespedFactoryTest()
		{
			string nombre = "Fernando";
			string apellidos = "Sandagorda";
			string telefono = "98432132";
			string nrodoc = "540321";
			string email = "asdas@asdsad.com";
			string calle = "caleeee";
			string ciudad = "ciudada";
			string pais = "rusia";
			string codigo_postal = "9876";

			HuespedFactory huespedFactory = new HuespedFactory();

			var expectativa = huespedFactory.Create(nombre, apellidos, telefono, nrodoc, email, calle, ciudad, pais, codigo_postal);

			Assert.Equal(nombre, expectativa.Nombre);
			Assert.Equal(apellidos, expectativa.Apellidos);
			Assert.Equal(telefono, expectativa.Telefono);
			Assert.Equal(nrodoc, expectativa.NroDoc);
			Assert.Equal(email, expectativa.Email);
			Assert.Equal(calle, expectativa.Calle);
			Assert.Equal(ciudad, expectativa.Ciudad);
			Assert.Equal(pais, expectativa.Pais);
			Assert.Equal(codigo_postal, expectativa.CodigoPostal);


		}
	}
}
