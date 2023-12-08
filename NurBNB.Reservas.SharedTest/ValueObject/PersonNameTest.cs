using NurBNB.Reservas.Domain.ValueObjects;
using NurBNB.Reservas.SharedKernel.Core;
using NurBNB.Reservas.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Test.ValueObject
{
    public class PersonNameTest
    {
	   [Theory]
	   //[InlineData("12345678901")]
	   [InlineData("calle2")]
	   public void NombreValido(string nombre)
	   {
		  PersonNameValue aVerificar = new PersonNameValue(nombre);

		  Assert.Equal(nombre, aVerificar.Name);

	   }

	   [Fact]
	   public void NombreNoValido()
	   {
		  string nombre = "12345678901";
		  Assert.Throws<BussinessRuleValidationException>(() => new PersonNameValue(nombre));
	   }

	   [Fact]
	   public void DeStringAPersonName()
	   {
		  string valorEsperado = "Fernando";
		  PersonNameValue valorAverificar = (PersonNameValue)valorEsperado;

		  Assert.Equal(valorEsperado, valorAverificar.Name);
	   }

	   [Fact]
	   public void DePersonNameAString()
	   {
		  PersonNameValue valorAverificar = new PersonNameValue("JUANN");
		  string valorConvertido = valorAverificar;

		  Assert.Equal(valorAverificar.Name, valorConvertido);
	   }

    }
}
