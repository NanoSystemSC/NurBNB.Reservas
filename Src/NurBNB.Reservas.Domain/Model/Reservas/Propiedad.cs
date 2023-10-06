using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.Domain.Model.Estados;
using NurBNB.Reservas.Domain.ValueObjects;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Domain.Model.Reservas
{
    public class Propiedad: AggregateRoot
    {
        public string Propietario_ID { get; private set; }
        public string Titulo { get; private set; }
        public PrecioValue Precio { get; private set; }
        public string Detalle { get; private set; }
        public string ubicacion { get; private set; }

        public TipoEstadoReserva Estado { get; private set; }

        //private readonly ICollection<Reserva> _reserva;

        //public IEnumerable<Reserva> Reserva => _reserva;

        public Propiedad(string propietario_ID, string titulo, decimal precio, string detalle, string ubicacion)
        {
            Id = Guid.NewGuid();
            Propietario_ID = propietario_ID;
            Titulo = titulo;
            Precio = precio;
            Detalle = detalle;
            this.ubicacion = ubicacion;
            Estado = TipoEstadoReserva.Disponible;
            //_reserva = new List<Reserva>();
        }

        [ExcludeFromCodeCoverage]
        private Propiedad() { }

        
    }
}
