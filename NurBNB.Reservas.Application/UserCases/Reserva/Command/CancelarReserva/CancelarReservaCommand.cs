using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Application.UserCases.Reserva.Command.CancelarReserva
{
    public class CancelarReservaCommand : IRequest<Guid>
    {
	   public Guid ReservaID { get; set; }
    }
}
