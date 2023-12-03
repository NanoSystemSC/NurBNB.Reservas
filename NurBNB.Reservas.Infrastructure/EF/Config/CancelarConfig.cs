using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NurBNB.Reservas.Domain.Model.Cancelacion;
using NurBNB.Reservas.Domain.Model.Reservas;

namespace NurBNB.Reservas.Infrastructure.EF.Config
{
	[ExcludeFromCodeCoverage]
	internal class CancelarConfig : IEntityTypeConfiguration<CancelarReserva>
	{
		public void Configure(EntityTypeBuilder<CancelarReserva> builder)
		{
			builder.ToTable("CancelarReserva");
			builder.HasKey(x => x.Id);


			builder.Property(x => x.Id)
				.HasColumnName("ID_CancelarReserva");

			builder.Property(x => x.ReservaID)
				.HasColumnName("ReservaID");

			builder.Property(x => x.FechaCancelacion)
			   .HasColumnName("FechaCancelacion");

			builder.Property(x => x.AplicaDescuento)
				.HasColumnName("Aplica_Descuento");

			builder.Property(x => x.Motivo)
				.HasColumnName("Motivo");

			builder.Property(x => x.PorcentajeDevolucion)
				.HasColumnName("Porcentaje_Devolucion");

			builder.Ignore("_domainEvents");
			builder.Ignore(x => x.DomainEvents);
		}
	}
}
