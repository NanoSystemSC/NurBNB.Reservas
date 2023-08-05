using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NurBNB.Reservas.Domain.Factories;
using NurBNB.Reservas.Domain.Repositories;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Application.UserCases.Reserva.Command.CrearReserva
{
    public class CrearReservaHandler : IRequestHandler<CrearReservaCommand, Guid>
    {
        private readonly IReservaFactory _reservaFactory;
        private readonly IReservaRepository _reservaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CrearReservaHandler(IReservaFactory reservaFactory, IReservaRepository reservaRepository, IUnitOfWork unitOfWork)
        {
            _reservaFactory = reservaFactory;
            _reservaRepository = reservaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearReservaCommand request, CancellationToken cancellationToken)
        {
            var reservaCreada = _reservaFactory.Create(request.HuespedID, request.PropiedadID, request.FechaCheckIn, request.FechaCheckOut, request.Motivo);

            await _reservaRepository.CreateAsync(reservaCreada);
            await _unitOfWork.Commit();

            return reservaCreada.Id;
        }
    }
}
