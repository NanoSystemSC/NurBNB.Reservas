using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Domain.Model.Cancelacion
{
    public class TipoCancelacion: AggregateRoot
    {
        

        //public Guid  ID_TipoCancelacion { get; set; }
        public string Descripcion { get; private set; }
        public int Dia_Ini { get; private set; }
        public int Dia_Fin { get; private set; }
        public decimal PorcentajeDevolucion { get; private set; }

        public TipoCancelacion(string descripcion, int dia_Ini, int dia_Fin, decimal porcentajeDevolucion)
        {
            Id = Guid.NewGuid();
            Descripcion = descripcion;
            Dia_Ini = dia_Ini;
            Dia_Fin = dia_Fin;
            PorcentajeDevolucion = porcentajeDevolucion;
        }

        private TipoCancelacion() { }
    }
}
