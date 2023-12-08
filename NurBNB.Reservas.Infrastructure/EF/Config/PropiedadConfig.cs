using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NurBNB.Reservas.Domain.Model.Clientes;
using NurBNB.Reservas.Domain.Model.Estados;
using NurBNB.Reservas.Domain.Model.Reservas;
using NurBNB.Reservas.Domain.ValueObjects;

namespace NurBNB.Reservas.Infrastructure.EF.Config
{
    [ExcludeFromCodeCoverage]
    internal class PropiedadConfig : IEntityTypeConfiguration<Propiedad>
    {
	   public void Configure(EntityTypeBuilder<Propiedad> builder)
	   {
		  builder.ToTable("propiedad");
		  builder.HasKey(x => x.Id);


		  builder.Property(x => x.Id)
			  .HasColumnName("ID_Propiedad");

		  builder.Property(x => x.PropietarioID)
			  .HasColumnName("Propietario_ID");

		  builder.Property(x => x.Titulo)
			.HasColumnName("titulo");

		  var precioConverter = new ValueConverter<PrecioValue, decimal>(
			  costoValue => costoValue.Value,
			  costo => new PrecioValue(costo)
		  );

		  builder.Property(x => x.Precio)
			  .HasConversion(precioConverter)
			  .HasColumnName("precio");
		  //builder.Property(x => x.Precio)
		  //   .HasColumnName("precio");

		  builder.Property(x => x.Detalle)
			.HasColumnName("detalle");

		  builder.Property(x => x.ubicacion)
			.HasColumnName("ubicacion");

		  //builder.Property(x => x.Estado)
		  //    .HasColumnName("estado");

		  var tipoConverter = new ValueConverter<TipoEstadoReserva, string>(
		tipoEnumValue => tipoEnumValue.ToString(),
		tipo => (TipoEstadoReserva)Enum.Parse(typeof(TipoEstadoReserva), tipo)
	);

		  builder.Property(x => x.Estado)
			   .HasConversion(tipoConverter)
			   .HasColumnName("estado")
			   .HasMaxLength(20)
			   .IsRequired();

		  builder.Ignore("_domainEvents");
		  builder.Ignore(x => x.DomainEvents);
	   }
    }
}
