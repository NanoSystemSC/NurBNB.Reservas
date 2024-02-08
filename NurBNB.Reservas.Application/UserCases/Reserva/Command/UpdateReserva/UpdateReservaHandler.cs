using MediatR;
using NurBNB.Reservas.Domain.Factories;
using NurBNB.Reservas.Domain.Repositories;
using NurBNB.Reservas.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Application.UserCases.Reserva.Command.UpdateReserva
{
    public class UpdateReservaHandler : IRequestHandler<UpdateReservaCommand, Guid>
    {
	   private readonly IReservaFactory _reservaFactory;
	   private readonly IReservaRepository _reservaRepository;
	   private readonly IUnitOfWork _unitOfWork;

	   public UpdateReservaHandler(IReservaFactory reservaFactory, IReservaRepository reservaRepository, IUnitOfWork unitOfWork)
	   {
		  _reservaFactory = reservaFactory;
		  _reservaRepository = reservaRepository;
		  _unitOfWork = unitOfWork;
	   }
	   public async Task<Guid> Handle(UpdateReservaCommand request, CancellationToken cancellationToken)
	   {
		  var reserva = await _reservaRepository.FindByIdAsync(request.ReservaID);
		  if (reserva != null)
		  {
			 reserva.Estado = Domain.Model.Estados.TipoEstadoReserva.Reservado;

			 await _reservaRepository.UpdateAsync(reserva);
			 await _unitOfWork.Commit();
		  }

		  return reserva != null ? reserva.Id : Guid.NewGuid();

	   }
    }
}
