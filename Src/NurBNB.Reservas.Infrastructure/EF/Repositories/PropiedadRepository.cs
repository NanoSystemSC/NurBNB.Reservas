using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NurBNB.Reservas.Domain.Model.Reservas;
using NurBNB.Reservas.Domain.Repositories;
using NurBNB.Reservas.Infrastructure.EF.Context;

namespace NurBNB.Reservas.Infrastructure.EF.Repositories
{
    [ExcludeFromCodeCoverage]
    internal class PropiedadRepository : IPropiedadRepository
    {
        private readonly WriteDbContext _context;

        public PropiedadRepository(WriteDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Propiedad obj)
        {
             await _context.Propiedad.AddAsync(obj);
        }

        public async Task<Propiedad?> FindByIdAsync(Guid id)
        {
            return await _context.Propiedad.SingleOrDefaultAsync(p => p.Id == id);
        }

        public Task UpdateAsync(Propiedad propiedad)
        {
            _context.Propiedad.Update(propiedad);
            return Task.CompletedTask;
        }
    }
}
