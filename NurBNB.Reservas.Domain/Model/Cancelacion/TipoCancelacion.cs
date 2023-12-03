using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Domain.Model.Cancelacion
{
	public class TipoCancelacion : AggregateRoot
	{


		//public Guid  ID_TipoCancelacion { get; set; }
		public string Descripcion { get; private set; }
		public int DiaIni { get; private set; }
		public int DiaFin { get; private set; }
		public decimal PorcentajeDevolucion { get; private set; }

		public TipoCancelacion(string descripcion, int diaIni, int diaFin, decimal porcentajeDevolucion)
		{
			Id = Guid.NewGuid();
			Descripcion = descripcion;
			DiaIni = diaIni;
			DiaFin = diaFin;
			PorcentajeDevolucion = porcentajeDevolucion;
		}

		[ExcludeFromCodeCoverage]
		private TipoCancelacion() { }
	}
}
