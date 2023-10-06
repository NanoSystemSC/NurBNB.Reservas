using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NurBNB.Reservas.Domain.Model.Clientes;
using NurBNB.Reservas.Domain.Repositories;
using NurBNB.Reservas.Infrastructure.EF.Context;

namespace NurBNB.Reservas.Infrastructure.EF.Repositories
{
    [ExcludeFromCodeCoverage]
    internal class HuespedRepository : IHuespedRepository
    {
        private readonly WriteDbContext _context;

        public HuespedRepository(WriteDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Huesped obj)
        {
            await _context.Huesped.AddAsync(obj);
        }

        public async Task<Huesped?> FindByIdAsync(Guid id)
        {
            return await _context.Huesped.
                SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Huesped huesped)
        {
            _context.Huesped.Update(huesped);
            return Task.CompletedTask;
        }
    }
}
