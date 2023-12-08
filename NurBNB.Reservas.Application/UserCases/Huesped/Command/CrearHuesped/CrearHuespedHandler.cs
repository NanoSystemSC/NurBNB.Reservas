using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NurBNB.Reservas.Domain.Factories;
using NurBNB.Reservas.Domain.Repositories;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Application.UserCases.Huesped.Command.CrearHuesped
{
    public class CrearHuespedHandler : IRequestHandler<CrearHuespedCommand, Guid>
    {
	   private readonly IHuespedRepository _huespedRepository;
	   private readonly IHuespedFactory _huespedFactory;
	   private readonly IUnitOfWork _unitofWork;

	   public CrearHuespedHandler(IHuespedRepository huespedRepository, IHuespedFactory huespedFactory, IUnitOfWork unitofWork)
	   {
		  _huespedRepository = huespedRepository;
		  _huespedFactory = huespedFactory;
		  _unitofWork = unitofWork;
	   }

	   public async Task<Guid> Handle(CrearHuespedCommand request, CancellationToken cancellationToken)
	   {
		  if (string.IsNullOrEmpty(request.Nombre))
			 throw new ArgumentException("Debe ingresar un nombre del Huesped");

		  if (string.IsNullOrEmpty(request.Apellidos))
			 throw new ArgumentException("Debe ingresar un Apellido del Huesped");

		  if (string.IsNullOrEmpty(request.Email))
			 throw new ArgumentException("Debe ingresar un Mail del Huesped");


		  var huespedCreado = _huespedFactory.Create(request.Nombre, request.Apellidos, request.Telefono,
			  request.NroDoc, request.Email, request.Calle, request.Ciudad, request.Pais, request.CodigoPostal);

		  await _huespedRepository.CreateAsync(huespedCreado);
		  await _unitofWork.Commit();

		  return (huespedCreado != null ? huespedCreado.Id : Guid.NewGuid());
	   }
    }
}
