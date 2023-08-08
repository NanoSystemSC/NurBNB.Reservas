using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NurBNB.Reservas.Domain.Model.Cancelacion;
using NurBNB.Reservas.Domain.Repositories;
using NurBNB.Reservas.Infrastructure.EF.Context;

namespace NurBNB.Reservas.Infrastructure.EF.Repositories
{
    internal class TipoCancelacionRepository : ITipoCancelacionRepository
    {
        private readonly WriteDbContext _context;

        public TipoCancelacionRepository(WriteDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TipoCancelacion obj)
        {
            await _context.TipoCancelacion.AddAsync(obj);
        }

        public async Task<TipoCancelacion?> FindByIdAsync(Guid id)
        {
            return await _context.TipoCancelacion.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<TipoCancelacion?> FindByFechaAsync(DateTime FechaCheckIn)
        {
            var diffOfDates = DateTime.Now - FechaCheckIn;

            return await _context.TipoCancelacion.FirstOrDefaultAsync(x => diffOfDates.Days >= x.Dia_Ini && diffOfDates.Days <= x.Dia_Fin);
        }

        public Task UpdateAsync(TipoCancelacion tipoCancelacion)
        {
            _context.Update(tipoCancelacion);
            return Task.CompletedTask;
        }
    }
}
