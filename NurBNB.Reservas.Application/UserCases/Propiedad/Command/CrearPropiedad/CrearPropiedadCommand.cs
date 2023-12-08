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
	   public string PropietarioID { get; set; }
	   public string Titulo { get; set; }
	   public decimal Precio { get; set; }
	   public string Detalle { get; set; }
	   public string ubicacion { get; set; }
    }
}
