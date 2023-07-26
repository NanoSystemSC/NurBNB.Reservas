using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.Domain.Model.Estados;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Domain.Model.Reservas
{
    public class Reserva: AggregateRoot
    {
        public Guid Id_Reserva { get; set; }
        public string Id_Huesped { get; set; }
        public int ID_Propiedad { get; set; }
        public DateTime Fecha_Checkin { get; set; }
        public DateTime Fecha_Checkout { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public Estado estados { get; set; }

        internal Reserva(Guid id_Reserva, string id_Huesped, int iD_Propiedad, DateTime fecha_Checkin, DateTime fecha_Checkout, DateTime fecha_Registro, Estado estados)
        {
            Id_Reserva = id_Reserva;
            Id_Huesped = id_Huesped;
            ID_Propiedad = iD_Propiedad;
            Fecha_Checkin = fecha_Checkin;
            Fecha_Checkout = fecha_Checkout;
            Fecha_Registro = fecha_Registro;
            this.estados = estados;
        }   
    }
}
