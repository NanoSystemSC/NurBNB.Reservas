﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.Domain.Model.Clientes;
using NurBNB.Reservas.Domain.Model.Reservas;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Domain.Repositories
{
	public interface IPropiedadRepository : IRepository<Propiedad, Guid>
	{
		Task UpdateAsync(Propiedad propiedad);
	}
}
