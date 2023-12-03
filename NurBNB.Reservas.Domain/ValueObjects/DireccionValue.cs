using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.SharedKernel.Core;
using NurBNB.Reservas.SharedKernel.ValueObjects;

namespace NurBNB.Reservas.Domain.ValueObjects
{
	public record DireccionValue : ValueObject
	{
		public string Calle { get; init; }
		public string Ciudad { get; init; }
		public string Pais { get; init; }
		public string CodigoPostal { get; init; }

		public DireccionValue(string calle, string ciudad, string pais, string codigoPostal)
		{
			if (string.IsNullOrWhiteSpace(calle))
			{
				throw new BussinessRuleValidationException("Cantidad value cannot be negative");
			}
			Calle = calle;

			if (string.IsNullOrWhiteSpace(ciudad))
			{
				throw new BussinessRuleValidationException("Cantidad value cannot be negative");
			}
			Ciudad = ciudad;

			if (string.IsNullOrWhiteSpace(pais))
			{
				throw new BussinessRuleValidationException("Cantidad value cannot be negative");
			}
			Pais = pais;

			if (string.IsNullOrWhiteSpace(codigoPostal))
			{
				throw new BussinessRuleValidationException("Cantidad value cannot be negative");
			}
			CodigoPostal = codigoPostal;


		}

	}
}
