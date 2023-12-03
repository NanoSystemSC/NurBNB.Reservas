using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.Domain.Model.Clientes;

namespace NurBNB.Reservas.Domain.Factories
{
	public interface IHuespedFactory
	{
		Huesped Create(string nombre, string apellidos, string telefono, string nrodoc, string email, string calle, string ciudad, string pais, string codigoPostal);
	}
}
