using NurBNB.Reservas.SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Test.Rules
{
    public class NotNullRulesTest
    {
	   [Theory]
	   [InlineData("Fernando", true)]
	   [InlineData(null, false)]
	   public void ObjectosNulo(object valorEsperado, bool resultadoEsperado)
	   {
		  NotNullRule rule = new NotNullRule(valorEsperado);
		  bool esValido = rule.IsValid();

		  Assert.Equal(resultadoEsperado, esValido);
	   }
    }
}
