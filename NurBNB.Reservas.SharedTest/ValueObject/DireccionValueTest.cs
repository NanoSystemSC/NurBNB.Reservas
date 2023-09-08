using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class DireccionValueTest
    {
        [Theory]
        [InlineData("calle","ciudad","pais", "codigoPostal")]
        [InlineData("calle2", "ciudad2", "pais2", "codigoPostal2")]
        public void TodosLosValoresdeDireccion(string calle, string ciudad, string pais, string codigo_postal)
        {
            //int valorEsperado = 10;
            DireccionValue valorAverificar = new DireccionValue(calle, ciudad, pais, codigo_postal);

            Assert.Equal(calle, valorAverificar.Calle);
            Assert.Equal(ciudad, valorAverificar.Ciudad);
            Assert.Equal(pais, valorAverificar.Pais);
            Assert.Equal(codigo_postal, valorAverificar.Codigo_postal);            
        }

        [Fact]
        public void CalleVacia()
        {
           
            Assert.Throws<BussinessRuleValidationException>(() => new DireccionValue("", "ciudad", "pais", "codigo_postal"));
        }

        [Fact]
        public void CiudadVacia()
        {

            Assert.Throws<BussinessRuleValidationException>(() => new DireccionValue("Calle", "   ", "pais", "codigo_postal"));
        }

        [Fact]
        public void PaisVacia()
        {

            Assert.Throws<BussinessRuleValidationException>(() => new DireccionValue("Calle", "ciudadd", "", "codigo_postal"));
        }

        [Fact]
        public void CodigoPostalVacia()
        {

            Assert.Throws<BussinessRuleValidationException>(() => new DireccionValue("Calle", "ciudadd", "Paiss", ""));
        }
    }
}
