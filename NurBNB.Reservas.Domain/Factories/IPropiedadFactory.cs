using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.Domain.Model.Reservas;

namespace NurBNB.Reservas.Domain.Factories
{
    public interface IPropiedadFactory
    {
	   Propiedad Create(string propietarioID, string titulo, decimal precio, string detalle, string ubicacion);
    }
}
