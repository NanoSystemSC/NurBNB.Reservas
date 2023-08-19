using NurBNB.Reservas.SharedKernel.Rules;
using NurBNB.Reservas.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.SharedTest.Rules
{
    public class NotNullRuleTest
    {
        [Theory]
        [InlineData(null, false)]
        [InlineData("Fernando", true)]
        public void ObjectoNulo(string valorEsperado, bool resultadoEsperado)
        {
            NotNullRule rule = new NotNullRule(valorEsperado);
            bool esValido = rule.IsValid();

            Assert.Equal(resultadoEsperado, esValido);
        }
    }
}
