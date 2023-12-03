using Microsoft.EntityFrameworkCore;
using Moq;
using NurBNB.Reservas.Application.UserCases.Propiedad.Command.CrearPropiedad;
using NurBNB.Reservas.Application.UserCases.Reserva.Command.CrearReserva;
using NurBNB.Reservas.Domain.Model.Reservas;
using NurBNB.Reservas.Infrastructure.EF.Context;
using NurBNB.Reservas.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Test.Application.UserCases.Propiedad.Command
{

	public class CrearPropiedadTest
	{

		Mock<NurBNB.Reservas.Domain.Repositories.IPropiedadRepository> _propiedadRepository;
		Mock<IUnitOfWork> _unitOfWork;
		Mock<NurBNB.Reservas.Domain.Factories.IPropiedadFactory> _propiedaFactory;

		public CrearPropiedadTest()
		{
			_propiedadRepository = new Mock<NurBNB.Reservas.Domain.Repositories.IPropiedadRepository>();
			_unitOfWork = new Mock<IUnitOfWork>();
			_propiedaFactory = new Mock<NurBNB.Reservas.Domain.Factories.IPropiedadFactory>();

		}

		[Fact]
		public async void CrearReservaDePropiedadTest()
		{
			// Arrange

			var propiedad = new CrearPropiedadCommand()
			{
				Titulo = "Titulo 1",
				Detalle = "Detalle 1",
				Precio = 100,
				PropietarioID = Guid.NewGuid().ToString(),
				ubicacion = "Ubicacion 2323"
			};

			// Act
			var handler = new CrearPropiedadHandler(_propiedaFactory.Object, _propiedadRepository.Object, _unitOfWork.Object);

			var esperado = await handler.Handle(propiedad, new CancellationTokenSource(1000).Token);
			// Assert
			Assert.True(esperado.Equals(esperado));

		}

		[Fact]
		public async void CrearPropiedadSinUbicacion()
		{
			// Arrange

			var propiedad = new CrearPropiedadCommand()
			{
				Titulo = "Titulo 1",
				Detalle = "Detalle 1",
				Precio = 100,
				PropietarioID = Guid.NewGuid().ToString(),
				ubicacion = ""
			};

			// Act
			var handler = new CrearPropiedadHandler(_propiedaFactory.Object, _propiedadRepository.Object, _unitOfWork.Object);

			// Assert
			Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(propiedad, new CancellationTokenSource(1000).Token));

		}
		[Fact]
		public async void CrearPropiedadSinDetalle()
		{
			// Arrange

			var propiedad = new CrearPropiedadCommand()
			{
				Titulo = "Titulo 1",
				Detalle = "",
				Precio = 100,
				PropietarioID = Guid.NewGuid().ToString(),
				ubicacion = "Ubicacion 1"
			};

			// Act
			var handler = new CrearPropiedadHandler(_propiedaFactory.Object, _propiedadRepository.Object, _unitOfWork.Object);

			// Assert
			Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(propiedad, new CancellationTokenSource(1000).Token));

		}

		[Fact]
		public async void CrearPropiedadSinTitulo()
		{
			// Arrange

			var propiedad = new CrearPropiedadCommand()
			{
				Titulo = "",
				Detalle = "Detalle",
				Precio = 100,
				PropietarioID = Guid.NewGuid().ToString(),
				ubicacion = "Ubicacion 1"
			};

			// Act
			var handler = new CrearPropiedadHandler(_propiedaFactory.Object, _propiedadRepository.Object, _unitOfWork.Object);

			// Assert
			Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(propiedad, new CancellationTokenSource(1000).Token));

		}

		[Fact]
		public async void CrearPropiedadSinUbicacicion()
		{
			// Arrange

			var propiedad = new CrearPropiedadCommand()
			{
				Titulo = "Titulo 333",
				Detalle = "Detalle",
				Precio = 100,
				PropietarioID = Guid.NewGuid().ToString(),
				ubicacion = ""
			};

			// Act
			var handler = new CrearPropiedadHandler(_propiedaFactory.Object, _propiedadRepository.Object, _unitOfWork.Object);

			// Assert
			Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(propiedad, new CancellationTokenSource(1000).Token));

		}

	}
}
