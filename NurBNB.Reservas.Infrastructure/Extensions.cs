using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NurBNB.Reservas.Application;
using NurBNB.Reservas.Domain.Repositories;
using NurBNB.Reservas.Infrastructure.EF;
using NurBNB.Reservas.Infrastructure.EF.Context;
using NurBNB.Reservas.Infrastructure.EF.Repositories;
using NurBNB.Reservas.Infrastructure.Security;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration, bool isDevelopment)
        {
            services.AddApplication();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            AddDatabase(services,configuration,isDevelopment);

           // AddAuthentication(services, configuration);

            return services;
        }

        private static void AddDatabase(IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            var connectionString = configuration.GetConnectionString("ReservasDbConnectionString");
            //var connectionString = "Data Source = Reservas.sqlite";
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
            services.AddScoped<IReservaRepository, ReservaRepository>();

            services.AddScoped<ICancelarReservaRepository, CancelarReservaRepository>();
            services.AddScoped<ITipoCancelacionRepository, TipoCancelacionRepository>();

            using var scope = services.BuildServiceProvider().CreateScope();
            if (!isDevelopment)
            {
                var context = scope.ServiceProvider.GetRequiredService<ReadDbContext>();
                context.Database.Migrate();
            }
        }

        private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            JwtOptions jwtoptions = configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwtOptions =>
            {
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtoptions.SecretKey));
                jwtOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,
                    ValidateIssuer = jwtoptions.ValidateIssuer,
                    ValidateAudience = jwtoptions.ValidateAudience,
                    ValidIssuer = jwtoptions.ValidIssuer,
                    ValidAudience = jwtoptions.ValidAudience
                };
            });
        }
    }
}
