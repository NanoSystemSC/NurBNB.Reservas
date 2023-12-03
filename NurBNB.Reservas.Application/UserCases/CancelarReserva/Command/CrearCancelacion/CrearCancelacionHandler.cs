using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NurBNB.Reservas.Domain.Factories;
using NurBNB.Reservas.Domain.Repositories;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Application.UserCases.CancelarReserva.Command.CrearReserva
{
	public class CrearCancelacionHandler : IRequestHandler<CrearCancelacionCommand, Guid>
	{
		private readonly ICancelarFactory _cancelarFactory;
		private readonly ICancelarReservaRepository _cancelarRepository;
		private readonly IUnitOfWork _unitOfWork;

		public CrearCancelacionHandler(ICancelarFactory cancelarFactory, ICancelarReservaRepository cancelarRepository,
			IUnitOfWork unitOfWork)
		{
			_cancelarFactory = cancelarFactory;
			_cancelarRepository = cancelarRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Guid> Handle(CrearCancelacionCommand request, CancellationToken cancellationToken)
		{
			if (string.IsNullOrEmpty(request.Motivo))
				throw new ArgumentException("Debe ingresar el Motivo por el cual quiere realizar la cancelacion");

			var cancelacionCreada = _cancelarFactory.Create(request.ReservaID, DateTime.Now, false, 0, request.Motivo);

			await _cancelarRepository.CreateAsync(cancelacionCreada);
			await _unitOfWork.Commit();

			return (cancelacionCreada != null ? cancelacionCreada.Id : Guid.NewGuid());
		}
	}
}
