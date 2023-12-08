using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NurBNB.Reservas.Domain.Model.Cancelacion;
using NurBNB.Reservas.Domain.Model.Estados;
using NurBNB.Reservas.Domain.Model.Reservas;
using NurBNB.Reservas.Domain.Repositories;
using NurBNB.Reservas.Infrastructure.EF.Context;

namespace NurBNB.Reservas.Infrastructure.EF.Repositories
{
    [ExcludeFromCodeCoverage]
    internal class CancelarReservaRepository : ICancelarReservaRepository
    {
	   private readonly WriteDbContext _context;
	   //private readonly WriteDbContext _reservaRepository;
	   private readonly IReservaRepository _reservaRepository;
	   private readonly ITipoCancelacionRepository _tipoCancelacionRepository;
	   //private readonly IConfiguration _option;

	   public CancelarReservaRepository(WriteDbContext context, IReservaRepository reservaRepository, ITipoCancelacionRepository tipoCancelacion)
	   {
		  _context = context;
		  _reservaRepository = reservaRepository;
		  _tipoCancelacionRepository = tipoCancelacion;
	   }

	   public async Task CreateAsync(CancelarReserva obj)
	   {
		  var _reserva = await _reservaRepository.FindByIdAsync(obj.ReservaID);

		  if (_reserva == null)
		  {
			 throw new ArgumentException("No se encontro una reserva con ese código.");
		  }

		  var _tipoCancelacion = await _tipoCancelacionRepository.FindByFechaAsync(_reserva.FechaCheckIn);
		  if (_tipoCancelacion == null)
		  {
			 throw new ArgumentException("No se encontro un Tipo de Cancelación.");
		  }

		  obj.AplicaDescuento = _tipoCancelacion != null;
		  obj.PorcentajeDevolucion = _tipoCancelacion.PorcentajeDevolucion;

		  await _context.CancelarReservas.AddAsync(obj);

		  updateStatusReserve(_reserva);

	   }

	   [ExcludeFromCodeCoverage]
	   private void updateStatusReserve(Reserva reserva)
	   {
		  reserva.Estado = TipoEstadoReserva.Cancelado;
		  _context.Reserva.Update(reserva);
	   }


	   public async Task<CancelarReserva?> FindByIdAsync(Guid id)
	   {
		  return await _context.CancelarReservas.SingleOrDefaultAsync(p => p.Id == id);
	   }

	   public Task UpdateAsync(CancelarReserva cancelar)
	   {
		  _context.CancelarReservas.Update(cancelar);
		  return Task.CompletedTask;
	   }
    }
}
