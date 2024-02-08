using MediatR;
using NurBNB.Reservas.Application.Dto.Propiedad;
using NurBNB.Reservas.Application.Dto.Reserva;
using NurBNB.Reservas.Domain.Model.Estados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Application.UserCases.Reserva.Query.GetListofReservas
{
    public class GetListofReservasDisponiblesQuery : IRequest<List<ListOfReservaDto>>
    {
	   public TipoEstadoReserva estadoReserva { get; set; }
    }
}
