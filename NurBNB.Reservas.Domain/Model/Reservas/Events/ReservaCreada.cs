using MediatR;
using NurBNB.Reservas.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Domain.Model.Reservas.Events
{
    public record ReservaCreada : DomainEvent, INotification
    {
        public Guid ReservaId { get; init; }
        public Guid PropiedaId { get; init; }
        public string Nombre { get; set; }        
        
        public ReservaCreada(Guid reservaId, Guid propiedadID,
            string nombre) : base(DateTime.Now)
        {
            ReservaId = reservaId;
            PropiedaId = propiedadID;
            Nombre = nombre;           
        }
    }
}
