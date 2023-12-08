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
    public class ReservaRepository : IReservaRepository
    {
	   private readonly WriteDbContext _context;


	   public ReservaRepository(WriteDbContext context)
	   {
		  _context = context;
	   }

	   public ReservaRepository()
	   {

	   }
	   public async Task CreateAsync(Reserva obj)
	   {
		  await _context.AddAsync(obj);
	   }

	   public async Task<Reserva?> FindByIdAsync(Guid id)
	   {
		  return await _context.Reserva.SingleOrDefaultAsync(p => p.Id == id);
	   }



	   public Task UpdateAsync(Reserva reserva)
	   {
		  _context.Reserva.Update(reserva);
		  return Task.CompletedTask;
	   }
    }
}
