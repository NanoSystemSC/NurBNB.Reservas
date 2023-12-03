using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.Domain.Model.Reservas;

namespace NurBNB.Reservas.Domain.Factories
{
	public class PropiedadFactory : IPropiedadFactory
	{
		public Propiedad Create(string propietario_ID, string titulo, decimal precio, string detalle, string ubicacion)
		{
			return new Propiedad(propietario_ID, titulo, precio, detalle, ubicacion);
		}
	}
}
