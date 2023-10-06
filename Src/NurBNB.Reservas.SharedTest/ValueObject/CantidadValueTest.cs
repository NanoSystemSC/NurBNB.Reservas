using NurBNB.Reservas.SharedKernel.Core;
using NurBNB.Reservas.SharedKernel.ValueObjects;
using System.Diagnostics.CodeAnalysis;

namespace NurBNB.Reservas.SharedTest.ValueObject
{
    [ExcludeFromCodeCoverage]
    public class CantidadValueTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(20)]
        public void ValorMayorIgualACero(int valorEsperado)
        {
            //int valorEsperado = 10;
            CantidadValue valorAverificar = new CantidadValue(valorEsperado); 

            Assert.Equal(valorEsperado, valorAverificar.Value);
        }

        [Fact]
        public void ValorMenorACero()
        {
            int valorEsperado = -5;
           
            Assert.Throws<BussinessRuleValidationException>(() =>  new CantidadValue(valorEsperado));
        }

        [Fact]
        public void DeEnteroACantidad()
        {
            int valorEsperado = 5;
            CantidadValue valorAverificar =  (CantidadValue)valorEsperado;

            Assert.Equal(valorEsperado, valorAverificar.Value);
        }

        [Fact]
        public void DeCantidadAEntero()
        {
            CantidadValue valorAverificar = new CantidadValue(5);
            int valorConvertido = valorAverificar;

            Assert.Equal(valorAverificar.Value, valorConvertido);
        }
    }
}