using MediatR;
using Microsoft.EntityFrameworkCore;
using NurBNB.Reservas.Application.Dto.Propiedad;
using NurBNB.Reservas.Application.UserCases.Propiedad.Query.GetListofPropiedades;
using NurBNB.Reservas.Application.UserCases.Propiedad.Query.GetPropiedadDisponiblesList;
using NurBNB.Reservas.Infrastructure.EF.Context;
using NurBNB.Reservas.Infrastructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Infrastructure.UseCases.Propiedad.Query
{
    internal class GetListofPropiedadesHandler : IRequestHandler<GetListofPropiedadesQuery, List<ListofPropiedadesDto>>
    {
	   private readonly DbSet<PropiedadReadModel> propiedades;
	   private readonly DbSet<HuespedReadModel> huesped;

	   public GetListofPropiedadesHandler(ReadDbContext context)
	   {
		  propiedades = context.Propiedad;
		  huesped = context.Huesped;
	   }
	   public async Task<List<ListofPropiedadesDto>> Handle(GetListofPropiedadesQuery request, CancellationToken cancellationToken)
	   {
		  var propiedad = propiedades.AsNoTracking();
		  var propietario = huesped.AsNoTracking();

		  var _listaPropiedades = from prop in propiedad
							 join propietarios in propietario on prop.Propietario_ID equals propietarios.Id.ToString()
							 select new ListofPropiedadesDto
							 {
								Propietario = propietarios.Nombre.ToUpper() + " " + propietarios.Apellidos.ToUpper(),
								IDPropiedad = prop.Id,
								PropietarioID = prop.Propietario_ID.ToUpper(),
								Titulo = prop.Titulo.ToUpper(),
								Detalle = prop.Detalle.ToUpper(),
								Precio = prop.Precio,
								Ubicacion = prop.Ubicacion.ToUpper(),
								Estado = prop.Estado.ToUpper()
							 };

		  return await _listaPropiedades.ToListAsync(cancellationToken);


	   }
    }
}
