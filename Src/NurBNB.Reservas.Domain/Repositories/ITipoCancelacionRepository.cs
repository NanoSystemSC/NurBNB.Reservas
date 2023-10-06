using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.Domain.Model.Cancelacion;
using NurBNB.Reservas.Domain.Model.Clientes;
using NurBNB.Reservas.Domain.Model.Reservas;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Domain.Repositories
{
    public interface ITipoCancelacionRepository : IRepository<TipoCancelacion, Guid>
    {
        Task UpdateAsync(TipoCancelacion tipoCancelacion);
        Task<TipoCancelacion?> FindByFechaAsync(DateTime FechaCheckIn);
    }
}
