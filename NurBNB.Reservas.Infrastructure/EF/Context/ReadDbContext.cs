using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NurBNB.Reservas.Domain.Model.Reservas;
using NurBNB.Reservas.Infrastructure.EF.ReadModel;

namespace NurBNB.Reservas.Infrastructure.EF.Context
{
    internal class ReadDbContext: DbContext
    {
      

        public virtual DbSet<HuespedReadModel> Huesped { get; set;}

        public virtual DbSet<PropiedadReadModel> Propiedad { get; set; }

        public virtual DbSet<ReservaReadModel> Reserva { get; set; }

        public virtual DbSet<CancelarReadModel> CancelarReserva { get; set; }

        public virtual DbSet<TipoCancelacionReadModel> TipoCancelacion { get; set; }


        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
