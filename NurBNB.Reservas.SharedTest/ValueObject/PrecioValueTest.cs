using NurBNB.Reservas.Domain.ValueObjects;
using NurBNB.Reservas.SharedKernel.Core;
using NurBNB.Reservas.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Test.ValueObject
{
	[ExcludeFromCodeCoverage]
	public class PrecioValueTest
	{
		[Theory]
		[InlineData(0)]
		[InlineData(20)]
		public void ValorMayorIgualACero(decimal valorEsperado)
		{
			//int valorEsperado = 10;
			NurBNB.Reservas.Domain.ValueObjects.PrecioValue valorAverificar = new NurBNB.Reservas.Domain.ValueObjects.PrecioValue(valorEsperado);

			Assert.Equal(valorEsperado, valorAverificar.Value);
		}

		[Fact]
		public void ValorMenorACero()
		{
			int valorEsperado = -5;

			Assert.Throws<ArgumentException>(() => new NurBNB.Reservas.Domain.ValueObjects.PrecioValue(valorEsperado));
		}

		[Fact]
		public void DeDecimalAPrecio()
		{
			int valorEsperado = 5;
			NurBNB.Reservas.Domain.ValueObjects.PrecioValue valorAverificar = (NurBNB.Reservas.Domain.ValueObjects.PrecioValue)valorEsperado;

			Assert.Equal(valorEsperado, valorAverificar.Value);
		}

		[Fact]
		public void DePrecioADecimal()
		{
			NurBNB.Reservas.Domain.ValueObjects.PrecioValue valorAverificar = new NurBNB.Reservas.Domain.ValueObjects.PrecioValue(5);
			decimal valorConvertido = valorAverificar;

			Assert.Equal(valorAverificar.Value, valorConvertido);
		}
	}
}
