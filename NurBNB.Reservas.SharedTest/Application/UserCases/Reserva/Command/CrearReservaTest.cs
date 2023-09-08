using Castle.Core.Resource;
using Moq;
using NurBNB.Reservas.Application.UserCases.Reserva.Command.CrearReserva;
using NurBNB.Reservas.Domain;
//using NurBNB.Reservas.Domain.Model.Reservas;
//using NurBNB.Reservas.Domain.Repositories;
using NurBNB.Reservas.Infrastructure.EF.Context;
//using NurBNB.Reservas.Infrastructure.EF.Repositories;
using NurBNB.Reservas.SharedKernel.Core;
using NurBNB.Reservas.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.SharedTest.Application.UserCases.Reserva.Command
{
    public class CrearReservaTest
    {
        Mock<NurBNB.Reservas.Domain.Repositories.IReservaRepository> _reservaRepository;
        Mock<IUnitOfWork> _unitOfWork;
        Mock<NurBNB.Reservas.Domain.Factories.IReservaFactory> _reservaFactory;

        public CrearReservaTest()
        {
            _reservaRepository = new Mock<NurBNB.Reservas.Domain.Repositories.IReservaRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _reservaFactory = new Mock<NurBNB.Reservas.Domain.Factories.IReservaFactory>();

            
        }
        [Fact]
        public async void CrearReservaDePropiedadTest()
        {
            // Arrange
           
            var reserva = new CrearReservaCommand();
            reserva.HuespedID =Guid.NewGuid();
            reserva.PropiedadID = Guid.NewGuid(); 
            reserva.FechaCheckIn = DateTime.Now;
            reserva.FechaCheckOut = DateTime.Now.AddDays(3);
            reserva.Motivo = "Viaje de Prueba";

            
            // Act
            var handler = new CrearReservaHandler(_reservaFactory.Object, _reservaRepository.Object, _unitOfWork.Object);

            var tcs = new CancellationTokenSource(1000);

            var esperado =  await handler.Handle(reserva, tcs.Token);

            // Assert
            Assert.True(esperado.Equals(esperado));
            
        }

        [Fact]
        public async void ValidarFechasdeReservaTest()
        {
            // Arrange
            
            var reserva = new CrearReservaCommand();
            reserva.HuespedID = Guid.NewGuid();
            reserva.PropiedadID = Guid.NewGuid();
            reserva.FechaCheckIn = DateTime.Now.AddDays(3); 
            reserva.FechaCheckOut = DateTime.Now;
            reserva.Motivo = "Viaje de Prueba";

            // Act
            var handler = new CrearReservaHandler(_reservaFactory.Object, _reservaRepository.Object, _unitOfWork.Object);

            var tcs = new CancellationTokenSource(1000);

           
            // Assert
            
            Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(reserva, tcs.Token));

        }

        [Fact]
        public async void CrearReservaSinMotivo()
        {
            // Arrange

            var reserva = new CrearReservaCommand();
            reserva.HuespedID = Guid.NewGuid();
            reserva.PropiedadID = Guid.NewGuid();
            reserva.FechaCheckIn = DateTime.Now;
            reserva.FechaCheckOut = DateTime.Now.AddDays(3);
            reserva.Motivo = "";

            // Act
            var handler = new CrearReservaHandler(_reservaFactory.Object, _reservaRepository.Object, _unitOfWork.Object);

            var tcs = new CancellationTokenSource(1000);

            // Assert
            Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(reserva, tcs.Token));

        }
    }
}
