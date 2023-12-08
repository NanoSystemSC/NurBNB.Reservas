using NurBNB.Reservas.SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Test.Rules
{
    public class NotNegativeRuleTest
    {
	   [Theory]
	   [InlineData(-5, false)]
	   [InlineData(6, true)]
	   public void ObejtoNegativo(decimal valorEsperado, bool resultadoEsperado)
	   {
		  NotNegativeRule rule = new NotNegativeRule(valorEsperado);

		  bool esValido = rule.IsValid();

		  Assert.Equal(resultadoEsperado, esValido);

	   }
    }
}
