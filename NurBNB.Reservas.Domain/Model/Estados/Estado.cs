using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Domain.Model.Estados
{
    public class Estado : AggregateRoot
    {
	   public Guid IDEstado { get; set; }
	   public int TipoEstado { get; set; }
	   public string Descripcion { get; set; }

	   public Estado(Guid id, int tipoEstado, string descripcion)
	   {
		  IDEstado = id;
		  TipoEstado = tipoEstado;
		  Descripcion = descripcion;

	   }
    }
}
