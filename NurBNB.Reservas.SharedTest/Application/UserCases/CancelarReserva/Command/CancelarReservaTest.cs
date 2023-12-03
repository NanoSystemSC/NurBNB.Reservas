using Moq;
using NurBNB.Reservas.Application.UserCases.CancelarReserva.Command.CrearReserva;
using NurBNB.Reservas.Application.UserCases.Huesped.Command.CrearHuesped;
using NurBNB.Reservas.Domain.Factories;
using NurBNB.Reservas.Domain.Model.Clientes;
using NurBNB.Reservas.Domain.Repositories;
using NurBNB.Reservas.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Test.Application.UserCases.CancelarReserva.Command
{

	public class CancelarReservaTest
	{
		Mock<ICancelarReservaRepository> _cancelarReservaRepository;
		Mock<IUnitOfWork> _unitOfWork;
		Mock<ICancelarFactory> _cancelarReservaFactory;

		public CancelarReservaTest()
		{
			_cancelarReservaRepository = new Mock<ICancelarReservaRepository>();
			_cancelarReservaFactory = new Mock<ICancelarFactory>();
			_unitOfWork = new Mock<IUnitOfWork>();
		}

		[Fact]
		public async void CancelarReservaAlojamientoTest()
		{
			// Arrange

			var cancelacion = new CrearCancelacionCommand()
			{
				ReservaID = Guid.NewGuid(),
				Motivo = "Motivo de Prueba"
			};

			// Act
			var handler = new CrearCancelacionHandler(_cancelarReservaFactory.Object, _cancelarReservaRepository.Object, _unitOfWork.Object);
			var respuestaEsperada = await handler.Handle(cancelacion, new CancellationTokenSource(1000).Token);

			// Assert
			Assert.True(respuestaEsperada.Equals(respuestaEsperada));
		}

		[Fact]
		public async void CancelarReservaSinMotivoTest()
		{
			// Arrange

			var cancelacion = new CrearCancelacionCommand()
			{
				ReservaID = Guid.NewGuid(),
				Motivo = ""
			};


			// Act
			var handler = new CrearCancelacionHandler(_cancelarReservaFactory.Object, _cancelarReservaRepository.Object, _unitOfWork.Object);



			// Assert
			Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(cancelacion, new CancellationTokenSource(1000).Token));

		}
	}
}
