using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.Domain.Model.Cancelacion;
using NurBNB.Reservas.Domain.Model.Clientes;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Domain.Repositories
{
    public interface ICancelarReservaRepository : IRepository<CancelarReserva, Guid>
    {
	   Task UpdateAsync(CancelarReserva cancelar);
    }
}
