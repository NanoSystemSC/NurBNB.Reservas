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

        public virtual DbSet<Propiedad> Propiedad { get; set; }


        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
