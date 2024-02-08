using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using NurBNB.Reservas.Application.Dto.Propiedad;
using NurBNB.Reservas.Application.Dto.Reserva;
using NurBNB.Reservas.Application.UserCases.Propiedad.Query.GetListofPropiedades;
using NurBNB.Reservas.Application.UserCases.Reserva.Query.GetListofReservas;
using NurBNB.Reservas.Domain.Model.Clientes;
using NurBNB.Reservas.Infrastructure.EF.Context;
using NurBNB.Reservas.Infrastructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NurBNB.Reservas.Infrastructure.UseCases.Reserva.Query
{
    internal class GetListOfReservasHandler : IRequestHandler<GetListofReservasDisponiblesQuery, List<ListOfReservaDto>>
    {
	   private readonly DbSet<PropiedadReadModel> propiedades;
	   private readonly DbSet<HuespedReadModel> huespedes;
	   private readonly DbSet<ReservaReadModel> reservas;

	   public GetListOfReservasHandler(ReadDbContext context)
	   {
		  propiedades = context.Propiedad;
		  huespedes = context.Huesped;
		  reservas = context.Reserva;
	   }
	   public async Task<List<ListOfReservaDto>> Handle(GetListofReservasDisponiblesQuery request, CancellationToken cancellationToken)
	   {
		  var propiedad = propiedades.AsNoTracking();
		  var huesped = huespedes.AsNoTracking();
		  var reserva = reservas.AsNoTracking();

		  var _listaReservas = from reserv in reserva
						   join huesp in huesped on reserv.HuespedID.ToString().ToUpper() equals huesp.Id.ToString().ToUpper()
						   join prop in propiedad on reserv.PropiedadID equals prop.Id
						   //where reserv.Estado == request.estadoReserva.
						   select new ListOfReservaDto
						   {
							  IDReserva = reserv.Id.ToString().ToUpper(),
							  HuespedID = reserv.HuespedID.ToString().ToUpper(),
							  PropiedadID = reserv.PropiedadID.ToString().ToUpper(),
							  FechaCheckin = reserv.FechaCheckIn,
							  FechaCheckOut = reserv.FechaCheckOut,
							  FechaRegistro = reserv.FechaRegistro,
							  Motivo = reserv.Motivo,
							  Estado = reserv.Estado,
							  Titulo = prop.Titulo.ToUpper(),
							  Precio = prop.Precio,
							  Detalle = prop.Detalle.ToUpper(),
							  Cliente = huesp.Nombre.ToUpper() + " " + huesp.Apellidos.ToUpper()
						   };

		  if (!string.IsNullOrWhiteSpace(Convert.ToString(request.estadoReserva)) && request.estadoReserva > 0)
		  {
			  _listaReservas = _listaReservas.Where(x => x.Estado == request.estadoReserva.ToString());
		  }

		  return await _listaReservas.ToListAsync(cancellationToken);
	   }
    }
}
