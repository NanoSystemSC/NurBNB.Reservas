using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.Domain.Model.Reservas;
using NurBNB.Reservas.Domain.Repositories;
using NurBNB.Reservas.Infrastructure.EF.Context;

namespace NurBNB.Reservas.Infrastructure.EF.Repositories
{
    internal class ReservaRepository : IReservaRepository
    {
        private readonly WriteDbContext _context;

        public ReservaRepository(WriteDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Reserva obj)
        {
           
        }

        public Task<Reserva?> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Reserva reserva)
        {
            throw new NotImplementedException();
        }
    }
}
