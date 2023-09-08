using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.Domain.Model.Estados;

namespace NurBNB.Reservas.Application.Dto.Propiedad
{
    [ExcludeFromCodeCoverage]
    public class PropiedadDto
    {

        public Guid ID_Propiedad { get; set; }
        public string Propietario_ID { get;  set; }
        
        public string Titulo { get;  set; }
        public decimal Precio { get;  set; }       
        public string Detalle { get;  set; }
        public string ubicacion { get;  set; }
        public string Estado { get;  set; }
    }
}
