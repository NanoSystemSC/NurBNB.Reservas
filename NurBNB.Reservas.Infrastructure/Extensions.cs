using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NurBNB.Reservas.Application;
using NurBNB.Reservas.Domain.Repositories;
using NurBNB.Reservas.Infrastructure.EF;
using NurBNB.Reservas.Infrastructure.EF.Context;
using NurBNB.Reservas.Infrastructure.EF.Repositories;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration, bool isDevelopment)
        {
            services.AddApplication();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            AddDatabase(services,configuration,isDevelopment);

            return services;
        }

        private static void AddDatabase(IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            var connectionString =
                    configuration.GetConnectionString("ReservasDbConnectionString");
            //services.AddDbContext<ReadDbContext>(context =>
            //        context.UseSqlServer(connectionString));
            //services.AddDbContext<WriteDbContext>(context =>
            //    context.UseSqlServer(connectionString));

            services.AddDbContext<ReadDbContext>(context =>
                    context.UseSqlite(connectionString));

            services.AddDbContext<WriteDbContext>(context =>
                context.UseSqlite(connectionString));

            services.AddScoped<IUnitOfWork, UnitofWork>();
            services.AddScoped<IHuespedRepository, HuespedRepository>();
            services.AddScoped<IPropiedadRepository, PropiedadRepository>();
            //services.AddScoped<ITransaccionRepository, TransaccionRepository>();

            using var scope = services.BuildServiceProvider().CreateScope();
            if (!isDevelopment)
            {
                var context = scope.ServiceProvider.GetRequiredService<ReadDbContext>();
                context.Database.Migrate();
            }
        }
    }
}
