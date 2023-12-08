using NurBNB.Reservas.Domain.Model.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Test.Domain.Model.Clientes
{
    public class HuespedTest
    {

	   [Fact]
	   public void CrearHuespedTest()
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

		  Huesped huesped = new Huesped(nombre, apellidos, telefono, nrodoc, email, calle, ciudad, pais, codigo_postal);

		  Assert.Equal(nombre, huesped.Nombre);
		  Assert.Equal(apellidos, huesped.Apellidos);
		  Assert.Equal(telefono, huesped.Telefono);
		  Assert.Equal(nrodoc, huesped.NroDoc);
		  Assert.Equal(email, huesped.Email);
		  Assert.Equal(calle, huesped.Calle);
		  Assert.Equal(ciudad, huesped.Ciudad);
		  Assert.Equal(pais, huesped.Pais);
		  Assert.Equal(codigo_postal, huesped.CodigoPostal);





	   }
    }
}
