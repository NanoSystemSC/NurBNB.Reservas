using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NurBNB.Reservas.Domain.Factories;
using NurBNB.Reservas.Domain.Repositories;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Application.UserCases.Propiedad.Command.CrearPropiedad
{
    public class CrearPropiedadHandler : IRequestHandler<CrearPropiedadCommand, Guid>
    {                 
        private readonly IPropiedadFactory _propiedadFactory;
        private readonly IPropiedadRepository _propiedadRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CrearPropiedadHandler(IPropiedadFactory propiedadFactory, IPropiedadRepository propiedadRepository, IUnitOfWork unitOfWork)
        {
            _propiedadFactory = propiedadFactory;
            _propiedadRepository = propiedadRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearPropiedadCommand request, CancellationToken cancellationToken)
        {
            var propiedadCreada = _propiedadFactory.Create(request.ID_Propietario, request.Titulo, request.Precio,
                 request.Detalle, request.ubicacion);

            await _propiedadRepository.CreateAsync(propiedadCreada);
            await _unitOfWork.Commit();

            return propiedadCreada.Id;
        }
    }
}
