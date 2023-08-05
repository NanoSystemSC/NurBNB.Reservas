using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.Domain.Model.Estados;

namespace NurBNB.Reservas.Application.Dto.Propiedad
{
    public class PropiedadDto
    {

        public Guid PropiedadID { get; set; }
        public string ID_Propietario { get;  set; }
        
        public string Titulo { get;  set; }
        public decimal Precio { get;  set; }       
        public string Detalle { get;  set; }
        public string ubicacion { get;  set; }
        public string Estado { get;  set; }
    }
}
