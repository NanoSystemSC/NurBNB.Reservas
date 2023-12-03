using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.SharedKernel.Core;
using NurBNB.Reservas.SharedKernel.ValueObjects;

namespace NurBNB.Reservas.Domain.ValueObjects
{
	public record PrecioValue : ValueObject
	{
		public decimal Value { get; init; }

		public PrecioValue(decimal value)
		{
			if (value < 0)
			{
				throw new ArgumentException("El precio no puede ser negativo");
			}

			Value = value;
		}

		public static implicit operator decimal(PrecioValue costo) => costo.Value;

		public static implicit operator PrecioValue(decimal value) => new(value);
	}
}
