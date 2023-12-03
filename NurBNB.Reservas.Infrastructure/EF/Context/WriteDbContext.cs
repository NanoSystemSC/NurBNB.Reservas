using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NurBNB.Reservas.Domain.Model.Cancelacion;
using NurBNB.Reservas.Domain.Model.Clientes;
using NurBNB.Reservas.Domain.Model.Reservas;
using NurBNB.Reservas.Infrastructure.EF.Config;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Infrastructure.EF.Context
{
	[ExcludeFromCodeCoverage]
	public class WriteDbContext : DbContext
	{
		public virtual DbSet<Huesped> Huesped { set; get; }
		public virtual DbSet<Propiedad> Propiedad { set; get; }

		public virtual DbSet<Reserva> Reserva { set; get; }

		public virtual DbSet<CancelarReserva> CancelarReservas { set; get; }

		public virtual DbSet<TipoCancelacion> TipoCancelacion { set; get; }

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

			var reservaConfig = new ReservaConfig();
			modelBuilder.ApplyConfiguration(reservaConfig);

			var cancelarConfig = new CancelarConfig();
			modelBuilder.ApplyConfiguration(cancelarConfig);

			var TipoCancelacionConfig = new TipoCancelacionConfig();
			modelBuilder.ApplyConfiguration(TipoCancelacionConfig);

			//var transaccionConfig = new TransaccionConfig();
			//modelBuilder.ApplyConfiguration<Transaccion>(transaccionConfig);
			//modelBuilder.ApplyConfiguration<TransaccionItem>(transaccionConfig);


			modelBuilder.Ignore<DomainEvent>();
			//modelBuilder.Ignore<TransaccionConfirmada>();
		}
	}
}
