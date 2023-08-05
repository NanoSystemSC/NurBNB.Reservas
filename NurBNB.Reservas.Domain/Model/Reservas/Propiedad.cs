using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.Domain.ValueObjects;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Domain.Model.Reservas
{
    public class Propiedad: AggregateRoot
    {
        //public Guid ID_Propietario { get; private set; }
        public string ID_Propietario { get; private set; }
        public string Titulo { get; private set; }
        //public PrecioValue Precio { get; private set; }
        public decimal Precio { get; private set; }
        public string Detalle { get; private set; }
        public string ubicacion { get; private set; }

        public Propiedad(string iD_Propietario, string titulo, decimal precio, string detalle, string ubicacion)
        {
            Id = Guid.NewGuid();
            ID_Propietario = iD_Propietario;
            Titulo = titulo;
            Precio = precio;
            Detalle = detalle;
            this.ubicacion = ubicacion;
        }

        private Propiedad() { }
    }
}
