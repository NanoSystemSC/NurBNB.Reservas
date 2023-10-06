using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.Domain.ValueObjects;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Domain.Model.Clientes
{
    public class Huesped : AggregateRoot
    {
        public Guid ID_Huesped { get; private set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string NroDoc { get; set; }
        public string Email { get; set; }


        public DireccionValue Direccion { get; set; }


        internal Huesped(Guid id, string nombre, string apellidos, string telefono, string nrodoc, string email, DireccionValue direccion)
        {
            ID_Huesped = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Telefono = telefono;
            NroDoc = nrodoc;
            Email = email;
            Direccion = direccion;
        }

    }
}
