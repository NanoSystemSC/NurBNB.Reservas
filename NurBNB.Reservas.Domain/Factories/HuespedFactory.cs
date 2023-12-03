using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.Domain.Model.Clientes;

namespace NurBNB.Reservas.Domain.Factories
{
	public class HuespedFactory : IHuespedFactory
	{
		public Huesped Create(string nombre, string apellidos, string telefono, string nrodoc, string email, string calle, string ciudad, string pais, string codigo_postal)
		{
			return new Huesped(nombre, apellidos, telefono, nrodoc, email, calle, ciudad, pais, codigo_postal);
		}
	}
}
