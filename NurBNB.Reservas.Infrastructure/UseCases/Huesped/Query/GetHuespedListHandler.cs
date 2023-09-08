using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NurBNB.Reservas.Application.Dto.Huesped;
using NurBNB.Reservas.Application.UserCases.Huesped.Query.GetHuespuedList;
using NurBNB.Reservas.Infrastructure.EF.Context;
using NurBNB.Reservas.Infrastructure.EF.ReadModel;

namespace NurBNB.Reservas.Infrastructure.UseCases.Huesped.Query
{
    [ExcludeFromCodeCoverage]
    internal class GetHuespedListHandler : IRequestHandler<GetHuespedListQuery, ICollection<HuespedDto>>
    {
        private readonly DbSet<HuespedReadModel> _huespedes;

        public GetHuespedListHandler(ReadDbContext dbContext)
        {
            _huespedes = dbContext.Huesped;
        }

        public async Task<ICollection<HuespedDto>> Handle(GetHuespedListQuery request, CancellationToken cancellationToken)
        {
            var query = _huespedes.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                query = query.Where(x => x.Nombre.Contains(request.SearchTerm));
            }

            return await query.Select(huesped =>
                new HuespedDto
                {
                    HuespedID = huesped.Id,
                    Nombre = huesped.Nombre,
                    Apellidos = huesped.Apellidos,
                    NroDoc = huesped.NroDoc,
                    Email = huesped.Email,
                    Calle = huesped.Calle,
                    Ciudad= huesped.Ciudad,
                    Pais = huesped.Pais,
                    Telefono = huesped.Telefono,
                    Codigo_postal = huesped.Codigo_postal
                    
                }).ToListAsync(cancellationToken);
        }
    }
}
