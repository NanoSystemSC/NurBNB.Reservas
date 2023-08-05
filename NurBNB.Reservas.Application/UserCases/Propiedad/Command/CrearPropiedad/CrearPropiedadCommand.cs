using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NurBNB.Reservas.Domain.ValueObjects;

namespace NurBNB.Reservas.Application.UserCases.Propiedad.Command.CrearPropiedad
{
    public class CrearPropiedadCommand : IRequest<Guid>
    {
        public string ID_Propietario { get; private set; }
        public string Titulo { get; private set; }
        public decimal Precio { get; private set; }
        public string Detalle { get; private set; }
        public string ubicacion { get; private set; }
    }
}
