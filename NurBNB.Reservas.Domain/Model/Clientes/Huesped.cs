using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.Domain.ValueObjects;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Domain.Model.Clientes
{
	public class Huesped : AggregateRoot
	{
		// no expongo de manera publica la posiblidad de modificar
		// todos los seter.. deben ser privados... si quiero modificar.. expongo un metodo de modificar

		//public Guid ID_Huesped { get;  set; }
		public string Nombre { get; private set; }
		public string Apellidos { get; private set; }
		public string Telefono { get; private set; }
		public string NroDoc { get; private set; }
		public string Email { get; private set; }

		//public DireccionValue Direccion { get; set; }
		public string Calle { get; private set; }
		public string Ciudad { get; private set; }
		public string Pais { get; private set; }
		public string CodigoPostal { get; private set; }


		//internal Huesped(Guid id, string nombre, string apellidos, string telefono, string nrodoc, string email, DireccionValue direccion)
		//internal Huesped(string nombre, string apellidos, string telefono, string nrodoc, string email, DireccionValue direccion)
		public Huesped(string nombre, string apellidos, string telefono, string nrodoc, string email, string calle, string ciudad, string pais, string codigoPostal)
		{
			Id = Guid.NewGuid();
			Nombre = nombre;
			Apellidos = apellidos;
			Telefono = telefono;
			NroDoc = nrodoc;
			Email = email;
			//Direccion = direccion;
			Calle = calle;
			Ciudad = ciudad;
			Pais = pais;
			CodigoPostal = codigoPostal;
		}

		[ExcludeFromCodeCoverage]
		private Huesped() { }

	}
}
