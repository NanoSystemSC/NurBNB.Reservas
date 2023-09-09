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
   
    public class PrecioValueSharedTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(20)]
        public void ValorMayorIgualACero(decimal valorEsperado)
        {
            //int valorEsperado = 10;
            NurBNB.Reservas.SharedKernel.ValueObjects.PrecioValue valorAverificar = new NurBNB.Reservas.SharedKernel.ValueObjects.PrecioValue(valorEsperado);

            Assert.Equal(valorEsperado, valorAverificar.Value);
        }

        [Fact]
        public void ValorMenorACero()
        {
            int valorEsperado = -5;
            
            Assert.Throws<BussinessRuleValidationException>(() => new NurBNB.Reservas.SharedKernel.ValueObjects.PrecioValue(valorEsperado));
        }

        [Fact]
        public void DeDecimalAPrecio()
        {
            int valorEsperado = 5;
            NurBNB.Reservas.SharedKernel.ValueObjects.PrecioValue valorAverificar = (NurBNB.Reservas.SharedKernel.ValueObjects.PrecioValue)valorEsperado;

            Assert.Equal(valorEsperado, valorAverificar.Value);
        }

        [Fact]
        public void DePrecioADecimal()
        {
            NurBNB.Reservas.SharedKernel.ValueObjects.PrecioValue valorAverificar = new NurBNB.Reservas.SharedKernel.ValueObjects.PrecioValue(5);
            decimal valorConvertido = valorAverificar;

            Assert.Equal(valorAverificar.Value, valorConvertido);
        }
    }
}
