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

namespace NurBNB.Reservas.Infrastructure.EF.Config
{
    [ExcludeFromCodeCoverage]
    internal class HuespedConfig : IEntityTypeConfiguration<Huesped>
    {
        public void Configure(EntityTypeBuilder<Huesped> builder)
        {
            builder.ToTable("huesped");
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Id)
                .HasColumnName("huespedID");

            //var nombreConverter = new ValueConverter<ItemName, string>(
            //    nombreValue => nombreValue.Value,
            //    nombre => new ItemName(nombre)
            //);

            //builder.Property(x => x.Nombre)
            //    .HasConversion(nombreConverter)
            //    .HasColumnName("nombre");

            //var costoConverter = new ValueConverter<CostoValue, decimal>(
            //    costoValue => costoValue.Value,
            //    costo => new CostoValue(costo)
            //);

            //builder.Property(x => x.Costo)
            //    .HasConversion(costoConverter)
            //    .HasColumnName("costo");

            builder.Property(x => x.Nombre)
                .HasColumnName("nombres");

            builder.Property(x => x.Apellidos)
               .HasColumnName("apellidos");

            builder.Property(x => x.NroDoc)
               .HasColumnName("nrodoc");

            builder.Property(x => x.Email)
               .HasColumnName("email");

            builder.Property(x => x.Calle)
               .HasColumnName("calle");

            builder.Property(x => x.Ciudad)
               .HasColumnName("ciudad");

            builder.Property(x => x.Pais)
               .HasColumnName("pais");

            builder.Property(x => x.Codigo_postal)
               .HasColumnName("codigo_postal");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
