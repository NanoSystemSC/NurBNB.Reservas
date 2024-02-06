using MediatR;
using NurBNB.Reservas.Application.Dto.Propiedad;
using NurBNB.Reservas.Domain.Model.Estados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Application.UserCases.Propiedad.Query.GetListofPropiedades
{
    public class GetListofPropiedadesQuery : IRequest<List<ListofPropiedadesDto>>
    {
	   public TipoEstadoReserva estadoReserva { get; set; }
    }
}
