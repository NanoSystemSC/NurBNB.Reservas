using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NurBNB.Reservas.Domain.Model.Cancelacion;

namespace NurBNB.Reservas.Infrastructure.EF.Config
{
    internal class TipoCancelacionConfig : IEntityTypeConfiguration<TipoCancelacion>
    {
        public void Configure(EntityTypeBuilder<TipoCancelacion> builder)
        {
            builder.ToTable("TipoCancelacion");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID_TipoCancelacion");

            builder.Property(x => x.Descripcion)
                .HasColumnName("Descripcion");

            builder.Property(x => x.Dia_Ini)
                .HasColumnName("Dia_Ini");

            builder.Property(x => x.Dia_Fin)
                .HasColumnName("Dia_Fin");

            builder.Property(x => x.PorcentajeDevolucion)
                .HasColumnName("Porcentaje_Devolucion");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
