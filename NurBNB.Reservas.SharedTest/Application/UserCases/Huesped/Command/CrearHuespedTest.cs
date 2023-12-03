using Moq;
using NurBNB.Reservas.Application.UserCases.Huesped.Command.CrearHuesped;
using NurBNB.Reservas.Application.UserCases.Reserva.Command.CrearReserva;
using NurBNB.Reservas.Domain.Factories;
using NurBNB.Reservas.Domain.Model.Reservas;
using NurBNB.Reservas.Domain.Repositories;
using NurBNB.Reservas.Infrastructure.EF.Repositories;
using NurBNB.Reservas.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Test.Application.UserCases.Huesped.Command
{
	public class CrearHuespedTest
	{
		Mock<IHuespedRepository> _huespedRepository;
		Mock<IUnitOfWork> _unitOfWork;
		Mock<IHuespedFactory> _huespedFactory;

		public CrearHuespedTest()
		{
			_huespedRepository = new Mock<IHuespedRepository>();
			_unitOfWork = new Mock<IUnitOfWork>();
			_huespedFactory = new Mock<IHuespedFactory>();


		}

		[Fact]
		public async void CrearHuespedAlojamientoTest()
		{
			// Arrange

			var huesped = new CrearHuespedCommand()
			{
				Nombre = "Fernando",
				Apellidos = "Sandagorda",
				Telefono = "59177888996",
				Ciudad = "Santa Cruz",
				Pais = "Bolivia",
				Email = "email",
				Calle = "Calle direcccion",
				NroDoc = "5400100",
				CodigoPostal = "08567"
			};


			// Act
			var handler = new CrearHuespedHandler(_huespedRepository.Object, _huespedFactory.Object, _unitOfWork.Object);

			var tcs = new CancellationTokenSource(1000);

			var esperado = await handler.Handle(huesped, tcs.Token);

			// Assert
			Assert.True(esperado.Equals(esperado));

		}

		[Fact]
		public async void CrearHuespedAlojamientoSinNombresTest()
		{
			// Arrange

			var huesped = new CrearHuespedCommand()
			{
				Nombre = "",
				Apellidos = "Sandagorda",
				Telefono = "59177888996",
				Ciudad = "Santa Cruz",
				Pais = "Bolivia",
				Email = "email",
				Calle = "Calle direcccion",
				NroDoc = "5400100",
				CodigoPostal = "08567"
			};


			// Act
			var handler = new CrearHuespedHandler(_huespedRepository.Object, _huespedFactory.Object, _unitOfWork.Object);

			// Assert
			Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(huesped, new CancellationTokenSource(1000).Token));

		}

		[Fact]
		public async void CrearHuespedAlojamientoSinApellidosTest()
		{
			// Arrange

			var huesped = new CrearHuespedCommand()
			{
				Nombre = "Fernando",
				Apellidos = "",
				Telefono = "59177888996",
				Ciudad = "Santa Cruz",
				Pais = "Bolivia",
				Email = "email",
				Calle = "Calle direcccion",
				NroDoc = "5400100",
				CodigoPostal = "08567"
			};

			_huespedRepository.Setup(_huespedRepository => _huespedRepository.FindByIdAsync(Guid.NewGuid()));
			// Act
			var handler = new CrearHuespedHandler(_huespedRepository.Object, _huespedFactory.Object, _unitOfWork.Object);

			// Assert
			Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(huesped, new CancellationTokenSource(1000).Token));


		}

		[Fact]
		public async void CrearHuespedAlojamientoSinMailTest()
		{
			// Arrange

			var huesped = new CrearHuespedCommand()
			{
				Nombre = "Fernando",
				Apellidos = "Sandagorda",
				Telefono = "59177888996",
				Ciudad = "Santa Cruz",
				Pais = "Bolivia",
				Email = "",
				Calle = "Calle direcccion",
				NroDoc = "5400100",
				CodigoPostal = "08567"
			};

			_huespedRepository.Setup(_huespedRepository => _huespedRepository.FindByIdAsync(Guid.NewGuid()));
			// Act
			var handler = new CrearHuespedHandler(_huespedRepository.Object, _huespedFactory.Object, _unitOfWork.Object);

			// Assert
			Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(huesped, new CancellationTokenSource(1000).Token));


		}
	}
}
