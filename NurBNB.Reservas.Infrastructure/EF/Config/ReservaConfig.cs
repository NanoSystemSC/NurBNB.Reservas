using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NurBNB.Reservas.Domain.Model.Estados;
using NurBNB.Reservas.Domain.Model.Reservas;

namespace NurBNB.Reservas.Infrastructure.EF.Config
{
    [ExcludeFromCodeCoverage]
    internal class ReservaConfig : IEntityTypeConfiguration<Reserva>
    {
	   public void Configure(EntityTypeBuilder<Reserva> builder)
	   {
		  builder.ToTable("Reserva");
		  builder.HasKey(x => x.Id);


		  builder.Property(x => x.Id)
			  .HasColumnName("ID_Reserva");

		  builder.Property(x => x.HuespedID)
			  .HasColumnName("Huesped_ID");

		  builder.Property(x => x.PropiedadID)
			.HasColumnName("Propiedad_ID");

		  builder.Property(x => x.FechaCheckIn)
			  .HasColumnName("FechaCheckin");

		  builder.Property(x => x.FechaCheckOut)
			  .HasColumnName("FechaCheckOut");

		  builder.Property(x => x.FechaRegistro)
			  .HasColumnName("FechaRegistro");

		  builder.Property(x => x.Motivo)
			  .HasColumnName("Motivo");

		  var tipoConverter = new ValueConverter<TipoEstadoReserva, string>(
			  tipoEnumValue => tipoEnumValue.ToString(),
			  tipo => (TipoEstadoReserva)Enum.Parse(typeof(TipoEstadoReserva), tipo)
			  );

		  builder.Property(x => x.Estado)
			   .HasConversion(tipoConverter)
			   .HasColumnName("Estado")
			   .HasMaxLength(20)
			   .IsRequired();

		  builder.Ignore("_domainEvents");
		  builder.Ignore(x => x.DomainEvents);

	   }
    }
}
