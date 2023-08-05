using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NurBNB.Reservas.Domain.Model.Clientes;
using NurBNB.Reservas.Domain.Model.Reservas;
using NurBNB.Reservas.Infrastructure.EF.Config;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Infrastructure.EF.Context
{
    internal class WriteDbContext: DbContext
    {
        public virtual DbSet<Huesped> Huesped { set; get; }
        public virtual DbSet<Propiedad> Propiedad { set; get; }
        //public virtual DbSet<Transaccion> Transaccion { set; get; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var huespedConfig = new HuespedConfig();
            modelBuilder.ApplyConfiguration(huespedConfig);

            var propiedadConfig = new PropiedadConfig();
            modelBuilder.ApplyConfiguration(propiedadConfig);

            //var transaccionConfig = new TransaccionConfig();
            //modelBuilder.ApplyConfiguration<Transaccion>(transaccionConfig);
            //modelBuilder.ApplyConfiguration<TransaccionItem>(transaccionConfig);


            modelBuilder.Ignore<DomainEvent>();
            //modelBuilder.Ignore<TransaccionConfirmada>();
        }
    }
}
