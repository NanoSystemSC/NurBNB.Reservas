using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Domain.Model.Cancelacion
{
    public class CancelarReserva : AggregateRoot
    {
        public Guid ReservaID { get; private set; }
        public DateTime FechaCancelacion { get; private set; }
        //public bool Aplica_Descuento { get; private set; }
        public bool Aplica_Descuento { get;  set; }
        public string Motivo { get; private set; }
        public decimal Porcentaje_Devolucion { get;  set; }


        public CancelarReserva(Guid reservaID, DateTime fechaCancelacion, bool aplica_Descuento, decimal porcentaje_Devolucion, string motivo)
        {
            Id= Guid.NewGuid();
            ReservaID = reservaID;
            FechaCancelacion = fechaCancelacion;
            Aplica_Descuento = aplica_Descuento;
            Porcentaje_Devolucion = porcentaje_Devolucion;
            Motivo = motivo;
        }

        private CancelarReserva() { }
    }
}
