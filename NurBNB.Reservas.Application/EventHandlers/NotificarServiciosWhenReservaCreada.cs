using MediatR;
using NurBNB.Reservas.Application.Services;
using NurBNB.Reservas.Domain.Model.Reservas.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Application.EventHandlers
{
    internal class NotificarServiciosWhenReservaCreada : INotificationHandler<ReservaCreada>
    {

        private readonly IBusService _bus;

        public NotificarServiciosWhenReservaCreada(IBusService bus)
        {
            _bus = bus;
        }

        public async Task Handle(ReservaCreada notification, CancellationToken cancellationToken)
        {

            IntegrationEvents.ReservaCreada evento = new IntegrationEvents.ReservaCreada() { 
                ReservaId = notification.Id,
                PropiedaId = notification.PropiedaId,
                Nombre = notification.Nombre
            };

            await _bus.PublishAsync(evento);

           //return Task.CompletedTask;
        }
    }
}
