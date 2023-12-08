using NurBNB.Reservas.SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Test.Rules
{
    public class StringNotNullOrEmptyRuleTest
    {
	   [Theory]
	   [InlineData(null, false)]
	   [InlineData("Fernando", true)]
	   public void CadenaNulo(string valorEsperado, bool resultadoEsperado)
	   {
		  StringNotNullOrEmptyRule rule = new StringNotNullOrEmptyRule(valorEsperado);

		  bool esValido = rule.IsValid();

		  Assert.Equal(resultadoEsperado, esValido);
		  Assert.Contains("null", rule.Message);

	   }


    }
}
