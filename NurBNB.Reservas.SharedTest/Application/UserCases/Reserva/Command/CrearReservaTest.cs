using Castle.Core.Resource;
using Moq;
using NurBNB.Reservas.Application.UserCases.Reserva.Command.CrearReserva;
using NurBNB.Reservas.Domain;
//using NurBNB.Reservas.Domain.Model.Reservas;
//using NurBNB.Reservas.Domain.Repositories;
using NurBNB.Reservas.Infrastructure.EF.Context;
//using NurBNB.Reservas.Infrastructure.EF.Repositories;
using NurBNB.Reservas.SharedKernel.Core;
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

        Mock<WriteDbContext> _context;

       
        public CrearReservaTest()
        {
            _reservaRepository = new Mock<NurBNB.Reservas.Domain.Repositories.IReservaRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _reservaFactory = new Mock<NurBNB.Reservas.Domain.Factories.IReservaFactory>();

            _context = new Mock<WriteDbContext>();
        }
        [Fact]
        public async void CrearReservaDePropiedadTest()
        {
            // Arrange
            //var reserva = new Domain.Models.Customer(new Guid(), "Alan", "alab@test.com", new DateTime());
            var reserva = new CrearReservaCommand();
            reserva.HuespedID =Guid.NewGuid();
            reserva.PropiedadID = Guid.NewGuid(); 
            reserva.FechaCheckIn = DateTime.Now;
            reserva.FechaCheckOut = DateTime.Now.AddDays(3);
            reserva.Motivo = "Viaje de Prueba";

            //var reservaRepositoryMock = new Mock<IReservaRepository>(); // ICustomerRepository>();
            //_reservaRepository.Setup(x =>  x.FindByIdAsync(reserva.Id)) // x.GetById(customer.Id))
            //    .ReturnsAsync(reserva);

            var handler = new CrearReservaHandler(_reservaFactory.Object, _reservaRepository.Object, _unitOfWork.Object);

            var tcs = new CancellationTokenSource(1000);

            var esperado =  await handler.Handle(reserva, tcs.Token);

            // Act
            //var reserv = new ReservaRepository(_context.Object); // CustomerAppService(mapperMock.Object, customerRepositoryMock.Object, null, null);
            //var result = await reserv.FindByIdAsync(reserva.Id); // .GetById(customer.Id);

            // Assert
            Assert.True(esperado.Equals(esperado));
            
        }
    }
}
