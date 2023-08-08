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
        private readonly IReservaRepository _reservaRepository;

       

        public CrearCancelacionHandler(ICancelarFactory cancelarFactory, ICancelarReservaRepository cancelarRepository, 
            IUnitOfWork unitOfWork, IReservaRepository reservaRepository)
        {
            _cancelarFactory = cancelarFactory;
            _cancelarRepository = cancelarRepository;
            _unitOfWork = unitOfWork;
            _reservaRepository = reservaRepository;
        }

        public async Task<Guid> Handle(CrearCancelacionCommand request, CancellationToken cancellationToken)
        {

            //var objReserva = await _reservaRepository.FindByIdAsync(request.ReservaID);

            var cancelacionCreada = _cancelarFactory.Create(request.ReservaID, DateTime.Now, false, 0, request.Motivo);

            await _cancelarRepository.CreateAsync(cancelacionCreada);
            await _unitOfWork.Commit();

            return cancelacionCreada.Id;
        }
    }
}
